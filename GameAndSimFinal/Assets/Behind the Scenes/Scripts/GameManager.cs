using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<CustomData> variables;

    public static GameManager instance;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        if (instance != this)
            Destroy(gameObject);

        variables  = new List<CustomData>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool AlreadyHasVariable(string n)
    {
        foreach(CustomData cd in variables)
        {
            if (cd.name == n)
            {
                return true;
            }
        }

        return false;
    }

    public CustomData RetrieveVariable(string n)
    {
        foreach (CustomData cd in variables)
        {
            if (cd.name == n)
            {
                return cd;
            }
        }

        Debug.LogError("Could not find custom variable named: [" + n + "]. Be sure that you've created the variable before trying to access it.");

        return null;
    }

    public CustomData FindVariable(string n)
    {
        for (int i = 0; i < variables.Count; i++)
        {
            if(variables[i].name == n)
            {
                return variables[i];
            }
        }

        return null;
    }
}

public class CustomData
{
    public string name = "";
    public float value;

    public CustomData(string n, float v)
    {
        name = n;
        value = v;
    }

}
