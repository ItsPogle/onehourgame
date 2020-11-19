using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject target;
    public int health = 1;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameManager.instance.player;
    }

    private void Update()
    {
        agent.SetDestination(target.transform.position);

        if(health <= 0)
        {
            Destroy(gameObject);
            GameManager.instance.score++;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameManager.instance.GameOver();
        }
    }
}
