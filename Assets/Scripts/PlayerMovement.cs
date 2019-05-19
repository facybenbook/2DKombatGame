using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed; //Horizontal speed
    public float jumpForce; //Jump force of player
    private float moveInput; //Move Inpute

    public SpriteRenderer sr;
    Rigidbody2D rb;

    private bool isGrounded; //Either true or false
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Jump logic
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
 
        //Horizontal movements (left & right)
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2((moveInput * speed) * Time.deltaTime, rb.velocity.y);

        if(moveInput > 0){
            sr.flipX = false;
        }
        else if (moveInput < 0)
        {
            sr.flipX = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }
}
