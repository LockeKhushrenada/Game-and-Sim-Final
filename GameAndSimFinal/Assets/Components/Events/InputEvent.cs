using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputEvent: MonoBehaviour
{
    public bool active = true;
    public ButtonType key;
    public bool oneShot = false;
    public UnityEvent OnInput;


    bool completed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        HandleEvent();
    }

    public void HandleEvent()
    {
        if (oneShot && completed)
            return;

        if (Input.GetKeyDown(GetKeyFromButtonType(key)))
        {
            OnInput.Invoke();
            completed = true;
        }
    }

    public KeyCode GetKeyFromButtonType(ButtonType b)
    {
        switch (b)
        {
            case ButtonType.C:
                return KeyCode.C;

            case ButtonType.E:
                return KeyCode.E;

            case ButtonType.LeftControl:
                return KeyCode.LeftControl;

            case ButtonType.LeftShift:
                return KeyCode.LeftShift;

            case ButtonType.Q:
                return KeyCode.Q;

            case ButtonType.R:
                return KeyCode.R;

            case ButtonType.RightControl:
                return KeyCode.RightControl;

            case ButtonType.RightShift:
                return KeyCode.RightShift;

            case ButtonType.SpaceBar:
                return KeyCode.Space;

            case ButtonType.V:
                return KeyCode.V;

            case ButtonType.X:
                return KeyCode.X;

            case ButtonType.Z:
                return KeyCode.Z;

            case ButtonType.None:
                return KeyCode.Joystick5Button13; // uhhh needed a key that is super unlikely to be pressed
        }

        return KeyCode.Asterisk;
    }

    public void SetActive(bool setActive)
    {
        active = setActive;
    }
}
