using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowComponent : MonoBehaviour
{
    public Transform targetObject;// Ÿ�� ��� ����
    public Vector3 dirVec;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(targetObject != null)
        {
            float x = targetObject.position.x - transform.position.x;
            float y = targetObject.position.y - transform.position.y;

            double total = System.Math.Pow(x, 2) + System.Math.Pow(y, 2);// Pow�� ����
            double range = System.Math.Sqrt(total);// Sqrt�� ��Ʈ
            // x^2 + y^2�� �տ� ��Ʈ�� ���� �ش� ������Ʈ�� ��� ������Ʈ ���� �Ÿ��� ����

            if(range > 0.1f && range < 2.0f)
            {
                dirVec = new Vector3(x, y, 0);
                transform.position += dirVec * moveSpeed * Time.deltaTime;
            }
        }
    }
}
