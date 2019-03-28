using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataTarget
{

    public string targetName;
    public string titulo;
    public string historia;
    public string tesis;
    public string demos;

    public string SaveToString()
    {
        return JsonUtility.ToJson(this);
    }

}
