using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Shooting : Enemy
{
    public Player player;

    public float ShootingInterval = 4f;
    public float chasingInterval = 2f;
    public float ShootingDistance = 3f;
    public float chasingDistance = 12f; 

    private NavMeshAgent agent;
    private float ShootingTimer;

    private float chasingTimer; 
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Player").GetComponent<Player>();
        agent = GetComponent<NavMeshAgent>();
        ShootingTimer = Random.Range(0, ShootingInterval);
        agent.SetDestination(player.transform.position);
    }

    // Update is called once per frame
    void Update()
    { // shotting logic
        ShootingTimer -= Time.deltaTime; 
        if ((ShootingTimer <= 0) && (Vector3.Distance(transform.position,player.transform.position) <= ShootingDistance))
        {
            ShootingTimer = ShootingInterval;
            GameObject bullet = Pooling.Instance.GetBullet(false);
            bullet.transform.position = transform.position;
            bullet.transform.forward = (player.transform.position - transform.position).normalized;

        }//chasing
        chasingTimer -= Time.deltaTime;
        if(chasingTimer <= 0)
        {
            chasingTimer = chasingInterval;
            agent.SetDestination(player.transform.position);

        }
    }
}
