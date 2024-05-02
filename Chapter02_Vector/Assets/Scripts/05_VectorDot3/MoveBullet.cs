using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    public GameObject Target;
    public LineRenderer Line;
    public Vector3 Dir;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Target != null)
        {
            
            transform.position += Dir.normalized * Time.deltaTime * 10.0f;

            Util.DrawLine(Line, Dir, Color.blue);

            if((Target.transform.position - transform.position).magnitude <= 0.1f)
            {
                Target.GetComponent<Plane>().HitPlane(Dir);
                Destroy(this.gameObject);
            }
        }
    }

    public void SetTarget(GameObject obj)
    {
        Target = obj;
        Dir = Target.transform.position - transform.position;
    }
}
