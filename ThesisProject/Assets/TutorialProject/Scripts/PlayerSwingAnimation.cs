using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwingAnimation : MonoBehaviour
{
    Animator animator;
    F_PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<F_PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnAttack()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Swing")) return;
        animator.SetTrigger("isAttacking");
    }
}
