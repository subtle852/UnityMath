using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRigidbody : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public Vector3 dirVec;
    public TextMesh textMesh;

    public Rigidbody rigidbodyComponent;
    public bool isVelocity = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = gameObject.GetComponent<Rigidbody>();
        textMesh = gameObject.GetComponentInChildren<TextMesh>();

        rigidbodyComponent.useGravity = false;
    }

    private void FixedUpdate()
    {
        Move();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbodyComponent.velocity = Vector3.zero;
            isVelocity = !isVelocity;
        }
    }

    private void Move()
    {
        if (rigidbodyComponent != null)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");

            dirVec = new Vector3(x * moveSpeed, y * moveSpeed, 0);

            if (isVelocity)
            {
                rigidbodyComponent.velocity = dirVec;
            }
            else
            {
                rigidbodyComponent.AddForce(dirVec);
            }

            textMesh.text = nameof(Rigidbody) + "\n"
                + nameof(FixedUpdate) + "\n"
                + rigidbodyComponent.velocity + "\n"
                + "deltaTime:" + Time.deltaTime + "\n"
                + "fixedDeltaTime:" + Time.fixedDeltaTime;
        }
    }
}
