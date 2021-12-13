using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public enum Target
    {
        Player,
        Enemy
    }

    public Target target;

    public bool destroyOnContact = true;
    public int damageAmount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(target)
        {
            case Target.Player:
                if(collision.GetComponent<Player>() != null)
                {
                    if (collision.GetComponent<Health>() != null)
                        collision.GetComponent<Health>().TakeDamage(damageAmount);

                    if(destroyOnContact)
                        Destroy(gameObject);
                }
                break;
            case Target.Enemy:
                if(collision.GetComponent<Enemy>() != null)
                {
                    if (collision.GetComponent<Health>() != null)
                        collision.GetComponent<Health>().TakeDamage(damageAmount);

                    if (destroyOnContact)
                        Destroy(gameObject);
                }
                break;
        }
    }
}
