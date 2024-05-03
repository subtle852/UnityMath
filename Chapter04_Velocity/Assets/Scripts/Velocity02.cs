using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//x = vcos(θ)
//y = vsin(θ) - gt
public class Velocity02 : MonoBehaviour
{
    [Range(0, 90)]
    public float RotValue;

    public Transform LineRot;
    public Transform StartPos;
    public GameObject Ball;

    public float startSpeed = 20f;

    public TextMesh textMesh;

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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(Ball != null)
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
}
