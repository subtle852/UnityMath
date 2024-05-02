using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMove : MonoBehaviour
{
    private float Scalar = 0.0f;
    [SerializeField] private float Degree;

    private Vector3 startPos;

    public void SetDegree(float degree) => Degree = degree;

    // Start is called before the first frame update
    private void Start()
    {
        startPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Scalar += Time.deltaTime;

        float x = Scalar * Mathf.Cos(Degree2Rad(Degree));
        float y = Scalar * Mathf.Sin(Degree2Rad(Degree));

        Vector3 dirVec = startPos + new Vector3(x, y, 0);
        transform.localPosition = dirVec;
    }

    float Degree2Rad(float degree)
    {
        return degree * Mathf.PI / 180;
    }
}
