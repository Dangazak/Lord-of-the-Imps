using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpFlipper : MonoBehaviour
{
    [SerializeField] ImpMovement imp;
    [SerializeField] LayerMask colisionableObjects;
    [SerializeField] float raycastLenght = 0.05f;
    Ray ray;
    Vector2 direction;
    RaycastHit2D hitInfo;
    RaycastHit2D[] hitsInfo;

    private void Update()
    {
        if (imp.flipped)
            direction = -transform.right;
        else
            direction = transform.right;

        if (imp.currentState == ImpMovement.State.walking)
            RayCastCheck();

        //Debug.DrawRay(transform.position, transform.right * 0.05f, Color.red);
    }
    private void FlipImp()
    {
        AudioManager.instance.PlaySound(AudioManager.instance.turnSound);
        imp.flipped = !imp.flipped;
        imp.Move(!imp.flipped);
    }
    private void RayCastCheck()
    {
        hitsInfo = Physics2D.RaycastAll(transform.position, direction, raycastLenght, colisionableObjects);
        //hitInfo = Physics2D.Raycast(transform.position, direction, raycastLenght, colisionableObjects);
        //if (hitInfo) && hitInfo.collider != transform.parent.gameObject.GetComponent<CircleCollider2D>())
        for (int i = 0; i < hitsInfo.Length; i++)
        {
            if (!hitsInfo[i].collider.isTrigger && imp.currentState == ImpMovement.State.walking)
                FlipImp();
        }
    }
}
