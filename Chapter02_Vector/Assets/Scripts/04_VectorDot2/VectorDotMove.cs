using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * MoveSpeed > 0 => 움직임 가능
 * RotSpeed > 0  => 회전 가능
 * IsNormalized  => 정규화
 */
public class VectorDotMove : MonoBehaviour
{
    public Transform Target;
    public LineRenderer Line;
    public bool IsFollow = false;
    public float MoveSpeed = 1.0f;
    public float Rot;
    public float RotSpeed = 1.0f;
    public bool IsNormalized = true;

    void Awake()
    {
        Rot = transform.localEulerAngles.z;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IsNormalized = !IsNormalized;
        }

        DrawFowardLine();
        MoveFollow();

        Rot += Time.deltaTime * RotSpeed;
        transform.localRotation = Quaternion.Euler(0, 0, Rot);
    }

    private float MyDot(Vector2 v1, Vector2 v2)
    {
        return v1.x * v2.x + v1.y * v2.y;
    }

    private void DrawFowardLine()
    {
        if (Line == null) return;

        Line.transform.rotation = Quaternion.identity;

        Line.SetPositions(new Vector3[] { Vector3.zero, transform.up * 2f });
        Line.startColor = Color.red;
        Line.endColor = Color.red;
    }

    private void MoveFollow()
    {
        Vector3 dir = Target.position - transform.position;
        if(IsNormalized) dir = dir.normalized;
        float dot = Vector2.Dot(transform.up, dir);

        Debug.Log("dot: " + dot);
        IsFollow = dot > 0.6f && dir.magnitude < 2.0f;
        if (IsFollow)
        {
           // Vector3 dir = Target.position - transform.position;
            transform.position += transform.up.normalized * Time.deltaTime * MoveSpeed;
        }
    }
}
