using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Saving : MonoBehaviour {

    //Jesus this was a pain.
    public GameObject Player;
    public GameObject Enemy;
    public GameObject Skills;
    public GameObject Volume;
    GameObject[] enemy;
    List<Array> enemies = new List<Array>();

    private float newVol;
    private int counter;

    private void OnEnable()
    {
        
        counter = 0;
        //this checks to see if its a new game or not
        if (FPS.Control.Loading() == false)
        {
            //checks to see if the file is stil there
            if (File.Exists(Application.persistentDataPath + "/gameInfo.dat"))
            {
                //opens the file/sets it up
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/gameInfo.dat", FileMode.Open);
                GameData data = (GameData)formatter.Deserialize(file);
                file.Close();

                //Loads the player position, inventory count, Skills And Enemyposition
                Player.transform.position = new Vector3(data.playerPosX, data.playerPosY, 0);
                Player.transform.rotation = Quaternion.AngleAxis(270.0f - data.playerRotZ, Vector3.forward);
                Inventory.gameData.cog = data.cog;
                Inventory.gameData.nut = data.nut;
                Inventory.gameData.spring = data.spring;
                Inventory.gameData.money = data.money;

                Skills.gameObject.GetComponent<Skills>().playerSpeed = data.playerSpeed;
                Skills.gameObject.GetComponent<Skills>().playerLife = data.playerLife;
                Skills.gameObject.GetComponent<Skills>().playerFireRate = data.playerFireRate;
                Skills.gameObject.GetComponent<Skills>().enemySpeed = data.enemySpeed;
                Skills.gameObject.GetComponent<Skills>().enemyAliveTime = data.enemyAliveTime;
                Skills.gameObject.GetComponent<Skills>().enemySpawnRate = data.enemySpawnRate;
                Skills.gameObject.GetComponent<Skills>().moneyDrop = data.moneyDrop;
                Skills.gameObject.GetComponent<Skills>().dropRate = data.dropRate;

                newVol = data.volume;

                //i had to do the enemy posistions in such an akward way because
                //Unity doesnt allow you to save Vector's with Serialization
                //i could have Used IXM? or something, or paid $80 for a special unity kit, or just convert to vectors to Arrays and back
                foreach (Array arrays in data.enemyPos)
                {
                    float x = 0;
                    float y = 0;
                    int count = 0;
                    foreach (float rock in arrays)
                    {
                        if (count == 0)
                        {
                            x = rock;
                            count++;
                        }
                        else
                        {
                            y = rock;
                            count = 0;
                        }
                    }

                    var pos = new Vector3(x, y, 0);
                    //builds new enemies in the old ones places, this means that get
                    //new amount of life and new directions
                    Instantiate(Enemy, pos, Quaternion.identity);

                }
            }
        } else { FPS.Control.PlayerDied(false); }

        Volume.gameObject.GetComponent<MusicHandler>().Loadvolume(newVol);
    }

    private void Start()
    {
        //Tells the skills to repurchase all of the skills
        Skills.gameObject.GetComponent<Skills>().Load();
    }

    private void Update()
    {
        counter++;

        //This is my autosave functionality
        if(counter == 500)
        {
            SaveGame();
            counter = 0;
        }
    }

    public void SaveGame()
    {
        //this creates a new file
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gameInfo.dat");

        GameData data = new GameData();
        //sets all of the classes data from the games data
        data.playerPosX = Player.transform.position.x;
        data.playerPosY = Player.transform.position.y;
        data.playerRotZ = Player.GetComponent<PlayerController>().Rotate();
        data.cog = Inventory.gameData.SaveCog();
        data.nut = Inventory.gameData.SaveNut();
        data.spring = Inventory.gameData.SaveSpring();
        data.money = Inventory.gameData.SaveMoney();

        data.playerSpeed = Skills.gameObject.GetComponent<Skills>().playerSpeed;
        data.playerLife = Skills.gameObject.GetComponent<Skills>().playerLife;
        data.playerFireRate = Skills.gameObject.GetComponent<Skills>().playerFireRate;
        data.enemySpeed = Skills.gameObject.GetComponent<Skills>().enemySpeed;
        data.enemyAliveTime = Skills.gameObject.GetComponent<Skills>().enemyAliveTime;
        data.enemySpawnRate = Skills.gameObject.GetComponent<Skills>().enemySpawnRate;
        data.moneyDrop = Skills.gameObject.GetComponent<Skills>().moneyDrop;
        data.dropRate = Skills.gameObject.GetComponent<Skills>().dropRate;

        data.volume = Volume.gameObject.GetComponent<MusicHandler>().volume;

        enemies.Clear();
        //finds all the enemies puts them into an array
        //add all of there individual vector2's into arrarys into a List
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject rock in enemy)
        {
            float[] enemyPos = new float [2] { rock.gameObject.transform.position.x, rock.gameObject.transform.position.y };
            enemies.Add(enemyPos);
        }
        data.enemyPos = enemies;

        //Serializes the data
        formatter.Serialize(file, data);
        file.Close();
    }

    //Also handles the quit button, which just loads the menu
    public void QuitGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }
}

//This is my Data File and its Layout
[Serializable]
class GameData
{
    public float playerPosX;
    public float playerPosY;
    public float playerRotZ;
    public List<Array> enemyPos;
    public int cog;
    public int nut;
    public int spring;
    public int money;
    public int playerSpeed;
    public int playerLife;
    public int playerFireRate;
    public int enemySpeed;
    public int enemyAliveTime;
    public int enemySpawnRate;
    public int moneyDrop;
    public int dropRate;
    public float volume;
}