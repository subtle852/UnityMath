using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMove : MonoBehaviour
{
    [Range(1, 4)]
    public float Scalar = 0.0f;
    [SerializeField] private float Degree;

    private Vector3 startPos;

    public void SetDegree(float degree) => Degree = degree;

    private void Start()
    {
        startPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Scalar += Time.deltaTime;

        float x = Scalar * Mathf.Cos(Degrees2Rad(Degree));
        float y = Scalar * Mathf.Sin(Degrees2Rad(Degree));

        Vector3 dirVec = startPos + new Vector3(x, y, 0);
        transform.localPosition = dirVec;
    }

    float Degrees2Rad(float degrees)
    {
        return degrees * Mathf.PI / 180;
    }

}
