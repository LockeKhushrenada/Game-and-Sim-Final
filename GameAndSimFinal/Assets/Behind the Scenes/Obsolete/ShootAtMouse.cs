using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAtMouse : GameplayComponent
{
    public GameObject bullet;
    public Vector3 offset;
    float shootElapsed = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    protected override void UpdateButton()
    {
        // we always need at least a little delay so that it doesn't spam bullets and crash
        shootElapsed += Time.deltaTime;

        if (Input.GetButton("Fire1") && shootElapsed > timeBetween)
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
        if (shootElapsed >= timeBetween)
        {
            DoShoot();
            shootElapsed = 0;
        }

    }

    void DoShoot()
    {
        GameObject g = Instantiate(bullet, transform.position + offset, Quaternion.identity);

        var dir = (transform.position + offset) - new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z);
        dir.Normalize();
        dir *= -1;

        if (g.GetComponent<Rigidbody2D>() != null)
        {
            g.GetComponent<Rigidbody2D>().velocity = dir * 2;
            //g.GetComponent<Rigidbody2D>().AddForce(dir, ForceMode2D.Impulse);
        }
    }
}
