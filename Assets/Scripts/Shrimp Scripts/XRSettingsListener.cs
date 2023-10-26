using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class XRSettingsListener : MonoBehaviour
{
    public TunnelingVignetteController tunnelingVignetteController;
    public ActionBasedControllerManager controllerManager;
    private void Awake()
    {
        XRSettingsManager.XRSettingsChange += UpdateXRSettings;
    }
    private void Start()
    {
        UpdateXRSettings();
    }
    private void OnDestroy()
    {
        XRSettingsManager.XRSettingsChange -= UpdateXRSettings;
    }

    private void UpdateXRSettings()
    {
        if(XRSettingsManager.Instance != null)
        {
            tunnelingVignetteController.gameObject.SetActive(XRSettingsManager.Instance.isVignetteActive());
            controllerManager.smoothTurnEnabled = XRSettingsManager.Instance.isContinuousTurnActive();
        }
        else
        {
            Debug.Log("No XRSettingsManager was found. XR Rig will use default settings");
        }

    }
}
