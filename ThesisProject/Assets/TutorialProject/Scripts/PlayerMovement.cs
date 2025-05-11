using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody characterRB;
    Vector3 movementInput;
    public Vector3 movementVector;
    [SerializeField] float movementSpeed;
    [SerializeField] Animator animator;
    public bool isCrouching = false;
    public bool isSprinting = false;
    float jumpTimer = 1;
    int jumpCooldown = 1;
    void Start()
    {
        characterRB = GetComponent<Rigidbody>();
        characterRB.velocity = new Vector3(0, -10, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (movementInput != Vector3.zero)
        {
            // Calculate movement vector based on input and current orientation of the character
            movementVector = transform.right * movementInput.x + transform.forward * movementInput.z;

                movementVector.y = 0; //since we are rotating the entire game object we only want to calculate the movement vector along the x and z axis (ignore the vertical component of movement)

            

            if(isCrouching)
            {
                movementVector = movementVector / 2;
            }
            if (isSprinting)
            {
                movementVector = movementVector * 2;
            }

        }

        // Set the velocity of the character's Rigidbody to move it
        characterRB.velocity = (movementVector * Time.fixedDeltaTime * movementSpeed);
        if(characterRB.velocity.y > -5)
        {
           characterRB.AddForce(new Vector3(0, -300, 0));
        }
 
        jumpTimer += Time.fixedDeltaTime;
    }

    private void OnMovement(InputValue input)
    {

        movementInput = new Vector3(input.Get<Vector2>().x, 0, input.Get<Vector2>().y);
        animator.SetBool("IsMoving", true);

    }

    private void OnMovementStop(InputValue input)
    {
        movementVector = Vector3.zero;
        animator.SetBool("IsMoving", false);
    }

    private void OnJump(InputValue input)
    {
        if(jumpTimer >= jumpCooldown)
        {
            characterRB.AddForce(Vector3.up * 10000, ForceMode.Force);
            jumpTimer = 0;
            Debug.Log("Jump");
        }
        
    }

    private void OnCrouch(InputValue input)
    {
        
        isCrouching = true;

    }

    private void OnCrouchStop(InputValue input)
    {
        isCrouching = false;

    }

    private void OnSprint(InputValue input)
    {

        isSprinting = true;

    }

    private void OnSprintStop(InputValue input)
    {
        isSprinting = false;

    }
}
