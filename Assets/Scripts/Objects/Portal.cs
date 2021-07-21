using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    const string INACTIVE_ANIM_BOOL = "Inactive";
    [SerializeField] GameObject impPrefab;
    [SerializeField] float inactiveTime;
    [SerializeField] Animator animator;
    [SerializeField] int maxNumberOfImps;
    bool isActive = true;

    public void SpawnImp()
    {
        if (isActive && ImpMovement.activeImps < maxNumberOfImps)
        {
            ImpMovement.activeImps++;
            AudioManager.instance.PlaySound(AudioManager.instance.portalSound);
            animator.SetBool(INACTIVE_ANIM_BOOL, true);
            Instantiate(impPrefab, transform.position, Quaternion.identity);
            isActive = false;
            StartCoroutine(WaitToActivate());
        }
    }
    IEnumerator WaitToActivate()
    {
        yield return new WaitForSeconds(inactiveTime);
        isActive = true;
        animator.SetBool(INACTIVE_ANIM_BOOL, false);
    }
}
