using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemyPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            spawnNewEnemy();
        }
    }

    public void spawnNewEnemy(){
        //hace el llamado a la creacion de nuevos enemigos
        int randomNumber = Mathf.RoundToInt(UnityEngine.Random.Range( 0, transform.childCount));
        GameObject go = Instantiate(enemyPrefab, transform.GetChild(randomNumber).transform.position, Quaternion.identity);
        go.transform.GetComponent<EnemyMovement>().wayPoints = GetChilds(transform.GetChild(randomNumber).transform);
    }

    Transform[] GetChilds(Transform el){
        //se utiliza la transformacion para crear mas hijos de enemigos 
        Transform[] childs;
        childs = new Transform[el.childCount];
        for (int i = 0; i < childs.Length; i++)
        {
            childs[i] = el.GetChild(i);
        }
        return childs;
    }

}
