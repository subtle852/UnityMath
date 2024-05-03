using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[ExecuteInEditMode]
public class Friction01 : MonoBehaviour
{
    [System.Serializable]
    public class PhysicData
    {
        public Rigidbody2D rigidbody;
        public PhysicsMaterial2D PhysicMaterial;
        public BoxCollider2D boxCollider;
    }

    public GameObject Box;
    public GameObject Slope;
    public GameObject Root;

    public PhysicData boxPhysicData = new PhysicData();
    public PhysicData slopePhysicData;

    public TextMesh textMesh;

    public Vector3 initVec;
    public float rot = -10.0f;

    void Start()
    {
        initVec = Box.transform.localPosition;
        rot = Root.transform.localEulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            boxPhysicData.rigidbody.velocity = Vector2.zero;
            Box.transform.localPosition = initVec;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Root.transform.rotation = Quaternion.Euler(0, 0, --rot);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Root.transform.rotation = Quaternion.Euler(0, 0, ++rot);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if(SceneManager.GetActiveScene().name.Equals("01_Friction"))
                SceneManager.LoadScene("02_Friction");
            else if(SceneManager.GetActiveScene().name.Equals("02_Friction"))
                SceneManager.LoadScene("03_Friction");
            else
                SceneManager.LoadScene("01_Friction");
        }

        UpdateText();
    }
    
    void UpdateText()
    {
        //아래로 미끄러지려는 힘 F = mgSinθ
        //정지 마찰계수 f = μmgCosθ
        float rot = 360 - Root.transform.eulerAngles.z;

        /*
        float gravity = 9.81f;
        float staticFriction = boxPhysicData.PhysicMaterial.friction;
        float Force = boxPhysicData.rigidbody.mass * gravity * Mathf.Sin(Mathf.Deg2Rad * rot);
        float Friction = staticFriction * boxPhysicData.rigidbody.mass * gravity * Mathf.Cos(Mathf.Deg2Rad * rot);
        */

        float Force = Mathf.Sin(Mathf.Deg2Rad * rot);
        float staticFriction = boxPhysicData.PhysicMaterial.friction;
        float Friction = staticFriction * Mathf.Cos(Mathf.Deg2Rad * rot);

        if (textMesh != null)
        {
            textMesh.text = "";
            textMesh.text += $"velocityc: {boxPhysicData.rigidbody.velocity}";
            textMesh.text += "\n";
            textMesh.text += $"정지마찰계수: {staticFriction}";
            textMesh.text += "\n";
            textMesh.text += $"Force: {Force}";
            textMesh.text += "\n";
            textMesh.text += $"Friction: {Friction}";
            textMesh.text += "\n";
            textMesh.text += $"Force - Friction: {Force - Friction}";
            textMesh.text += "\n";
            textMesh.text += $"Rot: {rot}";
        }
    }
}
