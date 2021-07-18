using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    const string INACTIVE_ANIM_BOOL = "Inactive";
    [SerializeField] GameObject impPrefab;
    [SerializeField] float inactiveTime;
    [SerializeField] Animator animator;
    bool isActive = true;

    public void SpawnImp()
    {
        if (isActive)
        {
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
