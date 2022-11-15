using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneController : MonoBehaviour
{
     public Animator animator;
    public void Activate() {
        animator.SetBool("Active", true);
    }

    public void Deactivate() {
        animator.SetBool("Active", false);
    }
}
