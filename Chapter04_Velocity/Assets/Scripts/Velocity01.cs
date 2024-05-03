using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//등속운동: S(위치) = v(속도) * t(시간) [s = vt]
//S(displacement) = veclocity * time

//등가속운동: S = 1/2at^2 + v0t
public class Velocity01 : MonoBehaviour
{
    Vector3 posVec01;
    Vector3 posVec02;

    [Range(1, 8)]
    public float speed01 = 2f;
    private float displacement01 = 0f;

    [Range(0, 8)]
    public float acceleration = 0.2f;
    private float displacement02 = 0f;

    private float startTime = 0.0f;
    public float deltaTime = 0.0f;

    public Transform tran01;
    public Transform tran02;

    public TextMesh textMesh01;
    public TextMesh textMesh02;

    public void Start()
    {
        startTime = Time.time;

        posVec01 = tran01.position;
        displacement01 = posVec01.x;

        posVec02 = tran02.position;
        displacement02 = posVec02.x;
    }

    public void Update()
    {
        deltaTime = Time.time - startTime;

        float delta01 = (speed01 * deltaTime);
        posVec01.x = displacement01 + delta01;
        tran01.position = posVec01;

        float delta02 = (acceleration / 2 * Mathf.Pow(deltaTime, 2));
        posVec02.x = displacement02 + delta02;
        tran02.position = posVec02;

        PrintData();
    }

    private void PrintData()
    {
        if(textMesh01 != null)
        {
            textMesh01.text = "";
            textMesh01.text += $"speed01: {speed01}\n";
            textMesh01.text += $"posVec01: {posVec01.x}";

            textMesh02.text = "";
            textMesh02.text += $"acceleration: {acceleration}\n";
            textMesh02.text += $"posVec02: {posVec02.x}";
        }
    }
}
