using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorCross : MonoBehaviour
{
    public Transform Vec1;
    public Transform Vec2;
    public Transform Vec3;
    public TextMesh textMesh;

    Vector3 cVec;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CrossVector();

        Vector3 dir = cVec - Vec3.position;
        if (dir.magnitude >= 0.1f) Vec3.position += dir.normalized * Time.deltaTime;
    }

    void CrossVector()
    {
        cVec = Vector3.Cross(Vec1.position, Vec2.position);
       //cVec = Vector3.Cross(Vec2.position, Vec1.position); //교환번칙 성립 안함

        Debug.Log(nameof(cVec) + ":  " + cVec);
        Debug.Log(nameof(Util.MyCross) + ":  " + Util.MyCross(Vec1.position, Vec2.position));

        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        {
            sb.Append("Vec1: " + Vec1.position);
            sb.Append("\n");
            sb.Append("Vec2: " + Vec2.position);
            sb.Append("\n");
            sb.Append("cVec: " + cVec);

            textMesh.text = sb.ToString();
        }
    }
}
