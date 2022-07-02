using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;


public class OptionsManager : Singleton<OptionsManager>
{
    public TMP_Dropdown ResolutionsDropDown;
    public TMP_Dropdown QualityDropDown;
    public TMP_Dropdown QualityTextureDropDown;
    public Toggle FullscreenToggle;
    private List<string> resolutionsList;
    
    void Start()
    {
        OptionSystem.Instance.GetResolutions(resolutionsList,ResolutionsDropDown);
    }

    public void Save()
    {
        SaveSystem.Instance.SaveToJSON();
    }
}
