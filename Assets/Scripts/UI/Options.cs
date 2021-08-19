using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    [SerializeField] Slider musicVolumeSlider, soundVolumeSlider;
    float musicVolume, soundVolume;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            musicVolume = PlayerPrefs.GetFloat("MusicVolume");
            musicVolumeSlider.value = musicVolume;
        }
        else
        {
            musicVolume = 0.5f;
        }
        if (PlayerPrefs.HasKey("SoundVolume"))
        {
            soundVolume = PlayerPrefs.GetFloat("SoundVolume");
            soundVolumeSlider.value = soundVolume;
        }
        else
        {
            soundVolume = 0.5f;
        }
    }
    private void OnDisable()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        PlayerPrefs.SetFloat("SoundVolume", soundVolume);
    }

    public void ResetRecord()
    {
        PlayerPrefs.SetInt("Record", 0);
    }

    public void SetMusicVolume(float volume)
    {
        musicVolume = volume;
        AudioManager.instance.SetMusicVolume(volume);
    }

    public void SetSoundVolume(float volume)
    {
        soundVolume = volume;
        AudioManager.instance.SetSoundVolume(volume);
    }
}
