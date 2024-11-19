using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioClip music;
    [SerializeField] private AudioSource audioSource;
    private static MusicManager instance;

    public static MusicManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = GameObject.FindObjectOfType<MusicManager>();
                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if(this != instance)
            {
                Destroy(this.gameObject);
            }
        }
        Play();
    }
    private void Play()
    {
        audioSource.PlayOneShot(music);
    }
}
