using System;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public Sound[] musicSounds, sfxSounds;
    public SoundArray[] sfxSoundArray;
    public AudioSource musicSource, sfxSource, extraSFXSource;

    private void Start()
    {
        StartCoroutine(playMusic());
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void PlayMusic(string name)
    {
        Sound sound = Array.Find(musicSounds, x => x.name == name);

        if (sound == null)
        {
            Debug.Log("Sound not found or is null");
        }
        else
        {
            musicSource.clip = sound.clip;
            musicSource.Play();
        }
    }

    
    public void PlaySFX(string name)
    {
        Sound sound = Array.Find(sfxSounds, x => x.name == name);

        if (sound == null)
        {
            Debug.Log("Sound not found or is null");
        }
        else
        {
            Debug.Log("ShouldPlayOneShot");
            sfxSource.PlayOneShot(sound.clip);
        }
    }
   
    public void PlaySFXArrayRandom(string name)
    {
        SoundArray soundArray = Array.Find(sfxSoundArray, x => x.name == name);

        if (soundArray == null)
        {
            Debug.Log("Sound not found or is null");
        }
        else
        {
            int i;
            i = Random.Range(0, soundArray.clip.Length);

            sfxSource.PlayOneShot(soundArray.clip[i]);
        }
    }

    public void PlaySFXArrayAt(string name, int index)
    {
        SoundArray soundArray = Array.Find(sfxSoundArray, x => x.name == name);

        if (soundArray == null)
        {
            Debug.Log("Sound not found or is null");
        }
        else
        {
            sfxSource.PlayOneShot(soundArray.clip[index]);
        }
    }

    IEnumerator playMusic(){
        while (true)
        {
            int polyrytmePlaytime = 229;
            int harpeskifterPlaytime = 245;

            int whichSong = Random.Range(0, 2);
            if (whichSong == 0)
            {
                PlayMusic("Polyrytme");
                AudioManager.Instance.GetComponent<AudioSource>().volume = 0.08f;
                yield return new WaitForSeconds(polyrytmePlaytime);
            } 
            else if (whichSong == 1)
            {
                PlayMusic("Harpeskifter");
                AudioManager.Instance.GetComponent<AudioSource>().volume = 0.04f;
                yield return new WaitForSeconds(harpeskifterPlaytime);
            }
        }
    }

}