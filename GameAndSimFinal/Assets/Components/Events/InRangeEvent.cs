using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InRangeEvent : MonoBehaviour
{
    public bool active = true;
    public Transform target;
    public float range = 0;
    public UnityEvent ifInRange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if(Vector2.Distance(transform.position, target.position) <= range )
        {
            ifInRange.Invoke();
        }
    }

    public void SetActive(bool setActive)
    {
        active = setActive;
    }
}
