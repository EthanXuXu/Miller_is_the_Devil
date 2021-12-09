using UnityEngine.Audio;
using UnityEngine;

//Sound class, allows us to add audio to the game
[System.Serializable]
public class Sound
{

    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;

    [Range(.1f, 3f)]
    public float pitch;

    public bool loop;

    public AudioMixerGroup group;

    [HideInInspector]
    public AudioSource source;
}
