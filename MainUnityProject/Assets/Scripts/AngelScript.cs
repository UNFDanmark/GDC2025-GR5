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
        Agent.SetDestination(Target.transform.position);
    }

    void FixedUpdate()
    {
        
    }
    


    private void FetchInfo()
    {
        Agent = GetComponent<NavMeshAgent>();
        Target = GameObject.FindGameObjectWithTag("Tower");
    }
    
    
}
