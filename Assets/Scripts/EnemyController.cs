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

    [SerializeField] private Transform AiPath;
    public static Transform[] paths { get; private set; }


    private void Start()
    {
        int n = AiPath.childCount;
        paths = new Transform[n];
        for (int i = 0; i < n; ++i)
        {
            paths[i] = AiPath.GetChild(i);
        }

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
        currentTargetPath = ++ currentTargetPath % paths.Length;

        myAgent.SetDestination(paths[currentTargetPath].position);
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
