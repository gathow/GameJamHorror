 using UnityEngine;
using UnityEngine.InputSystem;

                public class PlayerMovement : MonoBehaviour
                {
                    public float playerSpeed = 5.0f;
                    public float jumpHeight = 1.5f;
                    public float gravityValue = -9.81f;
                    public float sprintMultiplier = 1.5f;
                    public GameObject Camera;
                    public GameObject Model;
                    private CharacterController controller;
                    private Vector3 playerVelocity;
                    private bool groundedPlayer;

                    [Header("Input Actions")]
                    public InputActionReference moveAction; 
                    public InputActionReference jumpAction;
                    public InputActionReference sprintAction;
                    private void Awake()
                    {
                        controller = gameObject.GetComponent<CharacterController>();
                    }

                    private void OnEnable()
                    {
                        moveAction.action.Enable();
                        jumpAction.action.Enable();
                        sprintAction.action.Enable();
                    }

                    private void OnDisable()
                    {
                        moveAction.action.Disable();
                        jumpAction.action.Disable();
                        sprintAction.action.Disable();
                    }

                    void Update()
                    {
                        groundedPlayer = controller.isGrounded;
                        if (groundedPlayer && playerVelocity.y < 0)
                        {
                            playerVelocity.y = 0f;
                        }
                        bool sprinting = sprintAction.action.IsPressed();
                        float currentSpeed = playerSpeed * (sprinting ? sprintMultiplier : 1f);
                        Vector2 input = moveAction.action.ReadValue<Vector2>();
                        Vector3 inputMove = new Vector3(input.x, 0, input.y);
                        inputMove = Vector3.ClampMagnitude(inputMove, 1f);
                        Quaternion pitchRotation = Quaternion.Euler(Model.transform.eulerAngles.x, 0f, 0f);
                        Quaternion yawRotation = Quaternion.Euler(0f, Camera.transform.eulerAngles.y, 0f);
                        Vector3 move = yawRotation * inputMove;
                        
                        
                        if (move.sqrMagnitude > 0.001f)
                        {    
                        Model.transform.forward = new Vector3(move.x, 0f, move.z).normalized;
                        } 
                        if (jumpAction.action.triggered && groundedPlayer)
                        {
                            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
                        }
                        
                        playerVelocity.y += gravityValue * Time.deltaTime;

                        Vector3 finalMove = (move * currentSpeed) + (playerVelocity.y * Vector3.up);
                        controller.Move(finalMove * Time.deltaTime);
                    }
                    void FixedUpdate()
    {
        Vector3 rotation = Camera.transform.eulerAngles;
        Vector3 Mrotation = Model.transform.eulerAngles;
        Model.transform.eulerAngles = new Vector3(rotation.x, Mrotation.y, Mrotation.z);
    }
                }