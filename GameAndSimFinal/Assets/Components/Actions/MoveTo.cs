using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : GameplayComponent
{
    public GameObject target;
    public Vector3 newPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected override void UpdateButton()
    {
        if (Input.GetKeyDown(GetKeyFromButtonType(key)))
            target.transform.position = newPosition;
    }

    protected override void UpdateConstant()
    {
        if (!completed)
        {
            target.transform.position = newPosition;
            completed = true;
        }
    }

    protected override void UpdateOneShot()
    {
        target.transform.position = newPosition;
    }

    public void Move()
    {
        target.transform.position = newPosition;
    }
}
