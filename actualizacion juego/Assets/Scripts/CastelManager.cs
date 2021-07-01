using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastelManager : MonoBehaviour
{

    public int maxHealth = 100;
    public int vida = 100;

    public HealtBar healthBar;
    public ParticleSystem dead;
    public GameObject PhysicBody;

    // Start is called before the first frame update
    void Start()
    {
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
        Destroy(PhysicBody);
        Destroy(gameObject);
        launchParticles();
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length > 0)
        {
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
