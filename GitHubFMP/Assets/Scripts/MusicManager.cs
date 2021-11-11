using UnityEngine;
using System.Collections;


public class MusicManager : MonoBehaviour
{
  
    [SerializeField]
    private AudioClip menuMusic;

    
    [SerializeField]
    private AudioClip levelMusic;

    [SerializeField]
    
    private AudioSource source;

   
    static private MusicManager instance;

    
    protected virtual void Awake()
    {
        // Singleton enforcement
        if (instance == null)
        {
            // Register as singleton if first
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            // Self-destruct if another instance exists
            Destroy(this);
            return;
        }
    }

    protected virtual void Start()
    {
        // If the game starts in a menu scene, play the appropriate music
        PlayMenuMusic();
    }

    static public void PlayMenuMusic()
    {
        if (instance != null)
        {
            if (instance.source != null)
            {
                instance.source.Stop();
                instance.source.clip = instance.menuMusic;
                instance.source.Play();
            }
        }
        else
        {
            Debug.LogError("Unavailable MusicPlayer component");
        }
    }


    static public void PlayGameMusic()
    {
        if (instance != null)
        {
            if (instance.source != null)
            {
                instance.source.Stop();
                instance.source.clip = instance.levelMusic;
                instance.source.Play();
            }
        }
        else
        {
            Debug.LogError("Unavailable MusicPlayer component");
        }
    }
}