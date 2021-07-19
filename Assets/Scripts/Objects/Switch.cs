using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    const string ACTIVATED = "Activated";
    [SerializeField] ActivableObject[] objectsToSwitch;
    //[SerializeField] float lockedTime;
    [SerializeField] LayerMask impsLayers;
    [SerializeField] Animator animator;
    //bool locked;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((((1 << other.gameObject.layer) & impsLayers) != 0) && !other.isTrigger) //!locked && 
        {
            //locked = true;
            //StartCoroutine(Unlock());
            animator.SetBool(ACTIVATED, !animator.GetBool(ACTIVATED));
            for (int i = 0; i < objectsToSwitch.Length; i++)
            {
                objectsToSwitch[i].ChangeState();
            }
        }
    }
    /*IEnumerator Unlock()
    {
        yield return new WaitForSeconds(lockedTime);
        locked = false;
    }*/
}
