using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    GameManager gameManager;
    private NavMeshAgent myAgent;

    private int currentTargetPath;

    bool chase = false;

    

    private void Start()
    {
        gameManager = GetComponent<GameManager>();
        myAgent = GetComponent<NavMeshAgent>();
        SetNextTarget();
    }

    private void Update()
    {
        if (!chase)
        {
            if (myAgent.remainingDistance <= myAgent.stoppingDistance)
            {
                SetNextTarget();
            }
            
        }

    }

    public void SetNextTarget()
    {
        currentTargetPath = ++ currentTargetPath % GameManager.paths.Length;

        myAgent.SetDestination(GameManager.paths[currentTargetPath].position);
    }

    //private void OnTriggerStay(Collider other)
    //{
       // if (other.transform.tag == "Player")
       // {
        //    chase = true;
        //    myAgent.SetDestination(other.transform.position);
       // }
   // }
    //private void OnTriggerExit(Collider other)
    //{
        //if (other.transform.tag == "Player")
        //{
        //    chase = false;
       // }   
    //}
}
