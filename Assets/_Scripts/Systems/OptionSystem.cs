using UnityEngine;
using System.Collections.Generic;

public class OptionSystem : Singleton<OptionSystem>
{
    Resolution[] resolutions;
    public void GetResolutions(List<string> resolutionsList, TMPro.TMP_Dropdown dropDown)
    {
        int currentResolution = default;

        resolutionsList = new List<string>();

        dropDown.ClearOptions();

        resolutions = Screen.resolutions;
        for (int i = 0; i < this.resolutions.Length; i++)
        {
            string resolution = resolutions[i].width + " x " + resolutions[i].height + " " + this.resolutions[i].refreshRate + "Hz";
            resolutionsList.Add(resolution);

            if(resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolution = i;
            }
        }

        dropDown.AddOptions(resolutionsList);
        dropDown.value = currentResolution;
        dropDown.RefreshShownValue();
    }

    public void SetResolution(TMPro.TMP_Dropdown dropDown, int index)
    {
        index = GetResolution(dropDown);
        Resolution currentResolution = resolutions[index];
        Screen.SetResolution(currentResolution.width,currentResolution.height,Screen.fullScreen);
    }
    
    public void SetFullscreen(UnityEngine.UI.Toggle toggle, bool isFullscreen)
    {
        isFullscreen = GetFullscreen(toggle);
        Screen.fullScreen = isFullscreen;
    }

    public void SetTextureQuality(TMPro.TMP_Dropdown dropDown, int index)
    {
        index = GetTextureQuality(dropDown);
        QualitySettings.masterTextureLimit = index;
    }

    public void SetQuality(TMPro.TMP_Dropdown dropDown, int index)
    {
        index = GetQuality(dropDown);
        QualitySettings.SetQualityLevel(index);
    }

    public int GetResolution(TMPro.TMP_Dropdown dropDown)
    {
        int index = dropDown.value; 
        return index;
    }

    public int GetTextureQuality(TMPro.TMP_Dropdown dropDown)
    {
        int index = dropDown.value; 
        return index;
    }

    public int GetQuality(TMPro.TMP_Dropdown dropDown)
    {
        int index = dropDown.value; 
        return index;
    }
    public bool GetFullscreen(UnityEngine.UI.Toggle toggle)
    {
        bool isFullscreen = toggle.isOn;
        return isFullscreen;
    }
}
