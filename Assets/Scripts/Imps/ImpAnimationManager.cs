using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpAnimationManager : MonoBehaviour
{
    const string JUMPING = "Jumping", GROUNDED = "Grounded", STOPPED = "Stopped";
    [SerializeField] Animator animator;

    public void SetGrounded(bool state)
    {
        animator.SetBool(GROUNDED, state);
    }
    public void SetJumping(bool state)
    {
        animator.SetBool(JUMPING, state);
    }
    public void SetStopped(bool state)
    {
        animator.SetBool(STOPPED, state);
    }
    public void SelectGroundedAnimation(ImpMovement.State impState)
    {
        SetGrounded(true);
        if (impState == ImpMovement.State.walking)
        {
            SetStopped(false);
        }
        else if (impState == ImpMovement.State.stopped)
        {
            SetStopped(true);
        }
    }
}
