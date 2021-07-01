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
        if (Input.GetKeyDown("r"))
        {
            MovePlayer();
        }
    }

    private void MovePlayer()
    {
        player.transform.position = transform.position;
    }
}
