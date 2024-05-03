using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    public Rigidbody2D CircleRigid01;
    public Rigidbody2D CircleRigid02;
    public Rigidbody2D CircleRigid03;
    public Rigidbody2D CircleRigid04;

    public bool isStart = false;

    List<Rigidbody2D> ListRigidbody = new List<Rigidbody2D>();
    List<Vector3> ListInitPos = new List<Vector3>();
    List<TextMesh> ListTextMesh = new List<TextMesh>();

    private void Start()
    {
        ListRigidbody.Add(CircleRigid01);
        ListRigidbody.Add(CircleRigid02);
        ListRigidbody.Add(CircleRigid03);
        ListRigidbody.Add(CircleRigid04);

        foreach (var item in ListRigidbody)
        {
            ListInitPos.Add(item.transform.position);
            ListTextMesh.Add(item.GetComponentInChildren<TextMesh>());
        }

        SetDrag(1.0f, 0);
        SetDrag(0.7f, 1);
        SetDrag(0.5f, 2);
        SetDrag(0.3f, 3);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ResetVelocity();
            isStart = true;
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (isStart)
        {
            AddForce();
            isStart = false;
        }

        SetText();
    }

    private void SetDrag(float drag, int index)
    {
        ListRigidbody[index].drag = drag;
    }

    private void ResetVelocity()
    {
        foreach (var item in ListRigidbody)
        {
            item.velocity = Vector3.zero;
        }

        for (int i = 0; i < ListRigidbody.Count; i++)
        {
            ListRigidbody[i].transform.position = ListInitPos[i];
        }
    }

    private void AddForce()
    {
        foreach (var item in ListRigidbody)
        {
            item.AddForce(Vector3.right * 4f, ForceMode2D.Impulse);
        }
    }

    private void SetText()
    {
        for (int i = 0; i < ListTextMesh.Count; i++)
        {
            ListTextMesh[i].text = "";
            ListTextMesh[i].text += $"v: {ListRigidbody[i].velocity}";
            ListTextMesh[i].text += $", drag: {ListRigidbody[i].drag}";
            ListTextMesh[i].text += $"\nposition.x: {ListRigidbody[i].transform.position.x}";
        }
    }
}
