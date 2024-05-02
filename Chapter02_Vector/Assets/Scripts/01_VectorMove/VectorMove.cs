using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorMove : MonoBehaviour
{
    public Transform target;
    [Range(1, 100)]
    public float speed = 1f;

    public bool isMoveNomarize = false;

    // Start is called before the first frame update
    void Start()
    {
        
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

            Vector3 dirVec = target.position - transform.position;

            Debug.Log("dirVec.magnitude: " + dirVec.magnitude);

            if (isMoveNomarize)
            {
                dirVec.Normalize();                       //Normalize == dirVec / dirVec.magnitude
                dirVec = dirVec / dirVec.magnitude;
            }

            transform.position += dirVec * speed * Time.deltaTime;
        }
    }
}

/* ���� �������� �����ϴ� ����� ������ ����� �ƴ϶�
 * ���� ��ġ���� �̿��� ������� �� ���� ��ġ������ ���͸� ����
 * ���� ���ο� ����� ���Ϳ���(-)�� �̿��ؼ� ���⼺�� �������� �� ���̴�.
 
    void Update()
    {
        if (targetObject != null)
        {
            float x = targetObject.transform.position.x - transform.position.x;
            float y = targetObject.transform.position.y - transform.position.y;

            double total = Math.Pow(x, 2) + Math.Pow(y, 2);
            double range = Math.Sqrt(total);

            if(Input.GetKeyDown(KeyCode.Space))
            {
                isMoveNomarize = !isMoveNomarize;
            }

            if (range > 0.1f && range < 3.0f)
            {
                if (isMoveNomarize)
                {
                    float xDir = (x > 0.0f) ? 1.0f : -1.0f;
                    float yDir = (y > 0.0f) ? 1.0f : -1.0f;

                    dirVec = new Vector3(xDir, yDir, 0);
                }
                else
                {
                    dirVec = new Vector3(x, y, 0);
                }
                
                transform.position += dirVec * moveSpeed * Time.deltaTime;
            }
        }
    }

 */