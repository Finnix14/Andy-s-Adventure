using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager AudioManagerInstance;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (AudioManagerInstance == null)
            
        {
            AudioManagerInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
                
    }
}
