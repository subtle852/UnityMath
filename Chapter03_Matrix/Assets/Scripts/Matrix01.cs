using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix01 : MonoBehaviour
{
    public TextMesh textMesh1;
    public TextMesh textMesh2;
    public TextMesh textMesh3;
    public TextMesh textMesh4;
    public TextMesh textMesh5;

    int index = 0;

    public float rot = 45;
    public Vector3 ScaleVec;

    // Start is called before the first frame update
    void Start()
    {
        PrintMatrixBasic01(textMesh1, new Vector2(1, 2), Vector4.zero, Vector4.zero, Vector4.zero);
        PrintMatrixBasic02(textMesh2, new Vector2(1, 2), new Vector2(3, 4), Vector4.zero, Vector4.zero);

        Matrix4x4 matTranslate = Matrix4x4.Translate(new Vector2(1, 2));
        textMesh3.text = "Translate\n";
        textMesh3.PrintMatrixMM(matTranslate);

        Matrix4x4 matScale = Matrix4x4.Scale(ScaleVec);
        textMesh5.text = "Scale\n";
        textMesh5.PrintMatrixMM(matScale);

        InvokeRepeating(nameof(ChangeRotate), 1f, 1f);
    }

    //y => x => z
    public void ChangeRotate()
    {
        Matrix4x4 matRotate = Matrix4x4.zero;

        matRotate = index switch
        {
            0 => Matrix4x4.Rotate(Quaternion.Euler(0, rot, 0)),
            1 => Matrix4x4.Rotate(Quaternion.Euler(rot, 0, 0)),
            _ => Matrix4x4.Rotate(Quaternion.Euler(0, 0, rot)),
        };

        /*      if (index == 0)     //y축 회전
                {
                    matRotate = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
                }
                else if (index == 1)    //x축 회전
                {
                    matRotate = Matrix4x4.Rotate(Quaternion.Euler(45, 0, 0));
                }
                else//z축 회전
                {
                    matRotate = Matrix4x4.Rotate(Quaternion.Euler(0, 0, 45));
                }*/

        string eulerStr = index switch
        {
            0 => $"(0, {rot}, 0)\n",
            1 => $"({rot}, 0, 0)\n",
            _ => $"(0, 0, {rot})\n",
        };

        textMesh4.text = eulerStr;

        textMesh4.PrintMatrix(matRotate);
        index = (++index) > 2 ? 0 : index;
    }

    public void PrintMatrixBasic01(
        TextMesh textMesh, 
        Vector4 pos1, 
        Vector4 pos2, 
        Vector4 pos3, 
        Vector4 pos4)
    {
        if(textMesh == null)
        {
            Debug.LogError("textMesh is null");
            return;
        }

        var matrix = Matrix4x4.zero;
        matrix.SetColumn(0, pos1);
        matrix.SetColumn(1, pos2);
        matrix.SetColumn(2, pos3);
        matrix.SetColumn(3, pos4);

        textMesh.text = pos1.ToString() + "\n";
        textMesh.PrintMatrix(matrix);
    }

    public void PrintMatrixBasic02(TextMesh textMesh,
        Vector4 pos1,
        Vector4 pos2,
        Vector4 pos3,
        Vector4 pos4)
    {
        if (textMesh == null)
        {
            Debug.LogError("textMesh is null");
            return;
        }

        var matrix = Matrix4x4.zero;
        matrix.SetColumn(0, pos1);
        matrix.SetColumn(1, pos2);
        matrix.SetColumn(2, pos3);
        matrix.SetColumn(3, pos4);

        textMesh.text = pos1.ToString() + "\n";
        textMesh.text += pos2.ToString() + "\n";

        textMesh.PrintMatrixMM(matrix);
    }
   
}
