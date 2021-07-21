using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Flips the imp when it collides with an obstacle
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
        for (int i = 0; i < hitsInfo.Length; i++)
        {
            if (!hitsInfo[i].collider.isTrigger && imp.currentState == ImpMovement.State.walking)
                FlipImp();
        }
    }
}
