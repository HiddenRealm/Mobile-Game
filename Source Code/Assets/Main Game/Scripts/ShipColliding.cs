using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipColliding : MonoBehaviour {

    public GameObject Player;
    
    //The Player GameObject is just made up of 2 GameObjects,
    //the first is the player sprite, rigidbody and collision
    //the second has no sprite and just contains this and a collision trigger event


    //this is the check is the players hit box has hit an enemy to damage the player.
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Player.gameObject.GetComponent<PlayerController>().LoseHealth();
        }
    }
}
