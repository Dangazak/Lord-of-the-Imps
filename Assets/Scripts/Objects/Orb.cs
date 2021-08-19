using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Orb : MonoBehaviour
{

    public GameObject levelCompletedWindow;
    [SerializeField] LayerMask impsLayers;
    void OnTriggerEnter2D(Collider2D other)
    {
        if ((((1 << other.gameObject.layer) & impsLayers) != 0) && !other.isTrigger)
        {
            levelCompletedWindow.SetActive(true);
            other.gameObject.GetComponent<ImpMovement>().Stop();
            //deactivate input control
            //Update stats
            Debug.Log("Victory");
            AudioManager.instance.PlaySound(AudioManager.instance.orbSound);
            AudioManager.instance.PlayLevelcompletedMusic();
            PersistentDataManager.instance.SetLevelScore(SceneManager.GetActiveScene().buildIndex, 1);
        }
    }
}
