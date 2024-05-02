using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorCrossUpDown : MonoBehaviour
{
    public Transform RotateVecTF;
    public Transform Vec1;
    public Transform Vec3;
    public TextMesh textMesh;

    public LineRenderer lineRenderer;
    public LineRenderer lineRendererDir;
    public LineRenderer lineRendererCross;

    Vector3 cVec;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frameww
    void Update()
    {
        CrossVector();

        Vector3 dir = cVec - Vec3.position;
        if (dir.magnitude >= 0.1f) Vec3.position += dir * Time.deltaTime * 5.0f;

        Util.DrawLine(lineRenderer, RotateVecTF.right, Color.yellow, 10.0f);
    }

    void CrossVector()
    {
        Vector3 dir = Vec1.position - RotateVecTF.position;
        cVec = Vector3.Cross(RotateVecTF.right, dir);

        Util.DrawLine(lineRendererDir, dir, Color.magenta, 3.0f);
        Util.DrawLine(lineRendererCross, cVec, Color.blue, 3.0f);

        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        {
            sb.Append("dir: " + dir);
            sb.Append("\n");
            sb.Append("cVec: " + cVec);
            sb.Append("\n");
            string str = cVec.z < 0 ? "아래에 위치" : " 위에 위치";
            sb.Append(str);

            textMesh.text = sb.ToString();
        }
    }
}
