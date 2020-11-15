using UnityEngine.Audio;
using System;
using UnityEngine;


public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    private bool fadeOut = false;
    private float sVolume = 0;

    public static AudioManager instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds)
        {
            s.source=gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void FixedUpdate()
    {
        if (GameObject.Find("PlayerPrefab(Clone)") != null)
        {
            string name = "Level 1 Music";
            Sound s = Array.Find(sounds, sound => sound.name == name);
            if (s.source.volume<.35f)
            {
               s.source.volume += .003f;
            }
            
        }
        else
        {
            
                Pause("Level 1 Music");
            
   
        }

    }
    private void Start()
    {
        Play("Level 1 Music");
    }

    // Update is called once per frame
    public void Play(string name)
    {
       Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void Pause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s.source.volume > 0)
        {
            s.source.volume -= .003f;

            
        }
        else
        {
            s.source.Pause();



            if (Input.GetKeyDown(KeyCode.R))
            {
                Play("Level 1 Music");
            }
        }
            

        
    }
}
