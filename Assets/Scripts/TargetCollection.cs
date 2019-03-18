using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TargetCollection 
{
    [SerializeField]
    List<DataTarget> targetList;

    public TargetCollection()
    {
        targetList = new List<DataTarget>();
    }

    public void addTarget(DataTarget target)
    {
        targetList.Add(target);
    }

    public DataTarget buscarTarget(string pTargetName)
    {
        return targetList.Find(x => x.targetName == pTargetName);
    }

    public string SaveToString()
    {
        return JsonUtility.ToJson(this);
    }
}
