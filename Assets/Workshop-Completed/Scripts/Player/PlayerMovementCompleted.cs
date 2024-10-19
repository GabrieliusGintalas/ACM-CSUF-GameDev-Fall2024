using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;

public class PlayerMovementCompleted : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
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
        
        if(Input.GetKey(KeyCode.A)){
            anim.SetBool("isRunning", true);
            moveDirection = -1;
        } else if(Input.GetKey(KeyCode.D)){
            anim.SetBool("isRunning", true);
            moveDirection = 1;
        } else {
            anim.SetBool("isRunning", false);
            moveDirection = 0;
        }


        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
            Jump();
        }
    }

    void FixedUpdate(){
        rb.velocity = new Vector2(PlayerStatsCompleted.inst.GetPlayerMoveSpeed() * moveDirection, rb.velocity.y);
    }

    public void Jump(){
        anim.SetTrigger("jumping");
        rb.velocity = new Vector2(rb.velocity.x, PlayerStatsCompleted.inst.GetPlayerJumpForce());
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
