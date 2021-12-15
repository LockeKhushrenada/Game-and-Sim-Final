using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlatformMovement : MonoBehaviour
{
    private Vector3 startPosition;
    private float elapsedTime;
    private float originalSpeed;
    private float slowedSpeed = 2;
    private float timePassed = 0;
    [SerializeField]
    private float loopSpeed = 1;
    [SerializeField]
    private float speed = 0.1f;
    [SerializeField]
    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        originalSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        float percentageComplete = elapsedTime / speed;

        transform.position = Vector3.Lerp(startPosition, target.position, Mathf.PingPong(percentageComplete, loopSpeed));

        if(Keyboard.current.eKey.isPressed)
        {
            speed = slowedSpeed;
            Timer myTimer1 = new Timer(10f, ClockOver);
            TimerManager.instance.timers.Add(myTimer1);

        }
    }

    void ClockOver()
    {
        speed = originalSpeed;
    }
}
