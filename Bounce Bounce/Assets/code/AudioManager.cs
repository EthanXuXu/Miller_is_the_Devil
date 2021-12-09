using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    public static AudioManager instance;

    // Start is called before the first frame update
    void Awake()
    {
        //when we load into another scene, this ensures that there is only one AudioManager
        if(instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(gameObject);
            return;
        }

        //doesn't reset the music when loading into a new scene
        DontDestroyOnLoad(gameObject);

        //set up the audio
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.group;
        }


    }

    void Start()
    {
        Play("Theme");
    }

    public void Play(string name)
    {

        Sound s = Array.Find(sounds, sound => sound.name == name);

        if(s == null)
        {
            Debug.LogWarning("Sound: "+ name + " not found");
            return;
        }
        s.source.Play();
    }
}
