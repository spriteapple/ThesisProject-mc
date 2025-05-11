using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSwingAnimation : MonoBehaviour
{
    private Animator animator; //Animator to turn on animations
    private PlayerMovement playerMovement;
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>(); // Getting the Rigidbody component attached to the character
        animator = GetComponent<Animator>();
    }

    private void OnAttack(InputValue input)
    {
        if (animator != null && playerMovement.movementVector == Vector3.zero && !animator.GetCurrentAnimatorStateInfo(0).IsName("Swing"))
        {
            animator.SetTrigger("IsSwinging");
        }
    }
}
