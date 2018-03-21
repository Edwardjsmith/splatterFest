using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{

    public AudioSource musicSource;
    AudioClip clip;

    public AudioClip[] music;

    // Use this for initialization

   
        
    
    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update ()
    {
        
        if (Input.GetKeyDown(KeyCode.Y))
        {
            clip = music[0];
            playSound(clip);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            clip = music[1];
            playSound(clip);
        }

        

        

    }

    void playSound(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }
}
