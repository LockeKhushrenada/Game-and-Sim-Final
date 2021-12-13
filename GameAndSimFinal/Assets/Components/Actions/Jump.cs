using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : GameplayComponent
{
    bool onGround = false;
    float jumpElapsed = 0;

    public int extraJumps = 1;
    int jumpsRemaining = 0;

    bool drawDebugLine = true;
    public float groundCheckDistance = 1.0f;
    public LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void DoJump()
    {

        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, speed), ForceMode2D.Impulse);
        onGround = false;
        jumpElapsed = 0;

        jumpsRemaining -= 1;
    }

    protected override void UpdateButton()
    {
        onGround = CheckForGrounded();

        jumpElapsed += Time.deltaTime;

        if (Input.GetKeyDown(GetKeyFromButtonType(key)) && onGround && active && jumpElapsed > timeBetween)
        {
            DoJump();
        }
    }

    protected override void UpdateConstant()
    {
        onGround = CheckForGrounded();

        jumpElapsed += Time.deltaTime;

        if (onGround && active && jumpElapsed > timeBetween)
            DoJump();
    }

    protected override void UpdateOneShot()
    {
        onGround = CheckForGrounded();

        if (onGround && active && !completed && jumpElapsed > timeBetween)
        {
            DoJump();
            completed = true;
        }
    }

    void OnCollisionStay2D()
    {
        //onGround = true;
    }

    bool CheckForGrounded()
    {

        if (jumpsRemaining > 0)
            return true;

        if (drawDebugLine)
            Debug.DrawLine(transform.position, transform.position + Vector3.down * groundCheckDistance);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);
        if (hit.collider != null)
        {
            jumpsRemaining = extraJumps;
            return true;
        }

        return false;
    }

}
