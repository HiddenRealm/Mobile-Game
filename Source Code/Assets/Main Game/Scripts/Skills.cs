using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skills : MonoBehaviour {

    //This class handled all of the skills menus & upgrades
    public int playerSpeed = 0;
    public int playerLife = 0;
    public int playerFireRate = 0;
    public int enemySpeed = 0;
    public int enemyAliveTime = 0;
    public int enemySpawnRate = 0;
    public int moneyDrop = 0;
    public int dropRate = 0;

    public GameObject Player;
    public GameObject Enemy;
    public GameObject Spawner;
    public GameObject Drops;

    public Text PSText;
    public Text PLText;
    public Text PFText;
    public Text ESText;
    public Text EAText;
    public Text ERText;
    public Text MDText;
    public Text DRText;

    private void Awake()
    {
        //on Awake it ran it of these to update the text boxes with the
        //costs and levels
        PSfun(); PLfun(); PFfun();
        ESfun(); EAfun(); ERfun();
        MDfun(); DRfun();
    }

    //each one of these does the sameish thing, again probs should have done
    //function template, anyway, gets the pick & money value, checks to see if any
    //more upgrades are available, if so it works out the cost, prints it into the text box
    // checks if the player has enough and buys it if they do
    // that sets the value somewhere else in the code
    public void PSfun()
    {
        int x = 0; int y = 0;
        int cog = Inventory.gameData.SaveCog();
        int money = Inventory.gameData.SaveMoney();
        if (playerSpeed < 5)
        {
            x = ((playerSpeed + 1) * 2);
            y = ((playerSpeed + 1) * 100);
            PSText.text = x.ToString() + " : Cogs & " + y.ToString() + " : Coins";
            if (cog >= x && money >= y)
            {
                Inventory.gameData.LoadCog(cog - x); Inventory.gameData.LoadMoney(money - y);
                playerSpeed = (playerSpeed + 1);
                Player.gameObject.GetComponent<PlayerController>().SetSpeed();
            }
        }
        else { PSText.text = "Max"; }

    }
    public void PLfun()
    {
        int x = 0; int y = 0;
        int nut = Inventory.gameData.SaveNut();
        int money = Inventory.gameData.SaveMoney();

        if (playerLife < 5)
        {
            x = ((playerLife + 1) * 2);
            y = ((playerLife + 1) * 100);
            PLText.text = x.ToString() + " : Nuts & " + y.ToString() + " : Coins";
            if (nut >= x && money >= y)
            {
                Inventory.gameData.LoadNut(nut - x); Inventory.gameData.LoadMoney(money - y);
                playerLife = (playerLife + 1);
                Player.gameObject.GetComponent<PlayerController>().SetLife();
            }
        }
        else { PLText.text = "Max"; }
    }
    public void PFfun()
    {
        int x = 0; int y = 0;
        int spring = Inventory.gameData.SaveSpring();
        int money = Inventory.gameData.SaveMoney();

        if (playerFireRate < 5)
        {
            x = ((playerFireRate + 1) * 2);
            y = ((playerFireRate + 1) * 100);
            PFText.text = x.ToString() + " : Springs & " + y.ToString() + " : Coins";
            if (spring >= x && money >= y)
            {
                Inventory.gameData.LoadSpring(spring - x); Inventory.gameData.LoadMoney(money - y);
                playerFireRate = (playerFireRate + 1);
                Player.gameObject.GetComponent<PlayerController>().SetFireRate();
            }
        }
        else { PFText.text = "Max"; }
    }

    public void ESfun()
    {
        int x = 0; int y = 0;
        int cog = Inventory.gameData.SaveCog();
        int money = Inventory.gameData.SaveMoney();
        if (enemySpeed < 5)
        {
            x = ((enemySpeed + 1) * 2);
            y = ((enemySpeed + 1) * 100);
            ESText.text = x.ToString() + " : Cogs & " + y.ToString() + " : Coins";
            if (cog >= x && money >= y)
            {
                Inventory.gameData.LoadCog(cog - x); Inventory.gameData.LoadMoney(money - y);
                enemySpeed = (enemySpeed + 1);
                Enemy.gameObject.GetComponent<RockController>().SetSpeed();
            }
        }
        else { ESText.text = "Max"; }
    }
    public void EAfun()
    {
        int x = 0; int y = 0;
        int nut = Inventory.gameData.SaveNut();
        int money = Inventory.gameData.SaveMoney();

        if (enemyAliveTime < 5)
        {
            x = ((enemyAliveTime + 1) * 2);
            y = ((enemyAliveTime + 1) * 100);
            EAText.text = x.ToString() + " : Nuts & " + y.ToString() + " : Coins";
            if (nut >= x && money >= y)
            {
                Inventory.gameData.LoadNut(nut - x); Inventory.gameData.LoadMoney(money - y);
                enemyAliveTime = (enemyAliveTime + 1);
                Enemy.gameObject.GetComponent<RockController>().SetAliveTime();
            }
        }
        else { EAText.text = "Max"; }
    }
    public void ERfun()
    {
        int x = 0; int y = 0;
        int spring = Inventory.gameData.SaveSpring();
        int money = Inventory.gameData.SaveMoney();

        if (enemySpawnRate < 5)
        {
            x = ((enemySpawnRate + 1) * 2);
            y = ((enemySpawnRate + 1) * 100);
            ERText.text = x.ToString() + " : Springs & " + y.ToString() + " : Coins";
            if (spring >= x && money >= y)
            {
                Inventory.gameData.LoadSpring(spring - x); Inventory.gameData.LoadMoney(money - y);
                enemySpawnRate = (enemySpawnRate + 1);
                Spawner.gameObject.GetComponent<Spawner>().SetSpawnRate();
            }
        }
        else { ERText.text = "Max"; }
    }

    public void MDfun()
    {
        int y = 0;
        int money = Inventory.gameData.SaveMoney();

        if (moneyDrop < 5)
        {
            y = ((moneyDrop + 1) * 250);
            MDText.text = y.ToString() + " : Coins";
            if (money >= y)
            {
                Inventory.gameData.LoadMoney(money - y);
                moneyDrop = (moneyDrop + 1);
                Inventory.gameData.GetComponent<Inventory>().SetMoneyDrop();
            }
        }
        else { MDText.text = "Max"; }
    }
    public void DRfun()
    {
        int y = 0;
        int money = Inventory.gameData.SaveMoney();

        if (dropRate < 5)
        {
            y = ((dropRate + 1) * 250);
            DRText.text = y.ToString() + " : Coins";
            if (money >= y)
            {
                Inventory.gameData.LoadMoney(money - y);
                dropRate = (dropRate + 1);
                Drops.gameObject.GetComponent<BulletController>().SetDropRate();
            }
        }
        else { DRText.text = "Max"; }
    }

    //This load function is called from the Saving Script
    //it loads all of the skills back onto the player
    public void Load()
    {
        for(int j = playerSpeed; j != 0; j--)
        {
            Player.gameObject.GetComponent<PlayerController>().SetSpeed();
        }
        for (int j = playerLife; j != 0; j--)
        {
            Player.gameObject.GetComponent<PlayerController>().SetLife();
        }
        for (int j = playerFireRate; j != 0; j--)
        {
            Player.gameObject.GetComponent<PlayerController>().SetFireRate();
        }
        for (int j = enemySpeed; j != 0; j--)
        {
            Enemy.gameObject.GetComponent<RockController>().SetSpeed();
        }
        for (int j = enemyAliveTime; j != 0; j--)
        {
            Enemy.gameObject.GetComponent<RockController>().SetAliveTime();
        }
        for (int j = enemySpawnRate; j != 0; j--)
        {
            Spawner.gameObject.GetComponent<Spawner>().SetSpawnRate();
        }
        for (int j = moneyDrop; j != 0; j--)
        {
            Inventory.gameData.GetComponent<Inventory>().SetMoneyDrop();
        }
        for (int j = dropRate; j != 0; j--)
        {
            Drops.gameObject.GetComponent<BulletController>().SetDropRate();
        }
    }
}
