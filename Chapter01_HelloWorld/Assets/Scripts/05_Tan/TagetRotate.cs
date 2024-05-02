using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagetRotate : MonoBehaviour
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

    void Update()
    {
        if (Target != null)
        {
            float x = Target.position.x - Root.position.x;
            float y = Target.position.y - Root.position.y;
            float tan = y / x;

            float radianTan = Mathf.Atan(tan); 
            degree = Rad2Degrees(radianTan); 

            Root.localRotation = Quaternion.Euler(0, 0, degree);
        }
    }

    float Rad2Degrees(float rad)
    {
        return rad * 180 / Mathf.PI;
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
