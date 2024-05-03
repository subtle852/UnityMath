using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Force
���Ӽ� O(�������� ��) , ���� ����, 2D ���� ���� �̿� ����
Acceleration
���Ӽ� O(�������� ��) , ���� ����(�������Ͽ)
Impulse
���Ӽ� X(�������� ��) , ���� ���� �� ª�� ������ ��, �⵹�̳� ���߿� �̿�, , 2D ���� ���� �̿� ����
VelocityChange
���Ӽ� X(�������� ��) , ���� ����(�������Ͽ) �� ������ ���� �ٸ� ������Ʈ�� ������ �ӵ��� �������� ����
 */
public class Acceleration03 : MonoBehaviour
{
    [Range(0, 90)]
    public float RotValue;

    public Transform LineRot;
    public Transform StartPos;
    public GameObject Ball;
    public GameObject BallRigidBody;

    public float startSpeed = 20f;

    public TextMesh textMesh;

    public ForceMode forceMode = ForceMode.Impulse;

    public bool isCreateBall = false;

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if(RotValue < 90.0f) RotValue += 0.1f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if(RotValue > 0) RotValue -= 0.1f;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (startSpeed > 0) startSpeed -= 0.1f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (startSpeed < 30) startSpeed += 0.1f;
        }

        LineRot.rotation = Quaternion.Euler(new Vector3(0, 0, RotValue));

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isCreateBall = true;

            if (Ball != null)
            {
                GameObject go = Instantiate(Ball);
                MoveBall mb = go.GetComponent<MoveBall>();
                mb.InitData(RotValue, startSpeed, StartPos.position);
            }
        }

        if(textMesh != null)
        {
            textMesh.text = "";
            textMesh.text += $"����: {RotValue} \n";
            textMesh.text += $"�ӵ�: {startSpeed} \n";
        }
    }

    private void FixedUpdate()
    {
        if(isCreateBall)
        {
            if (BallRigidBody != null)
            {
                GameObject go = Instantiate(BallRigidBody);
                RigidMoveBall rigidMoveBall = go.GetComponent<RigidMoveBall>();
                rigidMoveBall.InitData(RotValue, startSpeed, StartPos.position, forceMode);
            }

            isCreateBall = false;
        }
    }
}
