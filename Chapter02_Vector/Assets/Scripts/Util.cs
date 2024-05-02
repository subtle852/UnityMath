using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util : MonoBehaviour
{
    public enum DIRECTION
    {
        UP,
        RIGHT,
        FORWARD,
    }

    public static void DrawLine(LineRenderer line, Transform trans, DIRECTION dir, Color color, float length = 2.0f)
    {
        if (line == null)
        {
            Debug.LogError("라인렌더러 없음");
            return;
        }

        line.transform.rotation = Quaternion.identity;

        if(dir == DIRECTION.UP)
            line.SetPositions(new Vector3[] { Vector3.zero, trans.up * length });
        else if (dir == DIRECTION.RIGHT)
            line.SetPositions(new Vector3[] { Vector3.zero, trans.right * length });
        else if (dir == DIRECTION.FORWARD)
            line.SetPositions(new Vector3[] { Vector3.zero, trans.forward * length });

        line.startColor = color;
        line.endColor = color;
    }

    public static void DrawLine(LineRenderer line, Vector3 dirVec, Color color, float length = 2.0f)
    {
        if (line == null)
        {
            Debug.LogError("라인렌더러 없음");
            return;
        }

        line.transform.rotation = Quaternion.identity;

        line.SetPositions(new Vector3[] { Vector3.zero, dirVec.normalized * length });

        line.startColor = color;
        line.endColor = color;
    }

    public static void Rotate(Transform trans, float rotSpeed = 10.0f)
    {
        trans.Rotate(new Vector3(0, 0, Time.deltaTime * rotSpeed));
    }

    public static Vector3 MyCross(Vector3 v1, Vector3 v2)
    {
        float x = v1.y * v2.z - v1.z * v2.y;    //a2b3 - a3b2
        float y = v1.z * v2.x - v1.x * v2.z;    //a3b1 - a1b3
        float z = v1.x * v2.y - v1.y * v2.x;    //a1b2 - a2b1

        return new Vector3(x, y, z);
    }
}
