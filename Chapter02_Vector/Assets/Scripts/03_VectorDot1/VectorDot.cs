using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorDot : MonoBehaviour
{
    public Transform VecA;
    public Transform VecB;

    public TextMesh textDot;
    public TextMesh textMyDot;
    public TextMesh textDegree;

    public LineRenderer[] lines;
    public int lineIndex = -1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(VecA != null && VecB != null)
        {
            Vector2 v1 = VecA.position;
            Vector2 v2 = VecB.position;

            float dot = Vector2.Dot(v1, v2);
            float myDot = MyDot(v1, v2);

            if (textDot != null)
            {
                textDot.text = "Dot: " + dot.ToString();
            }

            if (textMyDot != null)
            {
                textMyDot.text = "MyDot: " + myDot.ToString();
            }

            if(textDegree != null)
            {
                //A¡¤B = |A||B|cos¥è ==> cos¥è = A¡¤B / |A||B|  ==>  ¥è = Acos(A¡¤B / |A||B|)
                textDegree.text = "¥è " + Mathf.Rad2Deg * Mathf.Acos(dot / (v2.magnitude * v1.magnitude));
            }

            DrawLine(v1, Color.yellow, 0);
            DrawLine(v2, Color.red, 1);
        }
    }

    private float MyDot(Vector2 v1, Vector2 v2)
    {
        return v1.x * v2.x + v1.y * v2.y;
    }

    private void DrawLine(Vector3 target, Color color, int index)
    {
        LineRenderer line = lines[index];
        line.SetPositions(new Vector3[] { Vector3.zero, target });
        line.startColor = color;
        line.endColor = color;

        Debug.DrawLine(Vector3.zero, target, Color.red);
    }
}
