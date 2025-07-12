using System;
using UnityEngine;
using UnityEngine.AI;

public class AngelScript : MonoBehaviour
{
    public NavMeshAgent Agent;
    public GameObject Target;

    void Start()
    {
        FetchInfo();
        
    }

    void FixedUpdate()
    {
        Agent.SetDestination(Target.transform.position);
    }


    private void FetchInfo()
    {
        Agent = GetComponent<NavMeshAgent>();
        Target = GameObject.FindGameObjectWithTag("Tower");
    }
    
    
}
