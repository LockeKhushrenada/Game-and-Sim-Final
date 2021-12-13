using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Follow : GameplayComponent
{
    public GameObject target;

    public bool x = true;
    public bool y = true;
    public bool z = false;

    bool doFollow = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void Update()
    {
        base.Update();

        if (doFollow)
            DoFollow();
        
    }

    protected override void UpdateButton()
    {
        if (Input.GetKey(GetKeyFromButtonType(key)))
            doFollow = true;
    }

    protected override void UpdateConstant()
    {
        doFollow = true;
    }

    protected override void UpdateOneShot()
    {
        if (active && !completed)
        {
            doFollow = true;
            completed = true;
        }
    }

    public void EnableFollow()
    {
        doFollow = true;
    }

    void DoFollow()
    {
        if (target == null)
            return;

        if(GetComponent<Rigidbody2D>() != null)
        {
            GetComponent<Rigidbody2D>().velocity = (target.transform.position - transform.position) * speed;
        }

        else
        {
            Vector3 newPosition = new Vector3(
                        x ? target.transform.position.x : transform.position.x,
                        y ? target.transform.position.y : transform.position.y,
                        z ? target.transform.position.z : transform.position.z);

            transform.position = Vector3.Lerp(transform.position, newPosition, speed * Time.deltaTime);

            
        }

        if (transform.position == target.transform.position && inputType == InteractionType.OneShot)
        {
            doFollow = false;
        }

    }



}
