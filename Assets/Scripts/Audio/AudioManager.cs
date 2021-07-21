using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Stores audio clips that can be called from other scripts
public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource musicAudioSource;
    [SerializeField] AudioSource musicAudioSource2;
    public AudioClip levelCompletedMusic, ambienceSound, roundStart1, roundStart2, menuMusic1, menuMusic2,
    //endMusic, unlockMusic, endRoundMusic, 
    jumpSound, turnSound, fallDeathSound, portalSound, clickSound, crushDeathSound, spikeDeathSound,
    fall2DeathSound, openDoorSound, closeDoorSound, orbSound;
    [SerializeField] float minPitch, maxPitch;
    public static AudioManager instance;

    void Awake()
    {
        instance = this;

        if (PlayerPrefs.HasKey("MusicVolume"))
            SetMusicVolume(PlayerPrefs.GetFloat("MusicVolume"));
        if (PlayerPrefs.HasKey("SoundVolume"))
            SetSoundVolume(PlayerPrefs.GetFloat("SoundVolume"));
    }
    public void PlayLevelcompletedMusic()
    {
        musicAudioSource.Stop();
        musicAudioSource2.Stop();
        musicAudioSource.pitch = 1;
        musicAudioSource.PlayOneShot(levelCompletedMusic);
    }
    public void PauseMusic()
    {
        musicAudioSource.Pause();
        musicAudioSource2.Pause();
    }
    public void UnpauseMusic()
    {
        musicAudioSource.UnPause();
        musicAudioSource2.UnPause();
    }
    public void PlaySound(AudioClip clipToPlay)
    {
        audioSource.pitch = Random.Range(minPitch, maxPitch);
        audioSource.PlayOneShot(clipToPlay);
    }
    public void SetMusicVolume(float volume)
    {
        musicAudioSource.volume = volume;
        musicAudioSource2.volume = volume;
    }
    public void SetSoundVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
