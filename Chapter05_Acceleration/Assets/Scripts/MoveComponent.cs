using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{
    public Vector3 dirVec;
    public float moveSpeed = 2.0f;
    public TextMesh textMesh;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = gameObject.GetComponentInChildren<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        dirVec = new Vector3(x, y, 0);

        transform.position += dirVec * moveSpeed * Time.deltaTime;

        textMesh.text = nameof(Transform) + "\n"
            + nameof(Update) + "\n" 
            + (dirVec * moveSpeed) + "\n"
            + "deltaTime:" + Time.deltaTime + "\n"
            + "fixedDeltaTime:" + Time.fixedDeltaTime;

    }
}
