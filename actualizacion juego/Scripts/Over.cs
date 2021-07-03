using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Over : MonoBehaviour
{
    public GameObject GameOverText;
    public static GameObject GameOverStatic;

    // Start is called before the first frame update
    void Start()
    {
        //mensaje de game over 
        Over.GameOverStatic = GameOverText;
        Over.GameOverStatic.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void show()
    {
        // se activa cuando pierdes la vida 
        Over.GameOverStatic.gameObject.SetActive(true);
    }
}
