using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
 
    public float speed;
    private int droprate;

	// Use this for initialization
	void Start () {
        droprate = 15;
        //Use Unity's Rigidbody for movement + the shortcut for moving forward on a 2D plane.
        GetComponent<Rigidbody2D>().velocity = transform.up * speed;
        //The Bullet is only on the screen for 3 seconds before it is detroyed
        //I did it this way so that the bullet has enough time to get from corner to corner
        Destroy(gameObject, 3);
	}

    //Collision Trigger Event
    void OnTriggerEnter2D(Collider2D other)
    {
        //checks if the collision is on an enemy
        //earlier problem was that it was destroying the player on the first frame you fired
        if (other.tag == "Enemy")
        {
            Vector3 pos = this.gameObject.transform.position;
            SpawnDrop(pos);
            //Tells Inventory(GameManager) to spawn an explosion on this location
            Inventory.gameData.Explo(pos);
            //Tells Inventory(GameManager) to increase the money
            Inventory.gameData.GetMoney();
            //Destorys both objects
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }

    void SpawnDrop(Vector3 pos)
    {
       //Picks a random number between 0-20
       //if its bigger than Int droprate, then it spawns a pickup
       //pickup is decided with the second random number
       int x = Random.Range(0, 20);
       int y = Random.Range(0, 3);

        if (x >= droprate)
        {
            Inventory.gameData.GetComponent<Inventory>().Buttons(pos, y);
        }

    }

    //Allows the Skill Tree to update stats
    public void SetDropRate()
    {
        droprate -= 2;
    }
}
