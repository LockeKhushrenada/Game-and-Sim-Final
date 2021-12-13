using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : GameplayComponent
{
    public GameplayComponent target;
    public string variableName;
    public float value;
    
    public enum TypeOfChange
    {
        set,
        add,
        subtract
    }

    public TypeOfChange typeOfChange;

    // Start is called before the first frame update
    void Start()
    {
        if (active && typeOfChange == TypeOfChange.set)
            SetNewVariable();
    }

    public void SetNewVariable()
    {
        variableName = variableName.ToLower();

        // if the variable hasn't been made, make it
        if (typeOfChange == TypeOfChange.set && !GameManager.instance.AlreadyHasVariable(variableName))
        {
            GameManager.instance.variables.Add(new CustomData(variableName, value));
        }
    }

    protected override void UpdateButton()
    {
        if (Input.GetKeyDown(GetKeyFromButtonType(key)))
        {
            EditData();
        }
    }

    protected override void UpdateConstant()
    {
        EditData();
    }

    protected override void UpdateOneShot()
    {
        if(active && !completed)
        {
            EditData();
            completed = true;
        }
    }
    

    public void EditData()
    {
        // retrieve data
        CustomData d = GameManager.instance.RetrieveVariable(variableName);
        if (d == null)
            return;

        // change data
        d.value = ChangeValue(d.value);
    }

    float ChangeValue(float val)
    {
        switch(typeOfChange)
        {
            case TypeOfChange.set:
                val = value;
                break;

            case TypeOfChange.add:
                val += value;
                break;

            case TypeOfChange.subtract:
                val -= value;
                break;
        }

        return val;
    }
    

}
