using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class BasicEnemyMovement : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Health>().Currenthealth >0)
        {
            agent.SetDestination(player.transform.position);
        }
    }
}
