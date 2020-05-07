using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityPlaceManager 
{
    private static CityPlaceManager _instance;
    public static CityPlaceManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new CityPlaceManager();
                _instance.Init();
            }
                return _instance;
            
        }
    }

    private Dictionary<int, CityPlaceData> CityPlaceDataDic = new Dictionary<int, CityPlaceData>();


    private void Init()
    {
        CityPlaceData data0 = new CityPlaceData();
        data0.id = 0;
        data0.name = "爽了酒馆";
        data0.des = "爽了";
        CityPlaceDataDic.Add(data0.id, data0);
    }

    public CityPlaceData GetDataById(int id)
    {
        CityPlaceData data = null;
        if (!CityPlaceDataDic.TryGetValue(id, out data))
        {
            Debug.LogError("id is null" + id);
        }
        return data;
    }
}
