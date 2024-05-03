using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acceleration02 : MonoBehaviour
{
    public ForceMode setForcedMode = ForceMode.Force;
    public List<Transform> listObjects;

    public bool isMove = false;

    [System.Serializable]
    public class SetData
    {
        public Vector3 initVec;
        public Rigidbody rigidbody;
        public Vector3 dirVec;
        public float moveSpeed;
        public TextMesh textMesh;
        public ForceMode forceMode;

        public Vector3 DirVec { get => dirVec; set => dirVec = value; }
        public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }

        public SetData(Rigidbody rigidbody, Vector3 dirVec, float moveSpeed)
        {
            this.initVec = rigidbody.transform.position;
            this.rigidbody = rigidbody;
            this.dirVec = dirVec;
            this.moveSpeed = moveSpeed;

            textMesh = rigidbody.gameObject.GetComponentInChildren<TextMesh>();

            this.dirVec *= moveSpeed;

            Vector3 scale = rigidbody.transform.Find("Sphere").localScale;
            scale.x += rigidbody.mass * 0.1f;
            scale.y += rigidbody.mass * 0.1f;
            rigidbody.transform.Find("Sphere").localScale = scale;
        }

        public void SetForceMode(ForceMode forceMode)
        {
            this.forceMode = forceMode;
        }

        public void Move()
        {
            if (rigidbody != null)
            {
                rigidbody.AddForce(dirVec, this.forceMode);
            }
        }

        public void ViewTextMesh()
        {
            textMesh.text = rigidbody.transform.name + "\n"
            + "mass:" + rigidbody.mass + "\n"
            + "forceMode:" + forceMode + "\n"
            + string.Format("velocity:{0:0#.#0}", rigidbody.velocity.x);
        }

        public void Reset()
        {
            rigidbody.transform.position = initVec;
            rigidbody.velocity = Vector3.zero;
        }
    }

    public List<SetData> listDatas = new List<SetData>();

    void Start()
    {
        foreach (var item in listObjects)
        {
            // this.dirVec *= moveSpeed;

            //0.05f의 Speed(FixedUpdate)
            //listDatas.Add(new SetData(item.GetComponent<Rigidbody>(), Vector3.right, 0.05f));

            //10f의 Speed이므로 질량보다는 큰값으로 지정해야 움직임이 가능(스페이스키 누르면 적용(한번만))
            listDatas.Add(new SetData(item.GetComponent<Rigidbody>(), Vector3.right, 5f));
        }
    }

    // Update is called once per frame
    private void ChangeFoceMode()
    {
        foreach (var item in listDatas)
        {
            item.Reset();
        }

        setForcedMode += 1;

        if ((int)setForcedMode == 3 || (int)setForcedMode == 4)
        {
            listDatas[0].SetForceMode(ForceMode.Force);
            listDatas[1].SetForceMode(ForceMode.Impulse);

            listDatas[2].SetForceMode(ForceMode.Acceleration);
            listDatas[3].SetForceMode(ForceMode.VelocityChange);
        }
        else if ((int)setForcedMode == (int)ForceMode.Acceleration + 1)
        {
            setForcedMode = ForceMode.Force;

            foreach (var item in listDatas)
            {
                item.SetForceMode(setForcedMode);
            }
        }
        else
        {
            foreach (var item in listDatas)
            {
                item.SetForceMode(setForcedMode);
            }
        }

        isMove = true;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            ChangeFoceMode();
        }
    }

    private void FixedUpdate()
    {
        if (isMove)
        {
            foreach (var item in listDatas)
            {
                item.Move();
            }

            isMove = false;
        }

        /*foreach (var item in listDatas)
              {
                  item.Move();
              }*/

        foreach (var item in listDatas)
        {
            item.ViewTextMesh();
        }
    }
}
