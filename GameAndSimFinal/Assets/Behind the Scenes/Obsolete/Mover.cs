using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : GameplayComponent
{
    public enum Direction
    {
        x,
        y
    }

    public Direction direction;

    public bool flipXBasedOnSpeed = false;
    public bool flipYBasedOnSpeed = false;
    public bool rotateBasedOnSpeed = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void Update()
    {
        base.Update();

        if(GetComponent<SpriteRenderer>() != null)
        {
            if(flipXBasedOnSpeed)
            {
                if(GetComponent<Rigidbody2D>().velocity.x > 0)
                {
                    GetComponent<SpriteRenderer>().flipX = false;
                }
                else if (GetComponent<Rigidbody2D>().velocity.x > 0)
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                }
            }

            if(flipYBasedOnSpeed)
            {
                if (GetComponent<Rigidbody2D>().velocity.y > 0)
                {
                    GetComponent<SpriteRenderer>().flipY = false;
                }
                else if (GetComponent<Rigidbody2D>().velocity.y > 0)
                {
                    GetComponent<SpriteRenderer>().flipY = true;
                }
            }

            if(rotateBasedOnSpeed)
            {
                if(GetComponent<Rigidbody2D>().velocity != Vector2.zero)
                {
                    float angle = Mathf.Atan2(GetComponent<Rigidbody2D>().velocity.y, GetComponent<Rigidbody2D>().velocity.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
                }
                
            }
        }
    }


    protected override void UpdateButton()
    {
        float i = 0;
        switch(direction)
        {
            case Direction.x:
                i = Input.GetAxis("Horizontal");
                break;
            case Direction.y:
                i = Input.GetAxis("Vertical");
                break;
        }

        ApplyVelocity(i);
    }

    protected override void UpdateOneShot()
    {
        if(active && !completed)
        {
            switch (direction)
            {
                case Direction.x:
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(speed, 0), ForceMode2D.Impulse);
                    break;
                case Direction.y:
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0, speed));
                    break;
            }

            completed = true;
            
        }
    }

    protected override void UpdateConstant()
    {
        ApplyVelocity(1);
    }

    void ApplyVelocity(float mult)
    {
        switch(direction)
        {
            case Direction.x:
                GetComponent<Rigidbody2D>().velocity = new Vector2(speed * mult, GetComponent<Rigidbody2D>().velocity.y);
                break;
            case Direction.y:
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, speed * mult);
                break;
        }
    }
}
