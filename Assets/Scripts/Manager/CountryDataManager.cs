using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountryDataManager 
{
    private static CountryDataManager _intance = null;
    public static CountryDataManager Intance
    {
        get
        {
            if (_intance == null)
            {
                _intance = new CountryDataManager();
                _intance.Init();
            }
            return _intance;
        }
    }

    private Dictionary<int, CountryData> ContryDataDic = new Dictionary<int, CountryData>();


    private void Init()
    {
        CountryData data0 = new CountryData();
        data0.id = 0;
        data0.name = "梦之国卡达斯";
        data0.des = "梦之国卡达斯描述测试....";
        ContryDataDic.Add(data0.id, data0);
    }

    public CountryData GetDataById(int id)
    {
        CountryData data = null;
        if(!ContryDataDic.TryGetValue(id,out data))
        {
            Debug.LogError("id is null" + id);
        }
        return data;
    }

}
