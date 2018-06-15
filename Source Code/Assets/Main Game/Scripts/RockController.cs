using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour
{
    public GameObject Directions;
    private float topSpeed;
    private int aliveTime;
    float counter;
    float xDir; float yDir;

    // Use this for initialization
    void Start()
    {
        topSpeed = 0.3f;
        aliveTime = 10;

        //i wanted my asteroids to pick a random
        //rotation to take that way they would all move
        //differently, if i left myself more time
        //i wanted to have the asteroids spawn on the edges
        //of the screen and move into the middle 
        xDir = (Random.Range(0, 3) - 1);
        yDir = (Random.Range(0, 3) - 1);
        if(xDir == 0 && yDir == 0)
        {
            yDir++;
        }
        counter = 0;
    }

    void Update()
    {
        counter = counter + (1 * Time.deltaTime);
        Movement(topSpeed, xDir, yDir);

        //Asteroids disappear after a while so the
        //player has to keep killing them to get pickups
        if(counter >= aliveTime)
        {
            Destroy(gameObject);
        }
    }

    //Very basic movement not even using rigidbody,
    //this was one of the first scripts i wrote in
    //this assignment and i havent really come back
    //to it to update, however it works, so no need to fix.
    void Movement(float speed, float xDir, float yDir)
    {
        float xMove = xDir * speed * Time.deltaTime;
        float yMove = yDir * speed * Time.deltaTime;

        transform.Translate(xMove, yMove, 0);
    }


    //Setters
    public void SetSpeed()
    {
        topSpeed -= 0.005f;
    }

    public void SetAliveTime()
    {
        aliveTime += 1;
    }
}
