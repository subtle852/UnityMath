using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidMoveBall : MonoBehaviour
{
    public Rigidbody rigidbody;
    public Vector3 MoveDirection = Vector3.right;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -10) Destroy(gameObject);
    }

    public void InitData(float RotValue, float startSpeed, Vector3 startPos, ForceMode forceMode)
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();

        transform.position = startPos + new Vector3(0.5f, 0.5f, 0.0f);

        MoveDirection = new Vector3(Mathf.Cos(RotValue * Mathf.Deg2Rad), Mathf.Sin(RotValue * Mathf.Deg2Rad), 0);
        MoveDirection = MoveDirection.normalized;

        rigidbody.AddForce(MoveDirection * startSpeed, forceMode);
    }
}
