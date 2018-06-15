using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //PlayerControler handles everything to do with
    //the player object
    private bool gyroEnabled;
    private Gyroscope gyro;
    private float topSpeed;
    private float nextShot;
    public float fireRate;
    private float angle;
    public int life;
    private float speedUp;
    
    public JoyStick joystick;
    public GameObject Saving;
    public GameObject Explos;
    public GameObject Bullet;
    

    // Use this for initialization
    void OnEnable()
    {
        //This was my gyro checker, until i realised that gyro doesnt matter
        //but the accelerometer does, so i changed the check and kept all of the
        //variable names as it didnt seem to important
        gyroEnabled = EnableGyro();
        if(gyroEnabled == true)
        {
            speedUp = 2.5f;
        } else { speedUp = 1f; }
        topSpeed = 3f;
        life = 3;
        fireRate = 0.2f;
    }

    void Update()
    {
        //Checks to see if to use the accelerometer or keyboard for moving
        if (gyroEnabled)
        {
            ControlByGyro(topSpeed);
        }
        else
        {
            ControlByArrowKeys(topSpeed);
        }

       Rotations();

        //Shoots the bullets
        if (joystick.Shooting() == true && Time.time > nextShot)
        {
            Vector3 playerPos = gameObject.transform.position;
            playerPos.y = playerPos.y + 0.6f;
            Instantiate(Bullet, gameObject.transform.position, gameObject.transform.rotation);
            nextShot = Time.time + fireRate;
        }

        //disables movement when game paused
        if (Time.timeScale == 0)
        {
            gyroEnabled = false;
        }
        else
        {
            gyroEnabled = EnableGyro();
        }

        if(life <= 0)
        {
            hasDied();
        }
    }

    //Basic movement
    void ControlByArrowKeys(float speed)
    {
        float xMove = Input.GetAxis("Horizontal") * speed; //moving along the x axis
        float yMove = Input.GetAxis("Vertical") * speed; //moving along the y axis
        
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(xMove, yMove);
    }

    void ControlByGyro(float speed)
    {
        float xMove = Input.acceleration.x * speed; //moving along the x axis
        float yMove = Input.acceleration.y * speed; //moving along the y axis

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(xMove, yMove);
    }

    //does a little bit of math to work out the correct rotation that the player should be in
    void Rotations()
    {
        var xRot = joystick.Horizontal(); 
        var yRot = joystick.Vertical() * -1;

        if(xRot != 0.0 || yRot != 0.0)
        {
            angle = Mathf.Atan2(yRot, xRot) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(270.0f - angle, Vector3.forward);
        }
    }

    //this is for the bullets
    public float Rotate()
    {
        if (angle != 0)
        {
            return angle;
        }

        return 0;
    }

    //this is the accelerometer checker
    //famously called EnableGyro
    bool EnableGyro()
    {
        if (SystemInfo.supportsAccelerometer)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            return true;
        }

        return false;
    }

    //More Getters & Setters, No Favourites here
    public void SetSpeed()
    {
        topSpeed += speedUp;
    }

    public void SetLife()
    {
        life += 1;
        
    }

    public void SetFireRate()
    {
        fireRate -= 0.02f;
    }
    
    public void LoseHealth()
    {
        Instantiate(Explos, gameObject.transform.position, Quaternion.identity);
        life--;
    }

    public void hasDied()
    {
        FPS.Control.PlayerDied(true);
        Saving.gameObject.GetComponent<Saving>().QuitGame();
    }
}
