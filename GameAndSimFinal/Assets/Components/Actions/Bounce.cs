using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public bool active = true;

    public bool x = false;
    public bool y = false;

    Vector2 prevVelocity;
    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        prevVelocity = rb.velocity;
    }

    public void DoBounce()
    {
        // save velocity at impact
        Vector2 savedVelocity = prevVelocity;

        Vector2 newVelocity = Vector3.zero;

        if (x)
        {
            newVelocity = new Vector2(savedVelocity.x * -1, savedVelocity.y);
        }

        if(y)
        {
            newVelocity = new Vector2(savedVelocity.x , savedVelocity.y * -1);
            //rb.transform.position = new Vector3(rb.transform.position.x, rb.transform.position.y - Mathf.Sign(rb.velocity.y)*0.1f);
        }
        
        rb.velocity = newVelocity;
    }

    public void SetActive(bool setActive)
    {
        active = setActive;
    }
}
