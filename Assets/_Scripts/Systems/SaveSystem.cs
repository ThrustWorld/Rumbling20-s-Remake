using UnityEngine;

public interface ISaveable // Saving/Loading
{
    void Save(SaveSystem data);
    void Load(SaveSystem data);
}

[System.Serializable]
public class SaveSystem : Singleton<SaveSystem>
{
    // Data 
    public int HighScore;
    public int Resolution;
    public int Quality;
    public int TextureQuality;
    public float MainVolume;
    public bool Fullscreen;


    public string ToJson()
    {
        // Data converted to Json
        return JsonUtility.ToJson(this);
    }

    public void LoadFromJson(string json)
    {
        // Taking data from the .json
        JsonUtility.FromJsonOverwrite(json,this);
    }
}
