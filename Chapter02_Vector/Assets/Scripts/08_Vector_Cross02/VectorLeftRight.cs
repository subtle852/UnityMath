using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * ����Ű�� ���ؼ� CubePlayer�� �����̰�
 * SpaceŰ�� ������ ���� ���꿡 ���ؼ�(��������� ������ �߰� ����)
 * ���� ��������� ȸ��
 */
public class VectorLeftRight : MonoBehaviour
{
    public Transform Target;
    public Transform Player;
    public TextMesh textMesh;

    public LineRenderer LineDir;

    [Range(10, 50)]
    public float rotateSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //k�� �ε�ȣ(A X B) �� UP����(���� A, B�� ���� ������� UP������ �����ϸ� )
    void Update()
    {
        Vector3 dir = Player.position - Target.position;
        Vector3 cross = Vector3.Cross(Player.forward, dir);
        float dotUP = Vector3.Dot(cross.normalized, Vector3.up);

        //���Ʒ�..
        Vector3 crossFor = Vector3.Cross(Player.forward, dir);
        float dotFor = Vector3.Dot(crossFor.normalized, Vector3.right);

        Debug.Log("cross: " + cross);
        Debug.Log("dot:  " + dotUP);
        Debug.Log("dotFor: " + dotFor);

        Util.DrawLine(LineDir, dir, Color.yellow, 50f);
        //Util.DrawFowardLine(LineDir, crossFor, Color.yellow, 5f);

        if (Input.GetKey(KeyCode.Space))
        {
            //Player.forward = -dir;

            float angleY = dotUP > 0 ? -rotateSpeed : rotateSpeed;
            float y = (angleY * Time.deltaTime) + Player.rotation.eulerAngles.y;

            float angleX = dotFor > 0 ? -rotateSpeed : rotateSpeed;
            float x = (angleX * Time.deltaTime) + Player.rotation.eulerAngles.x;

            Player.rotation = Quaternion.Euler(x, y, 0);
        }

        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        {
            sb.Append("cross: " + cross);
            sb.Append("\n");
            sb.Append("dot: " + dotUP);
            sb.Append("\n");
            sb.Append("dotFor: " + dotFor);

            textMesh.text = sb.ToString();
        }
    }
}
