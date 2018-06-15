using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour {

    //MenuControl is as it sounds, it runs all of my UI menus
    //well the majority, it also handles my resoultionchanger
    //which doesnt work on the Android version but works fine
    //on the windows version, Try it out!
    public Transform Main;
    public Transform Sound;
    public Transform Res;
    public Transform Skill;
    public Transform canvas;
    public Transform Image;
    public Transform playerSkills;
    public Transform enemySkills;
    public Transform dropSkills;
    public int paused;
    public int resoloutionIndex;
    public Dropdown resoloutionDropdown;
    public Resolution[] resolutions;

    private void Start()
    {
        paused = 0;

        //checks to see if the drop down has be changed, if so runs the function
        resoloutionDropdown.onValueChanged.AddListener(delegate { ResoloutionChange(); });
        //adds all of the resolutions possible to the drop down list
        resolutions = Screen.resolutions;
        foreach(Resolution resolution in resolutions)
        {
            resoloutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }
    }

    //the majority of these functions just toggle all of the
    //different menus in my game, looking back at this
    //it would have been the perfect place to use a template function
    private void Update()
    {
        if(Time.timeScale == 1)
        {
            Main.gameObject.SetActive(true);
            Sound.gameObject.SetActive(false);
            Res.gameObject.SetActive(false);
            Skill.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        if (canvas.gameObject.activeInHierarchy == false)
        {
            canvas.gameObject.SetActive(true);
            Image.gameObject.SetActive(false);
            Time.timeScale = 0;
        }
        else
        {
            canvas.gameObject.SetActive(false);
            Image.gameObject.SetActive(true);
            Time.timeScale = 1;
        }
    }

    public void SoundToggle()
    {
        if (Sound.gameObject.activeInHierarchy == false)
        {
            Sound.gameObject.SetActive(true);
            Main.gameObject.SetActive(false);
        }
        else
        {
            Sound.gameObject.SetActive(false);
            Main.gameObject.SetActive(true);
        }
    }

    public void ResoloutionToggle()
    {
        if (Res.gameObject.activeInHierarchy == false)
        {
            Res.gameObject.SetActive(true);
            Main.gameObject.SetActive(false);
        }
        else
        {
            Res.gameObject.SetActive(false);
            Main.gameObject.SetActive(true);
        }
    }

    public void SkillToggle()
    {
        if (Skill.gameObject.activeInHierarchy == false)
        {
            Skill.gameObject.SetActive(true);
            Main.gameObject.SetActive(false);
        }
        else
        {
            Skill.gameObject.SetActive(false);
            Main.gameObject.SetActive(true);
        }
    }

    public void playerSkillToggle()
    {
        if (playerSkills.gameObject.activeInHierarchy == false)
        {
            playerSkills.gameObject.SetActive(true);
            Skill.gameObject.SetActive(false);
        }
        else
        {
            playerSkills.gameObject.SetActive(false);
            Skill.gameObject.SetActive(true);
        }

    }

    public void enemeySkillToggle()
    {
        if (enemySkills.gameObject.activeInHierarchy == false)
        {
            enemySkills.gameObject.SetActive(true);
            Skill.gameObject.SetActive(false);
        }
        else
        {
            enemySkills.gameObject.SetActive(false);
            Skill.gameObject.SetActive(true);
        }

    }

    public void dropSkillToggle()
    {
        if (dropSkills.gameObject.activeInHierarchy == false)
        {
            dropSkills.gameObject.SetActive(true);
            Skill.gameObject.SetActive(false);
        }
        else
        {
            dropSkills.gameObject.SetActive(false);
            Skill.gameObject.SetActive(true);
        }

    }

    //Changes the resolution to the one selected
    public void ResoloutionChange()
    {
        Screen.SetResolution(resolutions[resoloutionDropdown.value].width, resolutions[resoloutionDropdown.value].height, true);
    }
}