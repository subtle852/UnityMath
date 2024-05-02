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

    //tan���� = a /b  =>  ���� = atan(a/b)
    void Update()
    {
        if (Target != null)
        {
/*            float x = Target.position.x - Root.position.x;
            float y = Target.position.y - Root.position.y;
            float tan = y / x;*/

            Vector2 vec = Target.position - Root.position;
            float tan = vec.y / vec.x;

            float radianTan = Mathf.Atan(tan); //���ϰ��� �����̹Ƿ� ������ �����ؾ� �Ѵ�.
            degree = Rad2Degrees(radianTan); //������ ����..

            Debug.Log("tan: " + tan + "  degree: " + degree);

            Root.localRotation = Quaternion.Euler(0, 0, degree);

            //   float degree = Rad2Degrees(Mathf.Atan2(y, x)); //������ ����..
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
