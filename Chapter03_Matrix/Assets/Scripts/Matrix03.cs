using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix03 : MonoBehaviour
{
    public TextMesh textMesh1;
    public TextMesh textMesh2;
    public TextMesh textMesh3;
    public TextMesh textMesh4;
    public TextMesh textMesh5;
    public TextMesh textMesh6;

    public Transform Target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Target == null) return;

        {
            Matrix4x4 pos = Matrix4x4.Translate(Target.position);
            textMesh1.PrintMatrix(pos, false);
        }

        {
            Matrix4x4 rot = Matrix4x4.Rotate(Target.localRotation);
            textMesh2.PrintMatrix(rot, false);
        }

        {
            Matrix4x4 scale = Matrix4x4.Scale(Target.localScale);
            textMesh3.PrintMatrix(scale, false);
        }

        {
            Matrix4x4 matrix4X4 = Matrix4x4.TRS(Target.position, Target.localRotation, Target.localScale);
            textMesh4.PrintMatrix(matrix4X4, false);
        }

        /*{
            Matrix4x4 pos = Matrix4x4.Translate(Target.position);
            Matrix4x4 rot = Matrix4x4.Rotate(Target.localRotation);
            Matrix4x4 scale = Matrix4x4.Scale(Target.localScale);
            Matrix4x4 matrix4X4 = pos * rot * scale;

            textMesh5.PrintMatrix(matrix4X4, false);
        }*/

        //InverseMatrixÀû¿ë
        {
            Matrix4x4 matrix4X4 = Target.localToWorldMatrix;
            textMesh5.PrintMatrix(matrix4X4.inverse, false);
        }

        {
            Matrix4x4 matrix4X4 = Target.localToWorldMatrix;
            textMesh6.PrintMatrix(matrix4X4, false);
        }
    }
}
