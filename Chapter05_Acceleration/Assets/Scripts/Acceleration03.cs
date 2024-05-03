using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Force
연속성 O(연속적인 힘) , 무게 적용, 2D 게임 제작 이용 가능
Acceleration
연속성 O(연속적인 힘) , 무게 무시(자유낙하운동)
Impulse
연속성 X(순간적인 힘) , 무게 적용 ⇒ 짧은 순간의 힘, 출돌이나 폭발에 이용, , 2D 게임 제작 이용 가능
VelocityChange
연속성 X(순간적인 힘) , 무게 무시(자유낙하운동) ⇒ 질량이 서로 다른 오브젝트에 동일한 속도의 움직임이 가능
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
            textMesh.text += $"각도: {RotValue} \n";
            textMesh.text += $"속도: {startSpeed} \n";
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
