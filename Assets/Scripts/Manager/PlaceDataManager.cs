using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceDataManager 
{
	private static PlaceDataManager _instance = null;
	public static PlaceDataManager Instance
	{
		get
		{
			if(_instance == null)
			{
				_instance = new PlaceDataManager();
                _instance.Init();
			}
			return _instance;
		}
	}
    private Dictionary<int, PlaceData> PlaceDataDic = new Dictionary<int, PlaceData>();


    private void Init()
    {
        PlaceData data0 = new PlaceData();
        data0.id = 0;
        data0.belongCountryId = 0;
        data0.name = "食尸鬼村落";
        data0.des = "食尸鬼村落描述测试....";
        PlaceDataDic.Add(data0.id, data0);
    }

    public PlaceData GetDataById(int id)
    {
        PlaceData data = null;
        if (!PlaceDataDic.TryGetValue(id, out data))
        {
            Debug.LogError("id is null" + id);
        }
        return data;
    }
}
