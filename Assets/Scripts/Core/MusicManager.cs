using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField]
    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = GetComponent<AudioManager>();

        audioManager.PlaySound("Music");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetVolume(float volume)
    {
        foreach(Sound sound in audioManager.sounds)
        {
            if(0 <= volume && volume <= sound.volume)
            {
                sound.source.volume = volume;
            }
            else if(volume > sound.volume)
            {
                sound.source.volume = sound.volume;
            }
            else
            {
                sound.source.volume = 0;
            }
            
        }
    }
}
