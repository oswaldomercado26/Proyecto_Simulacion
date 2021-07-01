using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    
    public int damage = 5;
    public int life = 10;

    public ParticleSystem ded;

    public float speed = 10f;

    public Transform target;
    public int wavepointIndex = 0;
    public Transform[] wayPoints;

    void Start()
    {
        target = wayPoints[wavepointIndex];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position ) <= 0.4f)
        {
            GetNextWaypoint();
        }
        if (Input.GetKeyDown("t"))
        {  
            launchParticles();
        }
        if( life <1 )
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if ( other.gameObject.CompareTag("Ball")){
            life -= 5;
            launchParticles();
        }
    }
    private void GetNextWaypoint()
    {

        if (wavepointIndex >= wayPoints.Length -1)
        {
            return;
        }

        wavepointIndex++;
        target = wayPoints[wavepointIndex];

    }
    private void launchParticles(){
        ParticleSystem ps = Instantiate(ded, transform.position, Quaternion.identity);
        ps.Play();
    }
    private void OnDestroy() {
        launchParticles();
    }
}
