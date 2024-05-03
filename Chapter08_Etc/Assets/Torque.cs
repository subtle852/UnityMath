using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torque : MonoBehaviour
{
    public float amount = 0;
    public float timer = 0;

    public Rigidbody2D rigidbody2D;
    public Rigidbody rigidbody3D;
    public TextMesh textMesh01;
    public TextMesh textMesh02;

    public bool isChangeValue = false;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ResetVelocity();
            timer = 3f;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            amount += 1;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            amount -= 1;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rigidbody2D.angularDrag -= 0.01f;
            rigidbody3D.angularDrag -= 0.01f;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rigidbody2D.angularDrag += 0.01f;
            rigidbody3D.angularDrag += 0.01f;
        }

        if (timer <= 0)
        {
            ResetVelocity();
            timer = 0.0f;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    //Force는 default 값으로 질량을 사용하여 오브젝트에 연속적인 힘을 추가
    private void FixedUpdate()
    {
        SetText();

        if(rigidbody2D != null)
        {
            float v = amount * Time.fixedDeltaTime;
            rigidbody2D.AddTorque(v);
        }

        if (rigidbody3D != null)
        {
            float v = amount * Time.fixedDeltaTime;
            //rigidbody3D.AddRelativeTorque(transform.right * v, ForceMode.Force);

            rigidbody3D.AddTorque(transform.right * v);
        //    rigidbody3D.AddTorque(transform.up * v);
        }
    }

    private void SetText()
    {
        if(textMesh01 != null)
        {
            textMesh01.text = "";
            textMesh01.text += "Toque";
            textMesh01.text += $"\ntimer: {timer}";
            textMesh01.text += $"\namount: {amount * Time.fixedDeltaTime}";
            textMesh01.text += $"\nangularDrag: {rigidbody2D.angularDrag}";
            textMesh01.text += $"\nangularVelocity: {rigidbody2D.angularVelocity}";
            textMesh01.text += $"\nrotation: {rigidbody2D.transform.rotation}";
        }

        if (textMesh02 != null)
        {
            textMesh02.text = "";
            textMesh02.text += "Toque";
            textMesh02.text += $"\ntimer: {timer}";
            textMesh02.text += $"\namount: {amount * Time.fixedDeltaTime}";
            textMesh02.text += $"\nangularDrag: {rigidbody3D.angularDrag}";
            textMesh02.text += $"\nangularVelocity: {rigidbody3D.angularVelocity}";
            textMesh02.text += $"\nrotation: {rigidbody3D.transform.rotation}";
        }
    }

    private void ResetVelocity()
    {
        rigidbody2D.velocity = Vector3.zero;
        rigidbody3D.velocity = Vector3.zero;

        rigidbody2D.angularVelocity = 0.0f;
        rigidbody3D.angularVelocity = Vector3.zero;
    }
}
