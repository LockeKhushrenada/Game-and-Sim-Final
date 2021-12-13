using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 100;

    public UnityEvent whenOutOfHealth;

    bool activated = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int amount)
    {
        if(currentHealth > 0)
            currentHealth -= amount;

        if (currentHealth < 0)
            currentHealth = 0;

        if (currentHealth == 0 && whenOutOfHealth != null && !activated)
        {
            whenOutOfHealth.Invoke();
            activated = true;
        }
    }

    public void SetMaxHealth(int amount)
    {
        maxHealth = amount;
    }

    public void SetCurrentHealth(int amount)
    {
        currentHealth = amount;
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
    }
}
