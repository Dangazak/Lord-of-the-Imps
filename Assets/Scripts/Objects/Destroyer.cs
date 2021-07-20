using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] LayerMask impsLayers;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((((1 << other.gameObject.layer) & impsLayers) != 0) && !other.isTrigger)
        {
            Destroy(other.gameObject);
            AudioManager.instance.PlaySound(AudioManager.instance.fallDeathSound);
        }
    }
}
