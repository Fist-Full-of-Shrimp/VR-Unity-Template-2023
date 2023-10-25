using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;
    public TMP_Dropdown turnDropdown;
    public Toggle vignetteToggle;

    private void Awake()
    {
        masterSlider.onValueChanged.AddListener(MasterVolumeChange);
        musicSlider.onValueChanged.AddListener(MusicVolumeChange);
        sfxSlider.onValueChanged.AddListener(SFXVolumeChange);

        turnDropdown.onValueChanged.AddListener(TurnChange);
        vignetteToggle.onValueChanged.AddListener(VignetteChange);
    }

    private void OnDestroy()
    {
        masterSlider.onValueChanged.RemoveListener(MasterVolumeChange);
        musicSlider.onValueChanged.RemoveListener(MusicVolumeChange);
        sfxSlider.onValueChanged.RemoveListener(SFXVolumeChange);

        turnDropdown.onValueChanged.AddListener(TurnChange);
    }
    private void MasterVolumeChange(float volume)
    {
        SoundManager.Instance.SetMasterVolume(volume);
    }
    private void MusicVolumeChange(float volume)
    {
        SoundManager.Instance.SetMusicVolume(volume);
    }
    private void SFXVolumeChange(float volume)
    {
        SoundManager.Instance.SetSFXVolume(volume);
    }
    private void TurnChange(int dropdownValue)
    {
        XRSettingsManager.Instance.setContinuousTurn(dropdownValue);
    }
    private void VignetteChange(bool vignetteValue)
    {
        XRSettingsManager.Instance.setVignette(vignetteValue);
    }
}
