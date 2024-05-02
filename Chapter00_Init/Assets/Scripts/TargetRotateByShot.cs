using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRotateByShot : MonoBehaviour
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

    // Update is called once per frame
    void Update()
    {
        if (Target != null)
        {
            float x = Target.position.x - Root.position.x;
            float y = Target.position.y - Root.position.y;
            float tan = y / x;

            float radianTan = Mathf.Atan(tan);
            degree = Rad2Degree(radianTan);

            Root.localRotation = Quaternion.Euler(0, 0, degree);
        }
    }

    float Rad2Degree(float rad)
    {
        return rad * 180 / Mathf.PI;
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
