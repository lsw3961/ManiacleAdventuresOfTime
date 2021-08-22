using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //basic variables
    private Rigidbody2D rb;
    public InputReader reader;
    //move variables
    private Vector2 dir = Vector2.zero;
    private Vector2 lastDirection = Vector2.zero;

    [SerializeField] private float speed = 5;

    //jump variables
    [SerializeField] private float jumpForce = 5;
    [SerializeField] private float fallMultiplier = 5;
    [SerializeField] private float lowJumpMultiplier = 5;
    [SerializeField] private float slideSpeed = 1;
    [SerializeField] private float wallJumpTime = 1;
    [SerializeField] private float xWallForce = 1;
    [SerializeField] private float yWallForce = 3;
    private bool isJumping = false;
    private bool isJumpingReleased = true;
    private bool onGround = true;
    private bool onWall = false;
    private bool wallJumping = false;
    private bool wallSliding = false;
    [SerializeField] private Vector2 bottomOffset = Vector2.zero;
    [SerializeField] private Vector2 leftOffset = Vector2.zero;
    [SerializeField] private Vector2 rightOffset = Vector2.zero;
    [SerializeField] private float overlapRadius = 2;
    [SerializeField] private LayerMask groundedLayer = 0;


    //dash variables
    [SerializeField] private float dashStartTime = 2f;
    [SerializeField] private float dashSpeed = 5f;
    private float dashTime = 0f;
    private bool isDashing = false;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    #region Enable & Disable
    private void OnEnable()
    {
        reader.MoveEvent += Move;
        reader.JumpEvent += Jump;
        reader.DashEvent += DashTrigger;


    }

    private void OnDisable()
    {
        reader.MoveEvent -= Move;
        reader.JumpEvent -= Jump;
        reader.DashEvent -= DashTrigger;

    }

    #endregion

    private void Update()
    {
        Walk(dir);
        Dash();
        IsGrounded();
        FixJump();
        DashTimeCounter();
        if (wallJumping)
        {
            Invoke("SetWallJumpingToFalse",wallJumpTime);
            rb.velocity = new Vector2(xWallForce * -lastDirection.x, yWallForce);

        }
        if (onWall && !onGround)
        {
            WallSlide();
        }

    }

    /// <summary>
    /// these methods are the movement methods and deal with how the player moves
    /// </summary>
    /// <param name="direction"></param>
    private void Move(Vector2 direction)
    {
        dir = direction;
        if (dir != Vector2.zero)
        {
            lastDirection = dir;

        }
    }
    private void Walk(Vector2 dir)
    {
        rb.velocity = (new Vector2(dir.x * speed, rb.velocity.y));
    }

    /// <summary>
    /// these methods for checking jumping, 1 to read from the input reader, 1 to release from the input reader, and 1 to do the actualy calcuations 
    /// </summary>
    private void Jump()
    {
        isJumping = true;

        if (wallSliding)
        {
            wallJumping = true;
        }
        isJumpingReleased = false;
        reader.JumpReleaseEvent += JumpReleased;

    }
    private void JumpReleased()
    {
        isJumpingReleased = true;
        reader.JumpReleaseEvent -= JumpReleased;
    }
    private void FixJump()
    {

        if (isJumping&&onGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.velocity += Vector2.up * jumpForce;
        }
            if (rb.velocity.y < 0)
            {

                rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }
            else if (rb.velocity.y > 0 && isJumpingReleased )
            {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
            isJumping = false;
        

    }
    private void IsGrounded()
    {
        if (Physics2D.OverlapCircle((Vector2)this.transform.position + bottomOffset, overlapRadius, groundedLayer))
        {
            onGround = true;
        }
        else
        {
            onGround = false;
        }

        if (Physics2D.OverlapCircle((Vector2)this.transform.position + leftOffset, overlapRadius, groundedLayer) || Physics2D.OverlapCircle((Vector2)this.transform.position + rightOffset, overlapRadius, groundedLayer))
        {
            onWall = true;
            wallSliding = true;
        }
        else
        {
            wallSliding = false;
            onWall = false;
        }
    }
    private void WallSlide()
    {
        rb.velocity = new Vector2(rb.velocity.x, -slideSpeed);
    }
    private void SetWallJumpingToFalse()
    {
        wallJumping = false;
    }

    /// <summary>
    /// these methods have to do with the dash and how the dash functions
    /// </summary>
    private void DashTrigger()
    {
        isDashing = true;
    }
    private void Dash()
    {
        if (dashTime < 0 && isDashing)
        {
            if (lastDirection.x == 0)
            {
                lastDirection.x = 1;
            }
            dashTime = dashStartTime;
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.velocity += new Vector2(lastDirection.x * dashSpeed, 0);
            isDashing = false;
        }
    }
    private void DashTimeCounter()
    {
        dashTime -= Time.deltaTime;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere((Vector2)this.transform.position + bottomOffset, overlapRadius);
        Gizmos.DrawWireSphere((Vector2)this.transform.position + leftOffset, overlapRadius);
        Gizmos.DrawWireSphere((Vector2)this.transform.position + rightOffset, overlapRadius);
    }


}
