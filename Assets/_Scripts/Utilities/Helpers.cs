using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System;

//A static class where to put general helpful methods

public static class Helpers
{
    public static bool WriteToFile(string fileName, string fileContents)
    {
        var fullPath = Path.Combine(Application.persistentDataPath, fileName); // File location

        try
        {
            File.WriteAllText(fullPath, fileContents); // Create .json
            return true;
        }
        catch(Exception e)
        {
            Debug.LogError($"Failed to write to {fullPath} with exception {e} ");
        }
        
        return false;
    }

    public static bool LoadFromFile(string fileName, out string result)
    {
        var fullPath = Path.Combine(Application.persistentDataPath, fileName);

        try
        {
            result = File.ReadAllText(fullPath); // Load .json
            return true;
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to read from {fullPath} with exception {e} ");
            result = "";
        }
        return false;
    }
}