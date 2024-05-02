using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public LineRenderer LineX;
    public LineRenderer LineY;

    public void Update()
    {
        Util.DrawLine(LineX, transform, Util.DIRECTION.FORWARD, Color.red, 3f);
        Util.DrawLine(LineY, transform, Util.DIRECTION.UP, Color.green, 3f); 
    }
}
