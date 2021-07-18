using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpAnimationManager : MonoBehaviour
{
    const string JUMPING = "Jumping", GROUNDED = "Grounded";
    [SerializeField] Animator animator;

    public void SetGrounded(bool state)
    {
        animator.SetBool(GROUNDED, state);
    }
    public void SetJumping(bool state)
    {
        animator.SetBool(JUMPING, state);
    }
}
