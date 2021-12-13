using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class PositionEvent: UnityEvent<Vector2>
{

}

public class MouseClickEvent : MonoBehaviour
{
    public int mouseButton = 0;
    public PositionEvent ifMouseClicked;
    public Transform target;
    public Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(mouseButton))
        {
            /*Debug.Log("MX:" + Camera.main.ScreenToWorldPoint(Input.mousePosition).x + " MY:" + Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            Debug.Log("Target Position: " + position + (target == null ? Vector3.zero : target.position));
            */
            
            if (position == Vector3.zero || position == null)
            {
                ifMouseClicked.Invoke(Vector2.zero);
            }

            else
            {
                Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
                mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
                if (Vector2.Distance(mousePosition, position + (target == null ? Vector3.zero : target.position)) <= 2)
                {

                    Debug.Log("Clicked in position");
                    ifMouseClicked.Invoke(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                }
            }
        }
        
    }


}
