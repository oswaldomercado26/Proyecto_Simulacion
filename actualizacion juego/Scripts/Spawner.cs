using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawners;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        //se actualiza sin la necesidad de presionar rpara generar mas enemigos
        spawners = new GameObject[5];
        for (int i =0;i<spawners.Length;i++){
            spawners[i]= transform.GetChild(i).gameObject;
        }
    }

    private void SpawnEnemy() {
        //crea enemigos apartir de cierta posicion 
        int spawnerID = Random.Range(0, spawners.Length);
        Instantiate(enemy,spawners[spawnerID].transform.position,spawners[spawnerID].transform.rotation);
    }
    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.T)){
            SpawnEnemy();
        }
        
    }
}
