using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpDown : MonoBehaviour
{
    [Range(10, 50)]
    public float speed = 10.0f;
    [Range(1, 5)]
    public float scalar = 1.0f;
    public float degress = 0.0f;

    float y = 0.0f; 

    // Start is called before the first frame update
    void Start()
    {
        y = transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        degress += Time.deltaTime * speed;
        
        Vector3 direction = new Vector3(transform.localPosition.x, y + Mathf.Sin(Degrees2Rad(degress)) * scalar, 0);
        transform.localPosition = direction ;
    }

    float Degrees2Rad(float degrees)
    {
        return degrees * Mathf.PI / 180;
    }
}
