using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DegreeCircleComponent : MonoBehaviour
{
    [Range(1, 4)]
    public float scalar = 0.0f;
    public float degress = 0.0f;

    Vector3 dirVec;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    // 0 <= t <= 2¤Ðr
    // [x] = [ scalar * Cos(t) ] + [ scalar * Cos(3t) ]
    // [y]   [ scalar * Sin(t) ]   [ 0                ]
    void Update()
    {
        degress += Time.deltaTime * 50;

        float x = scalar * Mathf.Cos(Degrees2Rad(degress));
        float y = scalar * Mathf.Sin(Degrees2Rad(degress));

        x += scalar * Mathf.Cos(Degrees2Rad(degress * 3));

        dirVec = new Vector3(x, y, 0);
        transform.localPosition = dirVec;
    }

    float Degrees2Rad(float degrees)
    {
        return degrees * Mathf.PI / 180;
    }
}
