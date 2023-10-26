using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class XRSettingsManager : MonoBehaviour
{
    public static event Action XRSettingsChange;
    public static XRSettingsManager Instance;

    private bool _continuousTurnActive = false;
    private bool _vignetteActive = false;
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


    //Yeah... I hate this too
    public void setContinuousTurn(int dropdownSetting)
    {
        if(dropdownSetting == 0)
        {
            _continuousTurnActive = false;
        }
        else
        {
            _continuousTurnActive = true;
        }
        XRSettingsChange?.Invoke();
    }

    public void setVignette(bool vignetteValue)
    {
        _vignetteActive = vignetteValue;
        XRSettingsChange?.Invoke();
    }
    public bool isContinuousTurnActive()
    {
        return _continuousTurnActive;
    }
    public bool isVignetteActive()
    {
        return _vignetteActive;
    }
}
