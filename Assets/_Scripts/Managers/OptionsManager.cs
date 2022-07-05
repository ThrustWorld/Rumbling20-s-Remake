using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsManager : Singleton<OptionsManager>, ISaveable
{
    public TMP_Dropdown ResolutionsDropDown;
    public TMP_Dropdown QualityDropDown;
    public TMP_Dropdown TextureQualityDropDown;
    public Toggle FullscreenToggle;
    public Slider MainSlider;
    public AudioMixerGroup MainMixer;
    
    private List<string> resolutionsList;
    
    void Start()
    {
        OptionSystem.Instance.GetResolutions(resolutionsList,ResolutionsDropDown);
        UpdateUI();
    }

    public void SaveSettings()
    {   
        // Save
        SaveSystem data = new SaveSystem();
        Save(data);
        if(Helpers.WriteToFile("Settings.txt", data.ToJson())) // Check if the file with saved data has been created
        {
            Debug.Log("Save successful");
            LoadSettings(); // Apply the data
        }
    }

    public void LoadSettings()
    {
        if(Helpers.LoadFromFile("Settings.txt", out var json)) // Check if there's already the file with saved data
        {
            SaveSystem data = new SaveSystem();
            data.LoadFromJson(json); 
            Load(data); // Load the saved datas from the file
            Debug.Log("Load Complete");
        }
    }

    public void Save(SaveSystem data)
    {
        // Saving data
        data.Resolution = ResolutionsDropDown.value;
        data.Quality = QualityDropDown.value;
        data.TextureQuality = TextureQualityDropDown.value;
        data.Fullscreen = FullscreenToggle.isOn;
        data.MainVolume = MainSlider.value;
    }
    
    public void Load(SaveSystem data)
    {
        // Loading data
        OptionSystem.Instance.SetResolution(ResolutionsDropDown,data.Resolution);
        OptionSystem.Instance.SetQuality(QualityDropDown,data.Quality);
        OptionSystem.Instance.SetTextureQuality(TextureQualityDropDown,data.TextureQuality);
        OptionSystem.Instance.SetFullscreen(FullscreenToggle,data.Fullscreen);
        OptionSystem.Instance.SetMixerVolume(MainMixer,MainSlider,data.MainVolume);
    }

    void UpdateUI()
    {
        // Apply the save data to the UI elements
        if(Helpers.LoadFromFile("Settings.dat", out var json))
        {
            SaveSystem data = new SaveSystem();
            data.LoadFromJson(json);
            ResolutionsDropDown.value  = data.Resolution;
            QualityDropDown.value = data.Quality;
            TextureQualityDropDown.value = data.TextureQuality;
            FullscreenToggle.isOn = data.Fullscreen;
            MainSlider.value = data.MainVolume;
        }
    }
}