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
        //if (other.gameObject.layer == impsLayers)
        {
            //levelCompletedWindow.SetActive(true);
            other.gameObject.GetComponent<ImpMovement>().Stop();
            //deactivate input control
            //Play level completed sound
            //Update stats
            //Save level completed info
            Debug.Log("Victory");
        }
    }
}
