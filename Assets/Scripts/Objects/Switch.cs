using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Switches the activated state of an array of objects when an imp enters this objects trigger collider
public class Switch : MonoBehaviour
{
    const string ACTIVATED = "Activated";
    [SerializeField] ActivableObject[] objectsToSwitch;
    [SerializeField] LayerMask impsLayers;
    [SerializeField] Animator animator;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((((1 << other.gameObject.layer) & impsLayers) != 0) && !other.isTrigger) //!locked && 
        {
            animator.SetBool(ACTIVATED, !animator.GetBool(ACTIVATED));
            if (animator.GetBool(ACTIVATED))
                AudioManager.instance.PlaySound(AudioManager.instance.openDoorSound);
            else
                AudioManager.instance.PlaySound(AudioManager.instance.closeDoorSound);
            for (int i = 0; i < objectsToSwitch.Length; i++)
            {
                objectsToSwitch[i].ChangeState();
            }
        }
    }
}
