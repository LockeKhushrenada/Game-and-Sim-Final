using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetText : MonoBehaviour
{
    public string variableName = "";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetValueFromVariable();
    }

    public void GetValueFromVariable()
    {
        if (GameManager.instance.FindVariable(variableName) == null)
        {
            return;
        }

        ChangeText(GameManager.instance.FindVariable(variableName).value.ToString());
        
    }

    public void ChangeText(string text)
    {
        GetComponent<Text>().text = text;
    }
}
