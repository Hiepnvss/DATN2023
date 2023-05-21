using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class ClearData : Editor
{
    [MenuItem("TooltipAttribute/ClearData")]
    public static void ClearDataUserLevel()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }
}