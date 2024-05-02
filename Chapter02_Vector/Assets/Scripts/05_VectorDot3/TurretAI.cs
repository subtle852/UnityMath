using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAI : MonoBehaviour
{
    public GameObject[] Targets;
    public Transform Root;
    public LineRenderer Line;
    public GameObject Bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Util.DrawLine(Line, transform, Util.DIRECTION.RIGHT, Color.white, 4f);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < Targets.Length; i++)
            {
                GameObject bullet = Instantiate<GameObject>(Bullet);
                bullet.transform.position = Root.transform.position;
                bullet.transform.localScale = Vector3.one * 0.5f;
                (bullet.GetComponent<MoveBullet>()).SetTarget(Targets[i]);
            }
        }
    }
}
