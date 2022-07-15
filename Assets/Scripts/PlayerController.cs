using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //1) add float speed, jumpForce, moveInput; pr Rigidbody2D rb
    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;

    //4) flipping
    private bool facingRight = true;


    //5) Jumping
    private bool isGrounded;
    //creates a check to see if it is on the ground
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    bool jumpRequest;

    //5.2) Jumps
    private int extraJumps;
    public int extraJumpsValue;

    //6) Dash
    public float dashSpeed;
    public float startDashTime;

    private float dashTime;
    private int direction;

    void Start()//2) attach rigidbody to get compenent
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();

        //6) Dash
        dashTime = startDashTime;
    }

    void FixedUpdate()
    {
        //5 created the check here, and see if active
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (jumpRequest)
        {
            rb.velocity = Vector2.up * jumpForce;
            //rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            jumpRequest = false;
        }

        //4
        if(facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    void Update()
    {
        //3)add horizontal adds based on arrow/wasd left = -1; right = 1; getaxisRAW is more snappy
        moveInput = Input.GetAxis("Horizontal"); 
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        //5.2 Jumps DO THIS SECOND; REsets Jumps
        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }

        //5.2 Jumps DO THIS FIRST
        if (Input.GetButtonDown("Jump") && extraJumps > 0)
        {
            //Allows for jump in fixed update
            jumpRequest = true;
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        //6) Dash
        if (direction == 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (transform.localScale.x == -1)//moveInput < 0)
                {
                    direction = 1;
                }
                else if (transform.localScale.x == 1)//moveInput > 0)
                {
                    direction = 2;
                }
            }
        }
        else
        {
            if (dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
            }
            else
            {
                dashTime -= Time.deltaTime;

                if (direction == 1)
                {
                    rb.velocity = Vector2.left * dashSpeed;
                }
                else if (direction == 2)
                {
                    rb.velocity = Vector2.right * dashSpeed;
                }
            }
        }
    }

    //4)
    void Flip()
    {
        //following code changes the scale and inverts it, thus inverting the sprite
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
 
    void OnCollisionEnter2D (Collision2D other)
     {
         var magnitude = 2500;
 
         Vector2 force = transform.position - other.transform.position;

         Debug.Log(force);
 
         //force.Normalize ();
         rb.AddForce(-force * magnitude);


     }
}
