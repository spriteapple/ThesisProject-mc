using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    int mouseSensitivity = 5;
    [SerializeField] public Camera playerCamera;
    [SerializeField] public Transform playerCameraTransform;
    [SerializeField] public Camera playerCamera3rdPerson;
    [SerializeField] public Transform playerCamera3rdPersonTransform;
    float xRotation;
    float yRotation;
    float mouseX, mouseY;
    bool firstPerson = true;


    void Start()
    {
        // Locks the cursor to the center of the screen and hides it
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Scaling mouse movement by deltaTime and sensitivity
        mouseX *= Time.deltaTime * mouseSensitivity;
        mouseY *= Time.deltaTime * mouseSensitivity;

        // Adjusting yRotation based on mouseX movement
        yRotation += mouseX;

        // Adjusting xRotation based on mouseY movement, and clamping it within a range
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -35f, 40f);

        // Applying rotation to the player object (for left and right rotation)
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);

        // Applying rotation to the player's camera (Both vertical and horizontal rotation)
            playerCameraTransform.rotation = Quaternion.Euler(xRotation, yRotation, 0);




    }

    // This method is invoked when the player moves the mouse
    private void OnLook(InputValue input)
    {
        // Getting mouse input values
        mouseX = input.Get<Vector2>().x;
        mouseY = input.Get<Vector2>().y;
    }

    private void OnChangeCamera(InputValue input)
    {
        if (firstPerson)
        {
            playerCamera3rdPerson.enabled = true;
            playerCamera.enabled = false;
            firstPerson = false;
        }
        else if (!firstPerson)
        {
            playerCamera.enabled = true;
            playerCamera3rdPerson.enabled = false;
            firstPerson= true;
        }
    }
}
