using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioMixerGroup mainMixerGroup;

    [SerializeField]
    private bool is3D;

    public Sound[] sounds;

    // Start is called before the first frame update
    void Awake()
    {
        foreach(Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.outputAudioMixerGroup = mainMixerGroup;
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;

            if(is3D)
            {
                sound.source.spatialBlend = 1;
                sound.source.rolloffMode = AudioRolloffMode.Linear;
                sound.source.maxDistance = 50;
            }
            
        }
    }

    public void PlaySound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(!s.source.isPlaying)
            s.source.Play();
    }

    public void StopSound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s.source.isPlaying)
            s.source.Stop();
    }

}
