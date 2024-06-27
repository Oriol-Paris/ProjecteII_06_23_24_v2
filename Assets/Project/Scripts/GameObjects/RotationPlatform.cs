using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPlatform : MonoBehaviour
{
    [SerializeField]
    public float velocity; //unitsPerSec

    [SerializeField]
    public AnimationCurve rotationCurve;

    private float time;
    private float curveFactor;
    private float rotationAmount;
    private float normalizedTime;

    void Start()
    {
        time = 0f;
    }

    
    void Update()
    {
        time += Time.deltaTime;

        normalizedTime = time % 1f;

        curveFactor = rotationCurve.Evaluate(normalizedTime);

        rotationAmount = velocity * curveFactor * Time.deltaTime;

        transform.Rotate(Vector3.forward, rotationAmount);

    }
}
