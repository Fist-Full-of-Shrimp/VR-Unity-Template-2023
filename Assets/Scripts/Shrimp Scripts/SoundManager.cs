using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioMixer audioMixer;
    public string masterVolumeParameter = "masterVolume";
    public string musicVolumeParameter = "musicVolume";
    public string sfxVolumeParameter = "sfxVolume";

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        LoadVolumeSettings();
    }
    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat(masterVolumeParameter, volume);
        SaveVolumeSettings();
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat(musicVolumeParameter, volume);
        SaveVolumeSettings();
    }

    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat(sfxVolumeParameter, volume);
        SaveVolumeSettings();
    }

    private void SaveVolumeSettings()
    {
        float value;
        if(audioMixer.GetFloat(masterVolumeParameter, out value))
        {
            PlayerPrefs.SetFloat(masterVolumeParameter, value);
        }
        if (audioMixer.GetFloat(musicVolumeParameter, out value))
        {
            PlayerPrefs.SetFloat(musicVolumeParameter, value);
        }
        if (audioMixer.GetFloat(sfxVolumeParameter, out value))
        {
            PlayerPrefs.SetFloat(sfxVolumeParameter, value);
        }
    }

    private void LoadVolumeSettings()
    {
        if (PlayerPrefs.HasKey(masterVolumeParameter))
        {
            float masterVolume = PlayerPrefs.GetFloat(masterVolumeParameter);
            audioMixer.SetFloat(masterVolumeParameter, masterVolume);
        }

        if (PlayerPrefs.HasKey(musicVolumeParameter))
        {
            float musicVolume = PlayerPrefs.GetFloat(musicVolumeParameter);
            audioMixer.SetFloat(musicVolumeParameter, musicVolume);
        }

        if (PlayerPrefs.HasKey(sfxVolumeParameter))
        {
            float sfxVolume = PlayerPrefs.GetFloat(sfxVolumeParameter);
            audioMixer.SetFloat(sfxVolumeParameter, sfxVolume);
        }
    }


}
