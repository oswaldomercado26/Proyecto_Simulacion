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
        // se checa la posicion donde salen para determinar el desplazamieniento que van a tener y la distancia en tre cada uno de los enemigos
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
        //si con el objeto que defiendes choca eliminas al enemigo
        if ( other.gameObject.CompareTag("Ball")){
            life -= 5;
            launchParticles();
        }
    }
    private void GetNextWaypoint()
    {
        //determina aleatoriamente por donde van a salir los enemigos
        if (wavepointIndex >= wayPoints.Length -1)
        {
            return;
        }

        wavepointIndex++;
        target = wayPoints[wavepointIndex];

    }
    private void launchParticles(){
        //particulas de funcionamiento de las colisiones del enemigo
        ParticleSystem ps = Instantiate(ded, transform.position, Quaternion.identity);
        ps.Play();
    }
    private void OnDestroy() {
        launchParticles();
    }
}
