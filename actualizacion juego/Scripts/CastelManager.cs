using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastelManager : MonoBehaviour
{
    //variables para determinar la vida de la torre
    public int maxHealth = 100;
    public int vida = 100;

    public HealtBar healthBar;
    public ParticleSystem dead;
    public GameObject PhysicBody;

    // Start is called before the first frame update
    void Start()
    {
        //inicia la vida con el 100%
        vida = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (vida <= 0)
        {
            Die();
        }
        if (Input.GetKeyDown("t"))
        {  
            launchParticles();
        }
    }

    private void Die()
    {
        //particulas en el body cuando se destrulla el objeto
        Destroy(PhysicBody);
        Destroy(gameObject);
        launchParticles();
        //solo lo puede destruir el objeto con la etiqueta enemy
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length > 0)
        {
            //foreach para destruir los enemigos cuando chocan con la casa
            foreach (GameObject enemy in enemies)
            {
                Destroy(enemy);
            }
        }
        print("Perdiste");
    }
    private void launchParticles(){

        print("launch");
        ParticleSystem ps = Instantiate(dead, transform.position, Quaternion.identity);
        ps.Play();
    }

    void OnTriggerEnter(Collider other) {
        //checar el golpe de enemigo para las particulas
        print("hit");
        if (other.tag == "Enemy")
        {
            vida -= other.GetComponent<EnemyMovement>().damage;
            Destroy(other.gameObject);
        }
        print(vida);
        healthBar.SetHealth(vida);
    }
}
