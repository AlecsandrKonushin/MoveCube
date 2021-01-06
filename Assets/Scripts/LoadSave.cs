using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public static class LoadSave
{
    //public static void Save(string level)
    //{   
    //    string path = Path.Combine(Application.persistentDataPath, "Save.json");

    //    File.WriteAllText(path, JsonUtility.ToJson(level));
    //}

    //public static int Load()
    //{
    //    string path = Path.Combine(Application.persistentDataPath, "Save.json");

    //    if (File.Exists(path))
    //    {
    //        string level = JsonUtility.FromJson<string>(File.ReadAllText(path));
    //        return int.Parse(level);
    //    }
    //    else
    //        return 1;
    //}

    public static void Save(int level)
    {        
        StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/saveGame.ncs");
        sw.WriteLine(level.ToString());
        sw.Close();
    }

    public static int Load()
    {
        if (File.Exists(Application.persistentDataPath + "/saveGame.ncs"))
        {
            StreamReader sr = new StreamReader(Application.persistentDataPath + "/saveGame.ncs");
            int level = int.Parse(sr.ReadLine());
            sr.Close();
            return level;
        }
        else
            return 1;
    }
}
