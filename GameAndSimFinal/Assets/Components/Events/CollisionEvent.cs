using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionEvent : MonoBehaviour
{
    public enum CollisionType
    {
        Touch,
        Stay,
        Exit
    }

    public CollisionType collisionType;

    public string targetName = "";
    public string targetTag = "";
    public bool useTrigger = false;
    public UnityEvent onCollision;
    public bool oneShot = false;

    bool completed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (oneShot && completed)
            return;

        if (useTrigger)
            return;

        if(collisionType != CollisionType.Touch)
            return;

        onCollision.Invoke();

        completed = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (oneShot && completed)
            return;

        if (useTrigger)
            return;

        if (collisionType != CollisionType.Exit)
            return;

        onCollision.Invoke();

        completed = true;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (oneShot && completed)
            return;

        if (useTrigger)
            return;

        if (collisionType != CollisionType.Stay)
            return;

        onCollision.Invoke();

        completed = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (oneShot && completed)
            return;

        if (!useTrigger)
            return;

        if (collisionType != CollisionType.Touch)
            return;

        onCollision.Invoke();

        completed = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (oneShot && completed)
            return;

        if (!useTrigger)
            return;

        if (collisionType != CollisionType.Exit)
            return;

        onCollision.Invoke();

        completed = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (oneShot && completed)
            return;

        if (!useTrigger)
            return;

        if (collisionType != CollisionType.Stay)
            return;

        onCollision.Invoke();

        completed = true;
    }
}
