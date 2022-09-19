using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    [SerializeField] private AudioSource[] soundSources;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }


    public void PlaySource(int index)
    {
        soundSources[index].Play();
    }

    public void PlaySource(string name)
    {
        Array.Find(soundSources, x => x.name == name).Play();
    }
}
