using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivableObject : MonoBehaviour
{
    const string ACTIVATED = "Activated";
    [SerializeField] Animator animator;
    [SerializeField] bool startActive;
    bool activated;

    private void Start()
    {
        if (startActive)
            ChangeState();
    }

    public void ChangeState()
    {
        animator.SetBool(ACTIVATED, !animator.GetBool(ACTIVATED));
        activated = !activated;
    }
}
