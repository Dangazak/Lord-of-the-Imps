using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLvlButton : MonoBehaviour
{

    public void NextLvl()
    {
        Scene escena = SceneManager.GetActiveScene();
        int sceneIndex = escena.buildIndex;
        sceneIndex++;
        //GameControl.control.StopMusc ();
        SceneManager.LoadScene(sceneIndex);
    }
}
