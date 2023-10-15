using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinComponent : MonoBehaviour
{
    [Range(1, 4)]
    public float scalar = 0.0f;
    [Range(0, 360)]
    public float degree = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        degree += Time.deltaTime * 50.0f;

        // πÊ«‚ (x, y)
        float x = scalar * Mathf.Cos(Degree2Rad(degree));
        float y = scalar * Mathf.Sin(Degree2Rad(degree));

        Vector3 dirVec = new Vector3(x, y, 0);
        transform.position = dirVec;
    }

    float Degree2Rad(float degree)
    {
        return degree * Mathf.PI / 180;
    }
}
