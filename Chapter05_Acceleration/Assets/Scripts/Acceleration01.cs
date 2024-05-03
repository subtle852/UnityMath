using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acceleration01 : MonoBehaviour
{
    public Transform movementObject;
    public Transform rigidbodyObject;

    // Start is called before the first frame update
    void Start()
    {
        if(movementObject != null)
        {
            movementObject.gameObject.AddComponent<MoveComponent>();
        }

        if (rigidbodyObject != null)
        {
            rigidbodyObject.gameObject.AddComponent<MoveRigidbody>();
        }
    }
}
