using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lock : MonoBehaviour
{
    public string code = "abc123";

    public UnityEvent onUnlock;
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
        if (collision.GetComponent<Key>() != null)
        {
            if (collision.GetComponent<Key>().code == code)
            {
                onUnlock.Invoke();
                Destroy(collision.gameObject);
                Destroy(this);
            }
        }
    }
}
