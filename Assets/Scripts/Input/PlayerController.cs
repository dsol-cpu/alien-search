using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, PlayerInput.IPlayerActions
{
    [Header("Camera")]
    Rigidbody rb;
    Transform cameraObject;
    Vector2 zoomInput;
    Vector2 delta;

    [Header("Input Flags")]
    [SerializeField] private bool sprinting;
    [SerializeField] private bool interacting;

    [Header("Movement")]
    Vector2 movementInput;
    PlayerInput playerInput;
    private float moveAmount;
    float hCurrent, vCurrent;

    [SerializeField] private float sprintingSpeed = 15f;
    [SerializeField] private float runningSpeed = 7f;
    [SerializeField] private float walkingSpeed = 5f;
    [SerializeField] private float rotationSpeed = 2f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cameraObject = Camera.main.transform;
    }

    private void OnEnable()
    {
        if (playerInput == null)
        {
            playerInput = new PlayerInput();
            playerInput.Player.Move.performed += ctx => OnMove(ctx);
            playerInput.Player.Move.canceled += ctx => OnMove(ctx);

            playerInput.Player.Sprint.performed += ctx => OnSprint(ctx);
            playerInput.Player.Sprint.canceled += ctx => OnSprint(ctx);
        }
        playerInput.Player.Enable();
    }
    private void OnDisable()
    {
        playerInput.Player.Disable();
    }

    void Start()
    {

    }
    private void Movement()
    {
        hCurrent = movementInput.x;
        vCurrent = movementInput.y;

        moveAmount = Mathf.Clamp01(Mathf.Abs(hCurrent) + Mathf.Abs(vCurrent));

        Vector3 movement = new Vector3(hCurrent, 0, vCurrent) * Time.deltaTime;

        movement = cameraObject.TransformDirection(movement);
        movement.y = 0;
        movement.Normalize();

        if (sprinting)
        {
            movement *= sprintingSpeed;
        }
        else
        {
            if (moveAmount >= 0.5f)
            {
                movement *= runningSpeed;
            }
            else
            {
                movement *= walkingSpeed;
            }
        }

        rb.velocity = movement;
        if(movement != Vector3.zero)
            Rotation();
    }

    private void Rotation()
    {
        Vector3 targetDirection = cameraObject.forward * vCurrent + cameraObject.right * hCurrent;
        targetDirection.Normalize();
        targetDirection.y = 0;
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        if (movementInput.x != 0 || movementInput.y != 0)
            transform.rotation = playerRotation;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        sprinting = context.action.triggered;
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        interacting = context.action.triggered;
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        delta = context.ReadValue<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
}