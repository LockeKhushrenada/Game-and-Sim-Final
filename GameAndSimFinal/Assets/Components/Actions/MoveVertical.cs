using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVertical : MonoBehaviour
{
    public InteractionType inputType;
    public ButtonType upKey;
    public ButtonType downKey;
    public bool active = true;
    public float delay = 0;
    float delayElapsed = 0;
    bool completed = false;
    public float speed;
    public bool flipYBasedOnSpeed = false;
    public bool rotateBasedOnSpeed = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    public void Update()
    {
        //base.Update();
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

        if (GetComponent<SpriteRenderer>() != null)
        {
            if (flipYBasedOnSpeed)
            {
                if (GetComponent<Rigidbody2D>().velocity.y > 0)
                {
                    GetComponent<SpriteRenderer>().flipY= false;
                }
                else if (GetComponent<Rigidbody2D>().velocity.y > 0)
                {
                    GetComponent<SpriteRenderer>().flipY = true;
                }
            }

            if (rotateBasedOnSpeed)
            {
                if (GetComponent<Rigidbody2D>().velocity != Vector2.zero)
                {
                    float angle = Mathf.Atan2(GetComponent<Rigidbody2D>().velocity.y, GetComponent<Rigidbody2D>().velocity.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
                }

            }
        }
    }


    protected void UpdateButton()
    {
        float i = 0;
        //i = Input.GetAxis("Horizontal");
        int pos = Input.GetKey(GetKeyFromButtonType(upKey)) ? 1 : 0;
        int neg = Input.GetKey(GetKeyFromButtonType(downKey)) ? 1 : 0;
        i = pos - neg;


        ApplyVelocity(i);
    }

    protected void UpdateOneShot()
    {
        if (active && !completed)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, speed), ForceMode2D.Impulse);

            completed = true;

        }
    }

    protected void UpdateConstant()
    {
        ApplyVelocity(1);
    }

    void ApplyVelocity(float mult)
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, speed * mult);
    }

    public KeyCode GetKeyFromButtonType(ButtonType b)
    {
        switch (b)
        {
            case ButtonType.A:
                return KeyCode.A;

            case ButtonType.C:
                return KeyCode.C;

            case ButtonType.D:
                return KeyCode.D;

            case ButtonType.E:
                return KeyCode.E;

            case ButtonType.F:
                return KeyCode.F;

            case ButtonType.LeftControl:
                return KeyCode.LeftControl;

            case ButtonType.LeftShift:
                return KeyCode.LeftShift;

            case ButtonType.Q:
                return KeyCode.Q;

            case ButtonType.R:
                return KeyCode.R;

            case ButtonType.S:
                return KeyCode.S;

            case ButtonType.RightControl:
                return KeyCode.RightControl;

            case ButtonType.RightShift:
                return KeyCode.RightShift;

            case ButtonType.SpaceBar:
                return KeyCode.Space;

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
