using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneCtrl : MonoBehaviour
{
  public void ChangeScene(string sceneName)
    {
        //cambiar escena
        SceneManager.LoadScene(sceneName);
    }

    public void QuitApp()
    {
        //salir de la app
        Application.Quit();
    }
}
