using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheck : MonoBehaviour
{
    public float Angle = 120.0f;
    public float Distance = 3.0f;

    public LineRenderer[] Lines;
    public LineRenderer[] TargetLines;
    public List<Transform> ListTargets;

    private class TargetData
    {
        public Vector3 dir;
        public float magnitude;

        public TargetData(Vector3 dir, float magnitude)
        {
            this.dir = dir;
            this.magnitude = magnitude;
        }
    }
    private List<TargetData> ListDetects = new List<TargetData>();

    // Start is called before the first frame update
    void Start()
    {
        ListTargets = new List<Transform>();

        foreach (var item in GameObject.FindObjectsOfType<GameObject>())
        {
            if(item.name == "CubeRotate")
                ListTargets.Add(item.transform);
        }  
    }

    // Update is called once per frame
    void Update()
    {
        //DrawAngleLine
        {
            Vector3 leftDir = GetDirirection(-Angle / 2);
            Vector3 RightDir = GetDirirection(Angle / 2);

            Util.DrawLine(Lines[0], leftDir, Color.white, Distance);
            Util.DrawLine(Lines[1], RightDir, Color.white, Distance);
        }

        {
            ListDetects.Clear();

            int tagetCount = 0;

            for (int i = 0; i < ListTargets.Count; i++)
            {
                Transform targetTF = ListTargets[i];

                Vector3 dirVec = targetTF.position - transform.position;

                float dot = Vector3.Dot(transform.up, dirVec.normalized);
                float targetCos = Mathf.Cos((Angle / 2) * Mathf.Deg2Rad);
                float magnitude = dirVec.magnitude;

                Debug.Log("Dot: " + dot);
                Debug.Log("targetCos: " + targetCos);
                Debug.Log("magnitude: " + magnitude);

                if (targetCos < dot && magnitude < Distance)
                {
                    Util.Rotate(targetTF, 200);

                    Debug.Log("Å½»ö ¿Ï·á!!!");
                    tagetCount++;

                    ListDetects.Add(new TargetData(dirVec, magnitude));
                }
            }


            foreach (var item in TargetLines)
            {
                item.gameObject.SetActive(false);
            }
            for (int i = 0; i < ListDetects.Count; i++)
            {
                if (TargetLines.Length >= ListDetects.Count)
                {
                    TargetLines[i].gameObject.SetActive(true);
                    Util.DrawLine(TargetLines[i], ListDetects[i].dir, Color.green, ListDetects[i].magnitude);
                }
            }
        }
    }

    private Vector2 GetDirirection(float angle)
    {
        Vector2 dirVec = Vector3.zero;

        angle += transform.eulerAngles.z;
        float x = Mathf.Sin(angle * Mathf.Deg2Rad);
        float y = Mathf.Cos(angle * Mathf.Deg2Rad);

        dirVec = new Vector2(x, y);

        return dirVec;
    }
}
