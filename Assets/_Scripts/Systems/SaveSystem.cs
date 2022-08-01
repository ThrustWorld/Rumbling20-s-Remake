using UnityEngine;

public interface ISaveable // Saving/Loading
{
    void Save(SaveSystem data);
    void Load(SaveSystem data);
}

[System.Serializable]
public class PlayerScore
{
    public float HighScore;
    public float FinalScore;
}

[System.Serializable]
public class Settings
{
    public int Resolution;
    public int Quality;
    public int TextureQuality;
    public float MasterVolume;
    public float MusicVolume;
    public float EffectsVolume;
    public bool Fullscreen;

}
[System.Serializable]
public class SaveSystem : Singleton<SaveSystem>
{
    public Settings Settings;
    public PlayerScore Score;
    public string ToJson(object obj)
    {
        // Data converted to Json
        return JsonUtility.ToJson(obj,true);
    }

    public void LoadFromJson(string json, object obj)
    {
        // Taking data from the .json
        JsonUtility.FromJsonOverwrite(json,obj);
    }
}
