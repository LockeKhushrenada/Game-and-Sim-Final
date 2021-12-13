using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootInDirection : GameplayComponent
{
    public GameObject bullet;
    public Vector2 direction;
    public Vector2 offset;
    public bool shootInMoveDirection = false;
    [Range(0.1f, 10)]
    float shootElapsed = 0;

    Vector2 lastShootDir;

    // Start is called before the first frame update
    void Start()
    { 
    }

    protected override void UpdateButton()
    {
        // we always need at least a little delay so that it doesn't spam bullets and crash
        shootElapsed += Time.deltaTime;

        if (Input.GetKeyDown(GetKeyFromButtonType(key)) && shootElapsed > timeBetween)
        {
            DoShoot();
            shootElapsed = 0;
        }
    }

    protected override void UpdateOneShot()
    {
        if (active && !completed)
        {
            DoShoot();
        }
    }

    protected override void UpdateConstant()
    {
        // we always need at least a little delay so that it doesn't spam bullets and crash
        shootElapsed += Time.deltaTime;
        if(shootElapsed >= timeBetween)
        {
            DoShoot();
            shootElapsed = 0;
        }
        
    }

    public override void Update()
    {
        base.Update();

        if (GetComponent<Rigidbody2D>().velocity != Vector2.zero)
        {
            lastShootDir = GetComponent<Rigidbody2D>().velocity;
            
        }
    }

    public void DoShoot()
    {
        GameObject g = Instantiate(bullet, transform.position + new Vector3(offset.x, offset.y), Quaternion.identity);

        if(g.GetComponent<Rigidbody2D>() != null)
        {
            if (shootInMoveDirection)
            {
                g.GetComponent<Rigidbody2D>().AddForce(lastShootDir * direction.magnitude, ForceMode2D.Impulse);
            }

            else
            {
                //g.GetComponent<Rigidbody2D>().velocity = direction;
                g.GetComponent<Rigidbody2D>().AddForce(direction, ForceMode2D.Impulse);
            }
        }
    }
}
