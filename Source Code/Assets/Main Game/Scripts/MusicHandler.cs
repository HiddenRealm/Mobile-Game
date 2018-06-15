using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicHandler : MonoBehaviour {

    public Slider volumeSlider;
    public AudioSource volumeAudio;
    public float volume;

   void Update()
    {
        //very simple bit of code, sets slider value to be the music volume
        volumeAudio.volume = volumeSlider.value;
        volume = volumeAudio.volume;
    }

    //This loads in the saved volume
    public void Loadvolume(float newVol)
    {
        volumeSlider.value = newVol;
    }
}
