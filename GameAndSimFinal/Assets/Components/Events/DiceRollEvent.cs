using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DiceRollEvent : MonoBehaviour
{
    public int sides = 6;
    public bool activateOnStart = false;
    public bool repeat = false;
    public float repeatHowOften = 0;

    public UnityEvent onSuccessfulRoll;
    public UnityEvent onFailedRoll;

    float elapsed = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(activateOnStart)
        {
            Roll();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(repeat)
        {
            elapsed += Time.deltaTime;
            if(elapsed >= repeatHowOften)
            {
                Roll();
                elapsed = 0;
            }
        }
    }

    public void Roll()
    {
        int roll = Random.Range(0, sides) + 1;

        if(roll == sides)
        {
            if (onSuccessfulRoll != null)
                onSuccessfulRoll.Invoke();
        }

        else
        {
            if (onFailedRoll != null)
                onFailedRoll.Invoke();
        }
    }
}
