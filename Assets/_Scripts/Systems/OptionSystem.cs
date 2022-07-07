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

    public void SetResolution(int index)
    {
        Resolution currentResolution = resolutions[index];  
        Screen.SetResolution(currentResolution.width,currentResolution.height,Screen.fullScreen); // Apply resolution
    }
    

    public void SetTextureQuality(int index)
    {
        QualitySettings.masterTextureLimit = index; // Apply texture quality
    }

    public void SetQuality(int index)
    {
        QualitySettings.SetQualityLevel(index); // Apply quality
    }
    
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen; // Apply fullscreen
    }

    public void SetMixerVolume(UnityEngine.Audio.AudioMixerGroup mixer,string name, float value)
    {
        mixer.audioMixer.SetFloat(name, value); // Apply mixer volume
    }
}
