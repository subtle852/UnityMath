using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePoint : MonoBehaviour
{
    [SerializeField] public Transform target;
    // Start is called before the first frame update
    [SerializeField] public Transform[] Points;

    public int index;
    public bool isMoveNomarize = true;

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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isMoveNomarize = !isMoveNomarize;
            }

            Vector3 dirVec = (target.position - transform.position);
            float length = dirVec.magnitude;
            if (length <= 0.2f)
            {
                index++;
                index = (index >= Points.Length) ? 0 : index;

                target = Points[index];
            }

            if(isMoveNomarize) dirVec = dirVec.normalized;
            transform.position += dirVec * 2f * Time.deltaTime;

    /*        Vector2 dirVec2 = (target.position - transform.position);
            transform.right = dirVec2;

            Debug.Log("dirVec: " + dirVec);*/
            
            
            //각도 다시 작업하기..
            float rot = Mathf.Atan(dirVec.y / dirVec.x);
            float degree = rot * Mathf.Rad2Deg;

            Debug.Log("rot: " + rot);
            Debug.Log("degree: " + degree);

            //if (target.position.x < transform.position.x)
            if(dirVec.x < 0)
                degree = 180 + degree;

            transform.rotation = Quaternion.Euler(0, 0, degree);
            
        }
    }
}
