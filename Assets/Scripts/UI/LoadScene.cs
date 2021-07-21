using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadSceneWithIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadNextNotCompletedScene()
    {
        SceneManager.LoadScene(PersistentDataManager.instance.GetNextNotClearedLevel());
    }
}
