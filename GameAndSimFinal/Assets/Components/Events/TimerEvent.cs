using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimerEvent : MonoBehaviour
{
    public bool active = true;
    public float timeInSeconds = 0;
    public UnityEvent onTimerComplete;
    public bool repeat = false;

    float elapsed = 0;
    bool complete = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!active)
            return;

        if (complete)
            return;

        elapsed += Time.deltaTime;

        if(elapsed >= timeInSeconds)
        {
            onTimerComplete.Invoke();

            if (!repeat)
                complete = true;

            timeInSeconds = 0;
        }
    }

    public void SetActive(bool setActive)
    {
        active = setActive;
    }
}
