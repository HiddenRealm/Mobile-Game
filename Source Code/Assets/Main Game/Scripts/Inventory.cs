using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    //I set this class as a static one, i used it as a sort of GameManager
    //It kept track of a lot of different parts of the game.
    public static Inventory gameData;
    //I imported alot of GameObjects into this code
    //Im not really sure if this was bad practice and i sould try
    //to limit the amount i use but it helped keep track of alot of systems, including prefabs.
    public GameObject Saving;
    public GameObject Cog;
    public GameObject Nut;
    public GameObject Spring;
    public GameObject CogText;
    public GameObject NutText;
    public GameObject SpringText;
    public GameObject CoinText;
    public GameObject Player;
    public GameObject Explos;
    public Transform Canvas;
    private int moneyDrop;

    public Text healthText;
    private Text cogText;
    private Text nutText;
    private Text springText;
    private Text coinText;
    public int cog;
    public int money;
    public int nut;
    public int spring;
    private int noC; private int noN; private int noS;

    private void Awake()
    {
        gameData = this.GetComponent<Inventory>();
        cogText = CogText.GetComponentInChildren<Text>();
        nutText = NutText.GetComponentInChildren<Text>();
        springText = SpringText.GetComponentInChildren<Text>();
        coinText = CoinText.GetComponentInChildren<Text>();

        moneyDrop = 100;
        noC = 0; noN = 0; noS = 0;
    }

    private void Start()
    {
        Updating();
    }

    // Update is called once per frame
    void Update()
    {
        noC++; noN++; noS++;
        Updating();
    }

    public void Buttons(Vector3 pos, int which)
    {
        //This is where the pickups are spawned
        //I tried to have set the position of the spawns
        //to be the same as where the bullet collided
        //However these positions never lasted, im still not sure why
        // i have them pick a random position later in the code
        float x = ((pos.x + 8.33f) * 48);
        float y = ((pos.y + 5f) * 48);
        Vector3 newPos = new Vector3(x, y , 0);

        //chooses which prefab to load a version of
        if (which == 0)
        {
            Instantiate(Cog, newPos, Quaternion.identity, Canvas);
        }
        else if (which == 1)
        {
            Instantiate(Nut, newPos, Quaternion.identity, Canvas);
        }
        else if (which == 2)
        {
            Instantiate(Spring, newPos, Quaternion.identity, Canvas);
        }
    }

    public void Explo(Vector3 pos)
    {
        //makes an explosion animation appear
        Instantiate(Explos, pos, Quaternion.identity);
    }

    public void Collect(int which)
    {
        //there is where the pickups would get updated and stored
        //i was having a problem where every click would add 
        //150 or so, so i added a counter system to limit the pickup rate
        if (which == 0 && noC > 5)
        {
            cog++;
            noC = 0;
        }
        else if (which == 1 && noN > 5)
        {
            nut++;
            noN = 0;
        }
        else if (which == 2 && noS > 5)
        {
            spring++;
            noS = 0;
        }
        Updating();
    }

    //This one is my favourite getter so it gets to be higher
    //favourite for absoulutly no reason
    public void GetMoney()
    {
        money += moneyDrop;
    }

    private void Updating()
    {
        //this function simply updates all of the
        //text boxes to display to the player
        //all of the need UI features
        cogText.text = cog.ToString();
        nutText.text = nut.ToString();
        springText.text = spring.ToString();
        coinText.text = money.ToString();
        int life = Player.gameObject.GetComponent<PlayerController>().life;
        healthText.text = life.ToString();
    }

    //Getters & Setters <3
    public int SaveCog()
    {
        return cog;
    }

    public void LoadCog(int newCog)
    {
        cog = newCog;
    }

    public int SaveNut()
    {
        return nut;
    }

    public void LoadNut(int newNut)
    {
        nut = newNut;
    }

    public int SaveSpring()
    {
        return spring;
    }

    public void LoadSpring(int newSpring)
    {
        spring = newSpring;
    }

    public void SetMoneyDrop()
    {
        moneyDrop += 50;
    }

    public int SaveMoney()
    {
        return money;
    }

    public void LoadMoney(int newMoney)
    {
        money = newMoney;
    }
}
