 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceMapPanel : MonoBehaviour {
    public enum PlaceChoseState
    {
        mapState,
        choseCityState,
    }

    private UISprite mapSprite;
    private int currentCountryId;
    private int currentPlaceId;
    private PlaceChoseState state = PlaceChoseState.mapState;
    private Camera uiCamera;
    private GameObject root;
    void Start () {
        root = transform.parent.gameObject;
        uiCamera = GameObject.FindWithTag("PlaceMapCamera").GetComponent<Camera>();
        mapSprite = transform.Find("map").GetComponent<UISprite>();
        for (int i = 0; i < mapSprite.transform.childCount; i++)
        {
            UIButton btn = mapSprite.transform.GetChild(i).GetComponent<UIButton>();
            btn.onClick.Add(new EventDelegate(OnPlaceBtnClick));
        }
	}

    void Update()
    {
        Ray ray = uiCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 300, 1 << LayerMask.NameToLayer("Place")))
        {
            Debug.DrawLine(ray.origin, hitInfo.point);

            if (Input.GetMouseButtonUp(0))
            {
                if (hitInfo.collider.gameObject.name == "map")
                {
                    if(state == PlaceChoseState.choseCityState)
                    {
                        HoverPanel.CloseDesLabel();
                        state = PlaceChoseState.mapState;
                    }
                }
            }
        }
    }


    private void MoveToMoLiAnCity()
    {
        GameObject panel = root.transform.Find("MoLiAnPanel").gameObject;
        panel.gameObject.SetActive(true);
        Camera cityCamera = GameObject.FindWithTag("CityMapCamera").GetComponent<Camera>();
        CameraManager.instance.LerpCameraViewSize(cityCamera, 1.2f, 1, 0.25f);
    }
    private void OnPlaceBtnClick()
    {
        if(state == PlaceChoseState.choseCityState)
        {
            CameraManager.instance.LerpCameraViewSize(uiCamera, uiCamera.orthographicSize, 0.8f, 0.25f);
            CameraManager.instance.OnLerpFished.Add(new EventDelegate(MoveToMoLiAnCity));
            HoverPanel.CloseDesLabel();
        }
        if(state== PlaceChoseState.mapState)
        {
            Vector3 cameraMovePos = UIButton.current.transform.localPosition + UIButton.current.transform.parent.localPosition;
            cameraMovePos.z = uiCamera.transform.localPosition.z;
            TweenPosition tp = uiCamera.GetComponent<TweenPosition>();
            tp.enabled = true;
            tp.from = tp.transform.localPosition;
            tp.to = cameraMovePos;
            tp.duration = 0.25f;
            tp.ResetToBeginning();
            //CameraManager.instance.LerpCameraViewSize(uiCamera, uiCamera.orthographicSize, 0.6f, 0.3f);
            int id = CommonHelper.Str2Int(UIButton.current.gameObject.name);
            currentPlaceId = id;
            HoverPanel.ShowDesLabel(PlaceDataManager.Instance.GetDataById(id));
            state = PlaceChoseState.choseCityState;
        }

       
    }
}
