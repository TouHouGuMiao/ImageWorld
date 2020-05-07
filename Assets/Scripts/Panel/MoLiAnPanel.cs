using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoLiAnPanel : MonoBehaviour {
    private Transform placeBtnCon;
	// Use this for initialization
	void Start () {
        placeBtnCon = transform.FindRecursively("placeBtnCon");
        for (int i = 0; i < placeBtnCon.childCount; i++)
        {
            UIButton button = placeBtnCon.transform.GetChild(i).GetComponent<UIButton>();
            button.onClick.Add(new EventDelegate (OnPlaceBtnClick));
            GameObject grid = button.transform.GetChild(0).gameObject;
            for (int j = 0; j < grid.transform.childCount; j++)
            {
                UIButton childBtn = grid.transform.GetChild(i).GetComponent<UIButton>();
                childBtn.onClick.Add(new EventDelegate(OnIconClick));
            }
              
            
        }
    }

	
	// Update is called once per frame
	void Update () {
		
	}

    void OnPlaceBtnClick()
    {
        int id = CommonHelper.Str2Int(UIButton.current.gameObject.name);
        CityPlaceData data = CityPlaceManager.instance.GetDataById(id);
        HoverPanel.ShowDesLabel(data);
        UIGrid grid = UIButton.current.transform.GetChild(0).GetComponent<UIGrid>();
        grid.gameObject.SetActive(true);
        TweenScale ts = grid.GetComponent<TweenScale>();
        ts.enabled = true;
        ts.duration = 0.2f;
        ts.from = Vector3.zero;
        ts.to = Vector3.one;
        ts.ResetToBeginning();
        grid.Reposition();
    }

    void OnIconClick()
    {
        int id = CommonHelper.Str2Int(UIButton.current.gameObject.name);
        TaskData data = TaskManager.instance.GetDataById(id);
        if (!data.isFished)
        {
            TaskPanel.ShowTaksPanel(id);
        }
    }
}
