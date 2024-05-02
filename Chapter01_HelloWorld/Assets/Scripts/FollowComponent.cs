using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowComponent : MonoBehaviour
{
    public Vector3 dirVec;
    public float moveSpeed = 1.0f;
    public Transform targetObject;

    public bool isMoveNomarize = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
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

/*            Debug.Log($"x: {x}");
            Debug.Log($"y: {y}");
            Debug.Log($"total: {total}");
            Debug.Log($"range: {range}");*/
        }
    }
}
