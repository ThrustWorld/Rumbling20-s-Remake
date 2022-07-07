using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsManager : Singleton<OptionsManager>, ISaveable
{
    // Dropdowns
    public TMP_Dropdown ResolutionsDropDown;
    public TMP_Dropdown QualityDropDown;
    public TMP_Dropdown TextureQualityDropDown;
    
    public Toggle FullscreenToggle;
    
    // Volumes
    public Slider MasterSlider;
    public Slider MusicSlider;
    public Slider EffectsSlider;
    
    // Mixers
    public AudioMixerGroup MasterMixer;
    public AudioMixerGroup MusicMixer;
    public AudioMixerGroup EffectsMixer;

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
        data.Settings = new Settings();
        Save(data);
        if(Helpers.WriteToFile("Settings.json", data.ToJson(data.Settings))) // Check if the file has been
        {
            Debug.Log("Save successful");
            LoadSettings(); // Apply the data
        }
    }

    public void Save(SaveSystem data)
    {
        // Saving data
        data.Settings.Resolution = ResolutionsDropDown.value;
        data.Settings.Quality = QualityDropDown.value;
        data.Settings.TextureQuality = TextureQualityDropDown.value;
        data.Settings.Fullscreen = FullscreenToggle.isOn;
        data.Settings.MasterVolume = MasterSlider.value;
        data.Settings.MusicVolume = MusicSlider.value;
        data.Settings.EffectsVolume = EffectsSlider.value;
    }
    
    public void LoadSettings()
    {
        if(Helpers.LoadFromFile("Settings.json", out var json)) // Check if there's already the file with saved data
        {
            SaveSystem data = new SaveSystem();
            data.Settings = new Settings();
            data.LoadFromJson(json,data.Settings);
            Load(data); // Load the saved datas from the file
            Debug.Log("Load Complete");
        }
    }
    
    public void Load(SaveSystem data)
    {
        // Loading data
        OptionSystem.Instance.SetResolution(data.Settings.Resolution);
        OptionSystem.Instance.SetQuality(data.Settings.Quality);
        OptionSystem.Instance.SetTextureQuality(data.Settings.TextureQuality);
        OptionSystem.Instance.SetFullscreen(data.Settings.Fullscreen);
        OptionSystem.Instance.SetMixerVolume(MasterMixer,"MasterVolume",data.Settings.MasterVolume);
        OptionSystem.Instance.SetMixerVolume(MusicMixer,"MusicVolume",data.Settings.MusicVolume);
        OptionSystem.Instance.SetMixerVolume(EffectsMixer,"EffectsVolume",data.Settings.EffectsVolume);
    }

    void UpdateUI()
    {
        // Apply the save data to the UI elements
        if(Helpers.LoadFromFile("Settings.json", out var json))
        {
            SaveSystem data = new SaveSystem();
            data.Settings = new Settings();
            data.LoadFromJson(json,data.Settings);
            ResolutionsDropDown.value  = data.Settings.Resolution;
            QualityDropDown.value = data.Settings.Quality;
            TextureQualityDropDown.value = data.Settings.TextureQuality;
            FullscreenToggle.isOn = data.Settings.Fullscreen;
            MasterSlider.value = data.Settings.MasterVolume;
            MusicSlider.value = data.Settings.MusicVolume;
            EffectsSlider.value = data.Settings.EffectsVolume;
        }
    }
}