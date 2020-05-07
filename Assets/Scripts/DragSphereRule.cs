using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragSphereRule : MonoBehaviour {
	public enum WorldModeState
	{
		choseCountry,
		sureEnterCountry,
        moveEnterCountry,
	}
    private GameObject UIRoot;
	public WorldModeState worldState = WorldModeState.choseCountry;
	public float rotateSpeed = 0;
	private SphereCollider collider;
	private TweenRotation tr;
	private GameObject camera;
	private GameObject placesContain;
    public GameObject SkyBoxCamera;
    // Use this for initialization
    void Start () {
        UIRoot = GameObject.FindWithTag("UIRoot");
        camera = GameObject.FindWithTag("MainCamera");
		tr = gameObject.transform.GetComponent<TweenRotation>();
		collider = gameObject.GetComponent<SphereCollider>();
		placesContain = gameObject.transform.Find("placesContain").gameObject;
        

    }


    private void ShowPlaceMapPanel()
    {
        GameObject panel = UIRoot.transform.Find("PlaceMapPanel").gameObject;
        panel.SetActive(true);
        Camera mapCamera = GameObject.FindWithTag("PlaceMapCamera").GetComponent<Camera>();
        CameraManager.instance.LerpCameraViewSize(mapCamera, 1.2f, 1.0f, 0.2f);
        gameObject.SetActive(false);
    }

	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 10, 1 << LayerMask.NameToLayer("Countries")))
        {
            Debug.DrawLine(ray.origin, hitInfo.point);
            if (hitInfo.collider.name == "0")
            {
                if (Input.GetMouseButtonUp(0))
                {
                    if(worldState== WorldModeState.sureEnterCountry)
                    {
                        CameraManager.instance.LerpCameraFileOfView(Camera.main, Camera.main.fieldOfView, 21.6f,0.2f);
                        CameraManager.instance.OnLerpFished.Add(new EventDelegate(ShowPlaceMapPanel));
                        HoverPanel.CloseDesLabel();
                    }
                    if(worldState == WorldModeState.choseCountry)
                    {
                        tr.enabled = true;
                        tr.duration = 0.5f;
                        Vector3 fromVec = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
                        if (fromVec.z > 180)
                        {
                            fromVec.z = fromVec.z - 360;
                        }
                        if (fromVec.y > 180)
                        {
                            fromVec.y = fromVec.y - 360;
                        }

                        if (fromVec.x > 180)
                        {
                            fromVec.x = fromVec.x - 360;
                        }
                        tr.from = fromVec;
                        tr.to = new Vector3(-15.5f, 144.6f, -30f);
                        tr.delay = 0;
                        tr.onFinished.Clear();
                        tr.ResetToBeginning();
                        worldState = WorldModeState.sureEnterCountry;
                        HoverPanel.ShowDesLabel(CountryDataManager.Intance.GetDataById(0));
                    }
                   
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (worldState == WorldModeState.sureEnterCountry)
                {
                    HoverPanel.CloseDesLabel();
                    worldState = WorldModeState.choseCountry;
                }
            }
        }
    }


    #region
	void CameraMoveToDraem()
	{
		TweenPosition tp = camera.GetComponent<TweenPosition>();
		tp.enabled = true;
		tp.from = tp.gameObject.transform.position;
		tp.to = new Vector3(4.08f, 1.07f, -0.38f);
		tp.duration = 0.5f;
		tp.onFinished.Clear();
		tp.onFinished.Add(new EventDelegate(OnMoveToDreamFished));
		tp.ResetToBeginning();
	}

	void OnMoveToDreamFished()
	{	
		GameObject place = placesContain.transform.Find("Dream").Find("0").gameObject;
		place.gameObject.SetActive(true);
		TweenScale ts = place.GetComponent<TweenScale>();
		ts.enabled = true;
		ts.from = new Vector3(0, 0, 0);
		ts.to = new Vector3(0.1f, 0.1f, 0.1f);
		ts.duration = 0.3f;
		ts.delay = 0;
		ts.ResetToBeginning();
	}

	#endregion

	private bool IsChoseCountry()
	{
		if(worldState == WorldModeState.choseCountry)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	private IEnumerator OnMouseDown()
	{
		if (worldState != WorldModeState.choseCountry)
		{
			yield return new WaitWhile(IsChoseCountry) ;
		}
		Vector3 v3 = Input.mousePosition;//开始前记录鼠标点下的位置
		while (Input.GetMouseButton(0))
		{
			//float f = Input.mousePosition.x - v3.x;//记录鼠标水平移动的量
			Vector3 rotateVec = Input.mousePosition - v3;
			rotateVec = -rotateVec;
            transform.Rotate(0, rotateVec.x * rotateSpeed, -rotateVec.y * rotateSpeed, Space.World);//旋转
            SkyBoxCamera.transform.Rotate(0, rotateVec.x * rotateSpeed, -rotateVec.y * rotateSpeed, Space.World);
            v3 = Input.mousePosition;//再次记录
			yield return 0;
		}
	}


}
