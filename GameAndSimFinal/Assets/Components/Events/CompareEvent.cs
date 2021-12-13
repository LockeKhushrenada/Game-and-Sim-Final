using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CompareEvent : MonoBehaviour
{
    public enum Comparison
    {
        equal,
        greaterThan,
        greaterThanOrEqualTo,
        lessThan,
        lessThanOrEqualTo,
        notEqual
    }

    public bool active = true;
    public Comparison comparisonType;
    public string variable = "";
    public int value;
    public UnityEvent ifComparisonIsTrue;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Update()
    {
        if (active)
            CheckComparison();
    }

    void CheckComparison()
    {
        float check = 0;
        // if that variable doesn't exist, quit
        if(GameManager.instance.FindVariable(variable) == null)
        {
            return;
        }

        else
        {
            check = GameManager.instance.FindVariable(variable).value;
        }

        switch(comparisonType)
        {
            case Comparison.equal:
                if (check == value)
                    ifComparisonIsTrue.Invoke();
                break;

            case Comparison.greaterThan:
                if(check > value)
                    ifComparisonIsTrue.Invoke();
                break;

            case Comparison.greaterThanOrEqualTo:
                if(check >= value)
                    ifComparisonIsTrue.Invoke();
                break;

            case Comparison.lessThan:
                if(check < value)
                    ifComparisonIsTrue.Invoke();
                break;

            case Comparison.lessThanOrEqualTo:
                if(check <= value)
                    ifComparisonIsTrue.Invoke();
                break;

            case Comparison.notEqual:
                if(check != value)
                    ifComparisonIsTrue.Invoke();
                break;
        }
    }

    public void SetActive(bool setActive)
    {
        active = setActive;
    }
}
