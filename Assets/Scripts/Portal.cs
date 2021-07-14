using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] GameObject impPrefab;
    [SerializeField] float inactiveTime;
    bool isActive = true;

    public void SpawnImp()
    {
        if (isActive)
        {
            Instantiate(impPrefab, transform.position, Quaternion.identity);
            isActive = false;
            StartCoroutine(WaitToActivate());
        }
    }
    IEnumerator WaitToActivate()
    {
        yield return new WaitForSeconds(inactiveTime);
        isActive = true;
    }
}
