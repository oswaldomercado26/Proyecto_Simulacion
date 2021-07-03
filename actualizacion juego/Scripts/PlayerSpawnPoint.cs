using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player;
    void Start()
    {
        
    }
    void FixedUpdate() {
        //determina los enemigos y puedes aumentar las oleadas si presionas r
        if (Input.GetKeyDown("r"))
        {
            MovePlayer();
        }
    }

    private void MovePlayer()
    {
        // mueve la posicion de los enemigos
        player.transform.position = transform.position;
    }
}
