using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDataManager
{
    private static NPCDataManager _instance;
    public static NPCDataManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new NPCDataManager();
            }
            return _instance;
        }
    }

    private Dictionary<int, NPCData> NPCDataDic = new Dictionary<int, NPCData>();


    private void Init()
    {
        NPCData data0 = new NPCData();
        data0.id = 0;
        data0.iconType = NPCData.IconType.characer;

        NPCDataDic.Add(data0.id, data0);
    }

    public NPCData GetDataById(int id)
    {
        NPCData data = null;
        if (!NPCDataDic.TryGetValue(id, out data))
        {
            Debug.LogError("id is null" + id);
        }
        return data;
    }


}
