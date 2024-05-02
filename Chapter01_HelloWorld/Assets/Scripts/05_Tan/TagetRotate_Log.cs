using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagetRotate_Log : MonoBehaviour
{
    public Transform Target;
    public Transform Root;
    public GameObject Shot;

    private float degree;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateShot", 1.0f, 1.0f);
    }

    //tan알파 = a /b  =>  알파 = atan(a/b)
    void Update()
    {
        if (Target != null)
        {
/*            float x = Target.position.x - Root.position.x;
            float y = Target.position.y - Root.position.y;
            float tan = y / x;*/

            Vector2 vec = Target.position - Root.position;
            float tan = vec.y / vec.x;

            float radianTan = Mathf.Atan(tan); //리턴값은 라디언이므로 각도로 변경해야 한다.
            degree = Rad2Degrees(radianTan); //각도로 변경..

            Debug.Log("tan: " + tan + "  degree: " + degree);

            Root.localRotation = Quaternion.Euler(0, 0, degree);

            //   float degree = Rad2Degrees(Mathf.Atan2(y, x)); //각도로 변경..
            //   Root.localRotation = Quaternion.Euler(0, 0, degree);
        }
    }

    float Rad2Degrees(float rad)
    {
        return rad * 180 / Mathf.PI;
        //return rad * Mathf.Rad2Deg;
    }

    float Degrees2Rad(float degrees)
    {
        return degrees * Mathf.PI / 180;
    }

    private void CreateShot()
    {
        if(Shot != null)
        {
            GameObject obj = Instantiate<GameObject>(Shot, Root.position, Quaternion.identity);
            ShotMove shotMove = obj.GetComponent<ShotMove>();

            if (transform.localPosition.x > 0)
                degree += 180;

            shotMove.SetDegree(degree);

            Destroy(obj, 20.0f);
        }
    }
}
