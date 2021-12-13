using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Link : GameplayComponent
{
    public bool unlink = false;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    protected override void UpdateButton()
    {
        if (Input.GetKeyDown(GetKeyFromButtonType(key)))
        {
            ActivateLink();
        }
    }

    protected override void UpdateConstant()
    {
        ActivateLink();
    }

    protected override void UpdateOneShot()
    {
        if(!completed)
        {
            ActivateLink();
            completed = true;
        }
    }

    public void ActivateLink()
    {
        if (unlink)
            DoUnlink();
        else
            DoLink();
    }

    public void DoLink()
    {
        transform.parent = target.transform;
    }

    public void DoUnlink()
    {
        if(transform.parent == target)
        {
            transform.parent = null;
        }
    }
}
