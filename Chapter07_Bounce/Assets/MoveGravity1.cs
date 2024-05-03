using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGravity1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        if(rigidbody2D != null)
        {
            rigidbody2D.AddForce(-Vector2.up * 100, ForceMode2D.Force);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
