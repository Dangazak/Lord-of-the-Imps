using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLvlButton : MonoBehaviour
{

    public void NextLvl()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        int sceneIndex = currentScene.buildIndex;
        sceneIndex++;
        //GameControl.control.StopMusc ();
        SceneManager.LoadScene(sceneIndex);
    }
}
