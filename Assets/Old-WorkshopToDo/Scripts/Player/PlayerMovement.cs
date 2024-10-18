using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpStrength = 5f;
    private float originalScale;
    private float moveDirection;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private bool isGrounded;
    

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        originalScale = transform.localScale.x;
    }
    
    void Update()
    {
        CheckSpriteFlip();
        CheckIfGrounded();
        //TODO: Check for user input to move player left or right
        //Hint: Use Input.GetKey(...)
        /*
        
        if(...){
            anim.SetBool("isRunning", true);
            moveDirection = -1;
        } else if(...){
            anim.SetBool("isRunning", true);
            moveDirection = 1;
        } else {
            anim.SetBool("isRunning", false);
            moveDirection = 0;
        }
        */


        //TODO: Check for user input to make player jump + logic for when player should be able to jump
        //Hint: Use Input.GetKey(...)
        /*
        
        if(...){
            Jump();
        }
        */     

        //CHALLENGE 1: Can you add a double jump mechanic?
        //Challenge 2: Can you make a sprint mechanic that increases player movement when holding a key?
    }

    void FixedUpdate(){
        rb.velocity = new Vector2(moveSpeed * moveDirection, rb.velocity.y);
    }

    public void Jump(){
        anim.SetTrigger("jumping");
        rb.velocity = new Vector2(rb.velocity.x, jumpStrength);
    }

    public void CheckSpriteFlip(){
        if(rb.velocity.x > 0){
            transform.localScale = new Vector3(originalScale, originalScale, originalScale);
        } else if(rb.velocity.x < 0){
            transform.localScale = new Vector3(-originalScale, originalScale, originalScale);
        }
    }

    public void CheckIfGrounded(){
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        anim.SetBool("isGrounded", isGrounded);
    }
}
