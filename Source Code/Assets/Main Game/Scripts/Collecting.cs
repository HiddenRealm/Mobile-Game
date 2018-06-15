using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collecting : MonoBehaviour {
    
    public Button thisButton;
    public int collect;
    private float x, y;

	// Use this for initialization
	void Start () {
        thisButton = gameObject.GetComponent<Button>();
        //picks a location to spawn on the map, if I left myself more time i would have
        //included a SpawnIn animation that swooshs the item onto the screen
        x = Random.Range(10, 790);
        y = Random.Range(10, 470);
        gameObject.transform.position = new Vector3(x, y, 0);
    }
	
	// Update is called once per frame
	void Update () {
        //This was the only work around i could find at the time
        //Looking at it now i see that i could have just added it
        //as a trigger on the inspector panel, i left it in to show previous errors
        //it declares that when the button is clicked it adds the command to run that function
        thisButton.onClick.AddListener(Collect);
	}

    void Collect()
    {
        //this function tells the Inventory(GameManager) to add 1 pickup to the score
        //collect is defined in the prefab inspector panel, it was easier than writing 3 scripts
        Inventory.gameData.Collect(collect);
        Destroy(this.gameObject);
    }
}
