using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportProximity : MonoBehaviour
{
    [SerializeField]
    public Transform player;

    [SerializeField]
    public float teleportDistance = 2.5f;

    [SerializeField]
    public Vector3[] teleportPositions;

    private int nextPositionIndex = 0;

    private Vector3 originalPos;

    private float distanceToPlayer;

    void Start()
    {
        originalPos = this.transform.position;
    }

    void Update()
    {
        distanceToPlayer = Vector3.Distance(player.position, transform.position);

        if (distanceToPlayer < teleportDistance)
            TeleportNextPosition();
    }

    void TeleportNextPosition()
    {
        if (teleportPositions.Length == 0)
        {
            Debug.Log("No hay posiciones en el vector");
            return;
        }

        transform.position = teleportPositions[nextPositionIndex];

        nextPositionIndex = (nextPositionIndex + 1) % teleportPositions.Length;
    }

    public void StartFromBeggining()
    {
        this.transform.position = originalPos;
        nextPositionIndex = 0;
    }
}