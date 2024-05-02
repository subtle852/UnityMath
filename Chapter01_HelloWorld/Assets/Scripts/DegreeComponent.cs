using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DegreeComponent : MonoBehaviour
{
    [Range(1, 4)]
    public float scalar = 0.0f;
    [Range(0, 360)]
    public float degress = 0.0f;

    float dTime = 0.0f;

    public Vector3 dirVec;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        dTime += Time.deltaTime * 0.3f;
        float delta = scalar * Mathf.Sin(dTime);

        float x = delta * Mathf.Cos(Degrees2Rad(degress));
        float y = delta * Mathf.Sin(Degrees2Rad(degress));

        dirVec = new Vector3(x, y, 0);
        transform.localPosition = dirVec;
    }

    float Degrees2Rad(float degrees)
    {
        return degrees * Mathf.PI / 180;
    }
}
