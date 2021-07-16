using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpFlipper : MonoBehaviour
{
    [SerializeField] ImpMovement imp;
    [SerializeField] LayerMask colisionableObjects;
    Ray ray;
    Vector2 direction;

    private void Update()
    {
        if (imp.flipped)
            direction = -transform.right;
        else
            direction = transform.right;

        if (Physics2D.Raycast(transform.position, direction, 0.05f, colisionableObjects))
            FlipImp();
        //Debug.DrawRay(transform.position, transform.right * 0.05f, Color.red);
    }
    private void FlipImp()
    {
        imp.flipped = !imp.flipped;
        imp.Move(!imp.flipped);
    }
}
