using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpandDown : MonoBehaviour
{
    [Range(10, 50)]
    public float speed = 10.0f;
    [Range(1, 5)]
    public float scalar = 1.0f;
    public float degree = 0.0f;

    float y = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        degree += Time.deltaTime * speed;

        Vector3 direction = new Vector3(transform.localPosition.x, y + Mathf.Sin(Degree2Rad(degree)) * scalar, 0);
        transform.localPosition = direction;
    }

    float Degree2Rad(float degree)
    {
        return degree * Mathf.PI / 180;
    }
}
