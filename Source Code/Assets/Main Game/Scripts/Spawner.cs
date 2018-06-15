using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject enemy;
    float randX;
    Vector2 whereToSpawn;
    private float spawnRate;
    float NextSpawn = 0.0f;

    //this class was used to spawn all of my enemy prefabs

    private void Start()
    {
        spawnRate = 2f;
    }

    // Update is called once per frame
    void Update () {

        if (Time.time > NextSpawn)
        {

            //straight forward
            //resets the timer, picks a random position, sets it to a vector
            //spawns new asteroids there.
            NextSpawn = Time.time + spawnRate;
            randX = Random.Range (-8.4f, 8.4f);
            whereToSpawn = new Vector2(randX, transform.position.y);
            Instantiate(enemy, whereToSpawn, Quaternion.identity);
        }
	}

    //setter - he's my fav
    public void SetSpawnRate()
    {
        spawnRate -= 0.3f;
    }

}
