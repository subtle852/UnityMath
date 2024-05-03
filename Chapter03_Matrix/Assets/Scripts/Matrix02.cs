using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix02 : MonoBehaviour
{
    public TextMesh textMesh1;
    public TextMesh textMesh2;
    public TextMesh textMesh3;
    public TextMesh textMesh4;
    public TextMesh textMesh5;
    public TextMesh textMesh6;

    public Vector3 zeroVec = Vector3.zero;
    public Vector3 vecPos = new Vector3(-3, 3, 0);
    public Vector3 vecRot;
    public Vector3 vecScale = new Vector3(1.0f, 0.5f, 1.0f);
    public Vector3 vecInit;

    [Header("Å¸°Ù")]
    public Transform target;
    public int index;

    // Start is called before the first frame update
    void Start()
    {
        vecInit = target.localScale;

        InvokeRepeating(nameof(ChangePosition), 1, 2);
        InvokeRepeating(nameof(ChangeRotate), 1, 2);
        InvokeRepeating(nameof(ChangeScale), 1, 2);
    }

    private void ChangePosition()
    {
        index = (++index) > 1 ? 0 : index;

        if (index == 0)
        {
            // target.position = zeroVec;

            Matrix4x4 matTranslate = Matrix4x4.Translate(zeroVec);
            textMesh1.PrintMatrix(matTranslate, false);

            target.position = matTranslate.GetColumn(3);
        }
        else
        {
            {
                //  target.position = vec1;
            }

            {
                Matrix4x4 matTranslate = Matrix4x4.Translate(target.position);
                target.position = matTranslate.MultiplyPoint(vecPos);
                //target.position = matTranslate * vec1;

                textMesh1.PrintMatrix(Matrix4x4.Translate(target.position), false);
            }
        }

        textMesh3.text = $"pos: {target.position}";
    }

    private void ChangeRotate()
    {
        if (index == 0)
        {
            target.rotation = Quaternion.identity;

            Matrix4x4 matTranslate = Matrix4x4.Rotate(target.rotation);
            textMesh2.PrintMatrix(matTranslate, false);
        }
        else
        {
            //target.rotation = Quaternion.Euler(vecRot);

            Matrix4x4 matRot = Matrix4x4.Rotate(Quaternion.Euler(vecRot));
            textMesh2.PrintMatrix(matRot, false);

            {
             //   target.rotation = Quaternion.LookRotation(matRot.GetColumn(2), matRot.GetColumn(1));

             //   target.up = matRot.GetColumn(1);
            }

            {
          /*      var dir = target.position - Vector3.zero;
                float radian = Mathf.Atan(dir.y / dir.x);
                float degree = radian * Mathf.Rad2Deg;

                if (radian < 0) degree = 360 - degree;
                target.rotation = Quaternion.Euler(0, 0, degree);*/
            }

            {
                //degree = arccos(A dot B / |A||B|)
                Vector3 up = matRot.GetColumn(1); //x:0, y:1, z:2

                float dot = Vector3.Dot(Vector3.up, up);
                float degree = Mathf.Acos(dot / (Vector3.up.magnitude * up.magnitude)) * Mathf.Rad2Deg;

                target.rotation = Quaternion.Euler(0, 0, degree);
            }
        }

        textMesh4.text = $"rot: {target.eulerAngles}";
    }

    private void ChangeScale()
    {
        if (index == 0)
        {
            target.localScale = vecInit;

            Matrix4x4 matrixScale = Matrix4x4.Scale(target.localScale);
            textMesh6.PrintMatrix(matrixScale, false);
        }
        else
        {
            target.localScale = vecScale;

            Matrix4x4 matrixScale = Matrix4x4.Scale(target.localScale);
            textMesh6.PrintMatrix(matrixScale, false);
        }

        textMesh5.text = $"scale: {target.localScale}";
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
