using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //destroys the animation after 1 full loop, lines up to a second
        Destroy(gameObject, 1);
	}
	
}
