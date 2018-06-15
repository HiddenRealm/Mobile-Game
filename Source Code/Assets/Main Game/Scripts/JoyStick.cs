using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image bgImg;
    private Image joystickImg;
    private Vector3 inputs;
    private bool shots;

    // Use this for initialization
    void Start()
    {
        bgImg = GetComponent<Image>();
        joystickImg = transform.GetChild(0).GetComponent<Image>();
        shots = false;
    }

    //Checks if the screen is pressed down, i use this to know when to start shooting
    // sends the info to the drag version.
    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
        shots = true;
    }

    //checks when finger is lifting off, this sets the joystick
    //back into default position and stops shooting.
    public virtual void OnPointerUp(PointerEventData ped)
    {
        inputs = Vector3.zero;
        joystickImg.rectTransform.anchoredPosition = Vector3.zero;
        shots = false;
    }

    //the drag function works out the rotation that the player should be turnt
    //most of it anyway, the rest is done inside PlayerController, it also moves and
    //locks the smaller joystick around the larger background one.
    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImg.rectTransform, ped.position, ped.pressEventCamera, out pos))
        {
            pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y);

            inputs = new Vector3(pos.x * 2 + 1, pos.y * 2 - 1, 0);
            inputs = (inputs.magnitude > 1.0f) ? inputs.normalized : inputs;

            joystickImg.rectTransform.anchoredPosition = new Vector3(inputs.x * (bgImg.rectTransform.sizeDelta.x / 3), inputs.y * (bgImg.rectTransform.sizeDelta.y / 3), 0);
        }
    }

    //to shoot or not to shoot,
    //that really is the question
    public bool Shooting()
    {
        return shots;
    }

    //Sends the angles back to player
    public float Horizontal()
    {
        if (inputs.x != 0)
        {
            return inputs.x;
        }
        
        return 0;
    }

    public float Vertical()
    {
        if (inputs.y != 0)
        {
            return inputs.y;
        }
        
        return 0;
    }
}
