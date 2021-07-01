using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dañocastillo : MonoBehaviour
{
    VidaCastillo vidacastillo;
    public int cantidad;
    public float damageTime;
    float currentDamageTime;
    // Start is called before the first frame update
    void Start()
    {
        vidacastillo = GameObject.FindWithTag("Castillo").GetComponent<VidaCastillo>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Castillo")
        {
            currentDamageTime += Time.deltaTime;
            if (currentDamageTime > damageTime)
            {
                vidacastillo.vida += cantidad;
                currentDamageTime = 0.0f;
            }
        }
    }
}
