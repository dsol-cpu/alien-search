using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour,PlayerInput.IPlayerActions
{
    Rigidbody rb;
    Transform cameraObject;

    [Header("Movement")]
    Vector2 movementInput;
    Vector2 cameraInput;
    PlayerInput playerInput;
    bool sprinting;
    private float moveAmount;
    [SerializeField] private float sprintingSpeed = 7f;
    [SerializeField] private float runningSpeed = 5f;
    [SerializeField] private float walkingSpeed = 3f;

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

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float hCurrent = movementInput.x;
        float vCurrent = movementInput.y;

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
        //print(movement);
    }

    public void OnLooking(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        cameraInput = context.ReadValue<Vector2>();
    }

    public void OnMove(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
        print("moving"); 
    }

    public void OnSprint(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        sprinting = context.action.triggered;
        print("sprinting");
    }
}
