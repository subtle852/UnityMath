using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    public float Gravity = 9.8f;

    public Vector3 MoveDirection = Vector3.right;

    float frontDirectionSpeed = 0f;         // X ÁÂÇ¥
    float upDirectionSpeed = 0f;          // Y ÁÂÇ¥
    Vector3 normalDirection;

    bool isInit = false;

    // Update is called once per frame
    void Update()
    {
        if (!isInit) return;

        upDirectionSpeed -= Gravity * Time.deltaTime;

        Vector3 nextPosition = transform.position;

        nextPosition.x += frontDirectionSpeed * Time.deltaTime;
        nextPosition.y += upDirectionSpeed * Time.deltaTime;

        transform.position = nextPosition;

        if (transform.position.y <= -10) Destroy(gameObject);
    }

    public void InitData(float RotValue, float startSpeed, Vector3 startPos)
    {
        transform.position = startPos;

        MoveDirection = new Vector3(Mathf.Cos(RotValue * Mathf.Deg2Rad), Mathf.Sin(RotValue * Mathf.Deg2Rad), 0);

        frontDirectionSpeed = MoveDirection.x * startSpeed;
        upDirectionSpeed = MoveDirection.y * startSpeed;

        isInit = true;
    }
}
