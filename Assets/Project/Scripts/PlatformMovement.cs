using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{

    [SerializeField]
    private float velocity; //unitsPerSec

    private Vector2 initialPosition;

    [SerializeField]
    private List<Vector2> targetPoints;

    [SerializeField]
    private AnimationCurve movementCurve;
    private float currentLerpTime = 0.0f;
    private float lerpTime = 0.0f;
    private int currentIndex = 0;

    private Rigidbody2D rb;

    void Start()
    {
        initialPosition = transform.position;
        for(int i = 0; i < targetPoints.Count; i++)
        {
            targetPoints[i] += (Vector2)transform.position;
        }
        targetPoints.Insert(0, initialPosition);
        lerpTime = Vector2.Distance(targetPoints[0], targetPoints[1]) / velocity;
    }


    void Update()
    {
        currentLerpTime = Mathf.Min(currentLerpTime + Time.deltaTime, lerpTime);

        float t = currentLerpTime / lerpTime;

        this.transform.position = Vector2.Lerp(targetPoints[currentIndex],
            targetPoints[(currentIndex + 1) % targetPoints.Count],
            movementCurve.Evaluate(t));

        if(currentLerpTime == lerpTime)
        {
            int temp = currentIndex;
            currentIndex = (currentIndex + 1) % targetPoints.Count;
            lerpTime = Vector2.Distance(targetPoints[temp], targetPoints[currentIndex]) / velocity;
            currentLerpTime = 0.0f;
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(this.transform.position, 0.2f);
        foreach (Vector2 v in targetPoints) {
            Gizmos.DrawSphere(this.transform.position + (Vector3)v, 0.2f);
        }

        
    }
}
