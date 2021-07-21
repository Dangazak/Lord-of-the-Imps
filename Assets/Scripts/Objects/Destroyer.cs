using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] LayerMask impsLayers;
    public enum DeathType { fall, crush, spike }
    public DeathType selectedDeath = DeathType.fall;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((((1 << other.gameObject.layer) & impsLayers) != 0) && !other.isTrigger)
        {
            ImpMovement.activeImps--;
            Destroy(other.gameObject);
            if (selectedDeath == DeathType.fall)
            {
                AudioManager.instance.PlaySound(AudioManager.instance.fallDeathSound);
            }
            else if (selectedDeath == DeathType.spike)
            {
                AudioManager.instance.PlaySound(AudioManager.instance.spikeDeathSound);
            }
            else if (selectedDeath == DeathType.crush)
            {
                AudioManager.instance.PlaySound(AudioManager.instance.crushDeathSound);
            }

        }
    }
}
