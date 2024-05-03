using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{
    public Vector3 dirVec;
    public float moveSpeed = 1.0f;
    public float rotZ = 0.0f;
    public float rotX = 0.0f;
    public Vector3 rotVec;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        dirVec = new Vector3(x, y, 0);

        transform.position += dirVec * moveSpeed * Time.deltaTime;

        if(Input.GetKey(KeyCode.LeftControl))
        {
            rotZ += 1.0f;
        }
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            rotX += 1.0f;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rotZ = 0.0f;
            rotX = 0.0f;

            transform.position = Vector3.zero;
        }

        rotVec = new Vector3(rotX, 0, rotZ);
        transform.rotation = Quaternion.Euler(rotVec);
    }
}
