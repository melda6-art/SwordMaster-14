using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering; //To use the new InputSystem

public class Test : MonoBehaviour
{
    float horizontalInput;
    public string playerName = "Melda";
    public float playerHealth = 100f;
    public float jumpPower = 5f;
    
    public GameInput inputActions;  //Declaration
    public InputAction moveAction;
    public float movementSpeed = 6f;
    
    bool isFacingRight = false;
    Animator animator;
    
    public Vector2 moveInput;

    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); //So that the player has a body
        inputActions = new GameInput();
        moveAction = inputActions.Player.Move;  //With the dot you move forwards and access "move"
    }

    private Rigidbody2D rb;  //Declaration
    

    private void OnEnable()
    {
        inputActions.Enable();
        moveAction.performed += Move;
        moveAction.canceled += Move;
        //sub - positiv when key is pressed 
    }
        

    private void FixedUpdate()  //every frame
    {
        // Aufgabe: greife auf den Variablentyp Velocity vom RB2D zu und übernehme den Wert des Move Inputs
        rb.velocity = moveInput * movementSpeed;
        rb.velocity = new Vector2(moveInput.x * movementSpeed, rb.velocity.y);
        // Aufgabe: Bei der x-Achse soll Unity die Daten aus dem Input nutzen
        
        // "* movementSpeed" to be able to move
        animator.SetFloat("xVelocity", Math.Abs(rb.velocity.x));
        animator.SetFloat("yVelocity", rb.velocity.y);
    }

    private void OnDisable()
    {
        inputActions.Enable();
        moveAction.performed -= Move;
        moveAction.canceled -= Move;
        //unsub - negativ when key is not pressed
    }

    private void Move(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();  //we save wasd and the vectors 
    }

    float CheckHealth()
    {
        return playerHealth; 
    }
    
    public void GetDamagge(int dmg)  //My own method
    {
        playerHealth -= dmg;
        Debug.Log(CheckHealth());
    }

    bool IsPlayerDead()  //My own method
    {
        if (playerHealth < 1)
        {
            return true;
        }
        return false;
    }

    private void Jump(InputAction.CallbackContext ctx)
    {
        rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    }

    private void Update()
    {
       horizontalInput = Input.GetAxis("Horizontal");
        FlipSprite();
    }

    void FlipSprite()
    {
        if (isFacingRight && horizontalInput < 0f || !isFacingRight && horizontalInput > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 Is = transform.localScale;
            Is.x *= -1f;
            transform.localScale = Is;
        }
    }
}
