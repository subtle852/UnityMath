using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public Vector3 startPos;
    public Transform Target;
    public LineRenderer line;
    public float Rot;
    public float RotSpeed = 2f;
    public bool isHit = false;

    float Dot = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Target != null) Dot = Vector2.Dot(Target.right, transform.up);

        Util.DrawLine(line, transform, Util.DIRECTION.UP, Color.red, 3f);

        if (isHit == true)
        {
            float length = (startPos - transform.position).magnitude;
            if (length > 0.1f)
            {
                if (Dot >= 0)
                {
                    transform.position -= transform.up.normalized * Time.deltaTime * 2.0f;
                }
                else
                {
                    transform.position += transform.up.normalized * Time.deltaTime * 2.0f;
                }
            }
            else if(length <= 0.1f)
            {
                isHit = false;
            }
        }
        else
        {
            Util.Rotate(transform, 30.0f);
        }
    }

    [ContextMenu("HitPlane")]
    public void HitPlane(Vector3 dirVec)
    {
        if(isHit == false)
        {
            //Vector3 dir = transform.position - dirVec;
            //transform.position += -dir.normalized * 2.0f; 

            //여기서 내적을 이용해서 같은 방향인지 아닌지 체크 후에 
            //충격 후 이동 방향을 결정
            if (Dot >= 0)
            {
                
                transform.position += transform.up.normalized * 2.0f;
            }
            else
            {
                transform.position += -transform.up.normalized * 2.0f;
            }
            isHit = true;
        }
    }
}
