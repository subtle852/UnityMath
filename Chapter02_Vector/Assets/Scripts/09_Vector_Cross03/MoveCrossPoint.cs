using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCrossPoint : MonoBehaviour
{
    [SerializeField] public Transform target;
    // Start is called before the first frame update
    [SerializeField] public Transform[] Points;

    [Range(1, 5)]
    public float moveSpeed = 1f;
    [Range(10, 100)]
    public float rotateSpeed = 10f;

    public int index;

    void Start()
    {
        index = 0;

        target = Points[index];
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Vector3 dirVec = (target.position - transform.position);
            float length = dirVec.magnitude;
            if (length <= 0.01f)
            {
                index++;
                index = (index >= Points.Length) ? 0 : index;

                target = Points[index];
            }

            transform.position += transform.up * moveSpeed * Time.deltaTime;

            Vector3 cross = Vector3.Cross(transform.up, dirVec);

            float dotForward = Vector3.Dot(cross, Vector3.forward);

            float angleZ = dotForward > 0 ? rotateSpeed : -rotateSpeed;
            float z = (angleZ * Time.deltaTime) + transform.rotation.eulerAngles.z;

            transform.rotation = Quaternion.Euler(0, 0, z);
        }
    }
}

//각도 다시 작업하기..
/*            float rot = Mathf.Atan(dirVec.y / dirVec.x);
            float degree = rot * Mathf.Rad2Deg;

            if(dirVec.x < 0)
                degree = 180 + degree;

            transform.rotation = Quaternion.Euler(0, 0, degree);*/
