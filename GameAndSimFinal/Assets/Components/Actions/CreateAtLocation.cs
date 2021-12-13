using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAtLocation : GameplayComponent
{
    public GameObject target;
    public GameObject objectToCreate;
    public Vector3 location;

    float elapsed = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    protected override void UpdateButton()
    {
        if(Input.GetKeyDown(GetKeyFromButtonType(key)))
        {
            Create();
        }
    }

    protected override void UpdateConstant()
    {
        elapsed += Time.deltaTime;

        if(elapsed > timeBetween)
        {
            Create();
            elapsed = 0;
        }
    }

    protected override void UpdateOneShot()
    {
        if (active && !completed)
        {
            Create();
            completed = true;
        }
    }

    public void Create()
    {
        Vector3 loc = new Vector3();
        loc = location + (target == null ? Vector3.zero : target.transform.position);
        Instantiate(objectToCreate, loc, Quaternion.identity);
    }

    public void Create(Vector2 loc)
    {
        Instantiate(objectToCreate, loc, Quaternion.identity);
    }
}
