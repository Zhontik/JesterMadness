using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;

    public Camera playerCamera;
    public float cameraRotationLimit = 80.0f;
    public float sensitivityY = 1.0f;
    public float sensitivityX = 1.0f;
    public float movementSpeed = 4.0f;

    float gravity = 10;
    Vector3 velocity = Vector3.zero;
    float rotationX = 0;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        //Direction = transform.forward;

        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    void rotateCamera()
    {
        rotationX += -Input.GetAxis("Mouse Y") * sensitivityY;
        rotationX = Mathf.Clamp(rotationX, -cameraRotationLimit, cameraRotationLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
    }

    void OnGUI()
    {
        GUI.color = Color.yellow; //цвет надписи на Боксе
        //GUI.Box(new Rect(0, 10, 120, 30), "ground: " + characterController.isGrounded);
        GUI.Box(new Rect(0, 40, 120, 30), "velocity: " + velocity.magnitude);
    }

    void Update()
    {
        if(characterController.isGrounded)
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);
            float curSpeedX = Input.GetAxis("Vertical") * movementSpeed;
            float curSpeedY = Input.GetAxis("Horizontal") * movementSpeed;

            velocity = Vector3.ClampMagnitude(((forward * curSpeedX) + (right * curSpeedY)), movementSpeed);

            if (Input.GetButton("Jump"))
            {
                velocity.y = movementSpeed;
            }
        }
        else
            velocity.y -= gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);

        rotateCamera();
    }
}
