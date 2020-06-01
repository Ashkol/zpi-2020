using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Carrier : MonoBehaviour
{
    public Building sourceBuilding;
    public Building destinationBuilding;

    private NavMeshAgent agent;
    private float destinationReachedTreshold = 1f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        sourceBuilding = GetComponentInParent<Building>();
    }

    private void Update()
    {
        CheckDestinationReached();
    }

    public void MoveToDestination(float travelTime)
    {
        if (destinationBuilding != null)
        {
            agent.gameObject.SetActive(true);
            agent.isStopped = false;
            Vector3 destination = destinationBuilding.Entrance.transform.position;
            agent.speed = (Vector3.Distance(sourceBuilding.transform.position, destination) / travelTime) + 1f;
            agent.SetDestination(destination);
        }
    }

    void CheckDestinationReached()
    {
        if (destinationBuilding != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, destinationBuilding.Entrance.transform.position);
            if (distanceToTarget < destinationReachedTreshold)
            {
                ResetPosition();
            }
        }
    }

    public void ResetPosition()
    {
        transform.position = sourceBuilding.transform.position;
        agent.isStopped = true;
        agent.gameObject.SetActive(false);
    }
}
