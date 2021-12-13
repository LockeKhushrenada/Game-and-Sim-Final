using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public string variableName = "";
    public int value;

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
        if(collision.GetComponent<Player>())
        {

            if(GameManager.instance.AlreadyHasVariable(variableName))
            {
                GameManager.instance.RetrieveVariable(variableName).value += value;
                //Debug.Log(variableName + ": " + GameManager.instance.RetrieveVariable(variableName).value);
            }

            else
            {
                GameManager.instance.variables.Add(new CustomData(variableName, value));
            }

            Destroy(gameObject);
            //gameObject.SetActive(false);
        }
    }
}
