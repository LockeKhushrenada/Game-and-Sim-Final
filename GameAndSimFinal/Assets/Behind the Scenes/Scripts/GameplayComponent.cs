using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractionType
{
    Button,
    OneShot,
    Constant,
    OnEvent
}

public enum ButtonType
{
    None,
    A,
    C,
    D,
    E,
    F,
    Q,
    R,
    S,
    V,
    W,
    X,
    Z,
    SpaceBar,
    UpArrow,
    DownArrow,
    LeftArrow,
    RightArrow,
    LeftControl,
    LeftShift,
    RightControl,
    RightShift
}

public class GameplayComponent : MonoBehaviour
{
    public InteractionType inputType;
    public ButtonType key;
    public bool active = true;
    public float delay = 0;
    public float speed = 0;
    public float timeBetween = 0.5f;

    protected bool completed = false;
    protected float delayElapsed = 0;
    protected bool delayComplete = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (!active)
            return;

        delayElapsed += Time.deltaTime;

        if (delayElapsed < delay)
            return;

        switch (inputType)
        {
            case InteractionType.Button:
                UpdateButton();
                break;

            case InteractionType.OneShot:
                UpdateOneShot();
                break;

            case InteractionType.Constant:
                UpdateConstant();
                break;

            case InteractionType.OnEvent:
                break;
        }

    }

    protected virtual void UpdateButton()
    {
    }

    protected virtual void UpdateOneShot()
    {
    }

    protected virtual void UpdateConstant()
    {
    }

    public void SetActive(bool toggle)
    {
        active = toggle;
    }

    public KeyCode GetKeyFromButtonType(ButtonType b)
    {
        switch(b)
        {
            case ButtonType.A:
                return KeyCode.A;

            case ButtonType.C:
                return KeyCode.C;

            case ButtonType.D:
                return KeyCode.D;

            case ButtonType.DownArrow:
                return KeyCode.DownArrow;

            case ButtonType.E:
                return KeyCode.E;

            case ButtonType.F:
                return KeyCode.F;

            case ButtonType.LeftArrow:
                return KeyCode.LeftArrow;

            case ButtonType.LeftControl:
                return KeyCode.LeftControl;

            case ButtonType.LeftShift:
                return KeyCode.LeftShift;

            case ButtonType.Q:
                return KeyCode.Q;

            case ButtonType.R:
                return KeyCode.R;

            case ButtonType.RightArrow:
                return KeyCode.RightArrow;

            case ButtonType.S:
                return KeyCode.S;

            case ButtonType.RightControl:
                return KeyCode.RightControl;

            case ButtonType.RightShift:
                return KeyCode.RightShift;

            case ButtonType.SpaceBar:
                return KeyCode.Space;

            case ButtonType.UpArrow:
                return KeyCode.UpArrow;

            case ButtonType.V:
                return KeyCode.V;

            case ButtonType.W:
                return KeyCode.W;

            case ButtonType.X:
                return KeyCode.X;

            case ButtonType.Z:
                return KeyCode.Z;

            case ButtonType.None:
                return KeyCode.Joystick5Button13; // uhhh needed a key that is super unlikely to be pressed
        }

        return KeyCode.Asterisk;
    }
}
