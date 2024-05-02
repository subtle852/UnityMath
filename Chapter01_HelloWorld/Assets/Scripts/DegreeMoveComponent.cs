using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DegreeMoveComponent : MonoBehaviour
{
    [Range(1, 4)]
    public float scalar = 0.0f;
    public float degress = 0.0f;

    [Range(10, 100)]
    public float speed = 50f;

    public Vector3 dirVec;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        degress += Time.deltaTime * speed;
        if (degress > 360) degress = 0;

        float x = scalar * Mathf.Cos(Degrees2Rad(degress));
        float y = scalar * Mathf.Sin(Degrees2Rad(degress));

        dirVec = new Vector3(x, y, 0);
        transform.localPosition = dirVec;
    }

    float Degrees2Rad(float degrees)
    {
        Debug.Log("Degrees2Rad: " + degrees * Mathf.PI / 180);
        Debug.Log("Mathf.Deg2Rad: " + degrees * Mathf.Deg2Rad);

        return degrees * Mathf.PI / 180;
    }
}
