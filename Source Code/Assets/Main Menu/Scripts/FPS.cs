using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS : MonoBehaviour {

    /*Sets the class to be static, 
     i use this class when the player
     loads the main menu on a different scene
     it checks to see if the game should load
     the save file or start brand new*/
    public static FPS Control;
    private bool died = false;

    float deltaTime = 0.0f;

    void Awake()
    {
        //this is to make sure that i only 
        //ever have 1 instance of this class
        if(Control == null)
        {
            DontDestroyOnLoad(gameObject);
            Control = this;
        }
        else if(Control != this)
        {
            Destroy(this.gameObject);
        }
        
    }

    void Update()
    {
        //I use unscaledDeltaTime here because
        //it is not affected by Time.timeScale
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }

    //I used the OnGUI function here because
    //I didnt want to mess around with this at anytime,
    //Wanted it to work on its own system.
    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        //Allows me to make my own font properties
        GUIStyle style = new GUIStyle();

        //Make a rectangle
        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        //Align it in the top corner
        style.alignment = TextAnchor.UpperRight;
        //Set font size
        style.fontSize = h * 2 / 100;
        //Text colour
        style.normal.textColor = new Color(0.5f, 1.0f, 0.5f, 1.0f);
        //Defining Milliseconds
        float msec = deltaTime * 1000.0f;
        //Defininf FPS
        float fps = 1.0f / deltaTime;
        //Setting text layout
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        //Creating
        GUI.Label(rect, text, style);
    }

    //These two keep track off and update return playerdeath
    public void PlayerDied(bool x)
    {
        died = x;
    }

    public bool Loading()
    {
        return died;
    }
}
