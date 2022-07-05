using UnityEngine;
using System.Collections.Generic;

public class OptionSystem : Singleton<OptionSystem>
{
    Resolution[] resolutions; 
    public void GetResolutions(List<string> resolutionsList, TMPro.TMP_Dropdown dropDown)
    {
        int currentResolution = default;

        resolutionsList = new List<string>();

        dropDown.ClearOptions(); // Empty

        resolutions = Screen.resolutions;// All supported resolutions
        for (int i = 0; i < this.resolutions.Length; i++)
        {
            string resolution = resolutions[i].width + " x " + resolutions[i].height + " " + this.resolutions[i].refreshRate + "Hz"; // Taking resolution data individually
            resolutionsList.Add(resolution); // Add each supported resolution

            if(resolutions[i].width == Screen.width && resolutions[i].height == Screen.height) // Check the screen resolution
            {
                currentResolution = i;
            }
        }

        dropDown.AddOptions(resolutionsList); // Add the resolutions to the dropDown list
        dropDown.value = currentResolution; // Main resolution
        dropDown.RefreshShownValue();
    }

    public void SetResolution(TMPro.TMP_Dropdown dropDown, int index)
    {
        index = GetIndex(dropDown); // Resolution based on the dropDown menu value
        Resolution currentResolution = resolutions[index];  
        Screen.SetResolution(currentResolution.width,currentResolution.height,Screen.fullScreen); // Apply resolution
    }
    

    public void SetTextureQuality(TMPro.TMP_Dropdown dropDown, int index)
    {
        index = GetIndex(dropDown); // Texture quality based on the dropDown menu value
        QualitySettings.masterTextureLimit = index; // Apply texture quality
    }

    public void SetQuality(TMPro.TMP_Dropdown dropDown, int index)
    {
        index = GetIndex(dropDown); // Quality based on the dropDown menu value
        QualitySettings.SetQualityLevel(index); // Apply quality
    }
    
    public void SetFullscreen(UnityEngine.UI.Toggle toggle, bool isFullscreen)
    {
        isFullscreen = GetFullscreen(toggle); // Fullscreen based on the toggle value
        Screen.fullScreen = isFullscreen; // Apply fullscreen
    }

    public void SetMixerVolume(UnityEngine.Audio.AudioMixerGroup mixer,UnityEngine.UI.Slider slider, float value)
    {
        value = GetVolume(slider); // Volume based on the slider value
        slider.value = value;
        mixer.audioMixer.SetFloat("Main Volume", slider.value); // Apply mixer volume
    }
    public int GetIndex(TMPro.TMP_Dropdown dropDown)
    {
        int index = dropDown.value; 
        return index;
    }
    public bool GetFullscreen(UnityEngine.UI.Toggle toggle)
    {
        bool isFullscreen = toggle.isOn;
        return isFullscreen;
    }

    public float GetVolume(UnityEngine.UI.Slider slider)
    {
        float value = slider.value;
        return value;
    }
}
