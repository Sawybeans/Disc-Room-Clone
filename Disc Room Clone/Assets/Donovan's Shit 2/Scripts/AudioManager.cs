using UnityEngine.Audio;
using System;
using UnityEngine;


public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;
    public AudioMixerGroup mixerGroupEffects;
    public AudioMixerGroup mixerGroupMusic;
    public AudioMixer musicMixer;

    private bool fadeOut = false;
    private float sVolume = 0;
    private bool musicPaused = false;

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

            if (s.name == "Level 1 Music 2")
            {
                s.source.outputAudioMixerGroup = mixerGroupMusic;
            }
            else if (s.name == "Level 1 Music")
            {
                s.source.outputAudioMixerGroup = mixerGroupMusic;
            }
            else
            {
                s.source.outputAudioMixerGroup = mixerGroupEffects;
            }
        }
    }

    private void FixedUpdate()
    {
        if (GameObject.Find("PlayerPrefab(Clone)") != null)
        {
            string name = "Level 1 Music 2";
            Sound s = Array.Find(sounds, sound => sound.name == name);

            if (musicPaused)
            {
                Play("Level 1 Music 2");
                musicPaused = false;
            }
            if (s.source.volume<.35f)
            {
               s.source.volume += .003f;
            }
            
        }
        else
        {
            
                Pause("Level 1 Music 2");

            if (Input.GetKeyDown(KeyCode.R) && musicPaused==true)
            {
                //Play("Level 1 Music 2");
                
            }
        }

    }
    private void Start()
    {
        Play("Level 1 Music 2");
    }

    // Update is called once per frame
    public void Play(string name)
    {
       Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    // Update is called once per frame
    public void PlaySound(string name, float pitch)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.pitch = pitch;
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
           musicPaused = true;
        }
            

        
    }

    public void lowPassEnable()
    {
        musicMixer.SetFloat("lowPassLevel", 300);
        musicMixer.SetFloat("lowPassLevel2", 500);
    }
    public void lowPassDisable()
    {
        musicMixer.SetFloat("lowPassLevel", 22000);
        musicMixer.SetFloat("lowPassLevel2", 22000);
    }
}
