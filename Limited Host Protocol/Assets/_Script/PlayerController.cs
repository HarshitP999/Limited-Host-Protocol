using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour, IController
{

    // public Rigidbody2D.SlideMovement SlideMovement = new Rigidbody2D.SlideMovement();


    private Rigidbody2D rb2d;
    private Animator anim;
    public Vector2 moveInput;




    public StateManager fsm;
    public float baseSpeed = 5f;

    private InputSystem_Actions inputActions;

    bool isPossessed = false;




    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();


        fsm = new StateManager();
        fsm.ChangerState(new IdlePlayer(this)); 



        inputActions = new InputSystem_Actions();
    }




    private void OnEnable()
    {
        inputActions.Enable();


        inputActions.Player.Move.performed += OnMove;
        inputActions.Player.Move.canceled += ctx => moveInput = Vector2.zero;
        inputActions.Player.Posses.performed += OnPoss;
        inputActions.Player.Unposses.performed += Unposs;

    }
    private void OnDisable()
    {
        inputActions.Player.Move.performed -= OnMove;
        inputActions.Player.Move.canceled -= ctx => moveInput = Vector2.zero;
        inputActions.Player.Posses.performed -= OnPoss;
        inputActions.Player.Unposses.performed -= Unposs;


        inputActions.Disable();

    }
    private void FixedUpdate()

    {
        UpdateAnimation();
        fsm.UpdateState();
        MovePlayer();
        UpdateController();
    }
    void UpdateAnimation()
    {
        Debug.Log("Update Animation");
    }

    void Posses() { }

    void Unpossess() { }
    void UpdateController()
    {

        fsm.UpdateState();
    }

    void MovePlayer()
    {

        Vector2 velocity = new Vector2(moveInput.x * baseSpeed, 0);
        //   rb2d.AddForce(velocity,ForceMode2D.Force);
        rb2d.MovePosition(rb2d.position + velocity * Time.fixedDeltaTime);


    }
    void OnMove(InputAction.CallbackContext context)
    {
        //  if (context.performed)
        {
            Debug.Log("Button Pressed");

            moveInput = context.ReadValue<Vector2>();

        }

    }

    void OnPoss(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (!isPossessed)
            {
                Debug.Log("OnPosses is Pressed");
                Posses();
                isPossessed = true;

            }
            else { return; }
        }

    }
    void Unposs(InputAction.CallbackContext context)
    {
        {
           
            if (context.performed)
            {
                if (isPossessed)
                {
                    Debug.Log("UnPosses is Pressed");
                    Unpossess();
                    isPossessed = false;

                }
                else
                {
                    return;
                }
              
            }
        }
    }
}
