using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaCastillo : MonoBehaviour
{
    public float vida = 1000;

    public Image barraDeVida;



    // Update is called once per frame
    void Update()
    {
        //es para la vida del castillo pero se cambio en otro metodo
        vida = Mathf.Clamp(vida, 0, 1000);
        barraDeVida.fillAmount = vida / 1000;
        if (vida <= 0)
        {
            Over.show();
        }
    }
}
