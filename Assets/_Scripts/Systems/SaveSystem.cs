using UnityEngine;

public class SaveSystem : Singleton<SaveSystem>
{
    public void SaveToJSON()
    {
        OptionSystem.Instance.SetResolution(OptionsManager.Instance.ResolutionsDropDown, OptionsManager.Instance.ResolutionsDropDown.value);
        OptionSystem.Instance.SetFullscreen(OptionsManager.Instance.FullscreenToggle,OptionsManager.Instance.FullscreenToggle.isOn);
        OptionSystem.Instance.SetQuality(OptionsManager.Instance.QualityDropDown,OptionsManager.Instance.QualityDropDown.value);
        OptionSystem.Instance.SetTextureQuality(OptionsManager.Instance.QualityTextureDropDown,OptionsManager.Instance.QualityTextureDropDown.value);
    }
}
