using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {
    public static CameraManager instance;

    public List<EventDelegate> OnLerpFished = new List<EventDelegate>();
    public void LerpCameraViewSize(Camera camera, float min, float max, float time)
    {
        StartCoroutine(LerpCameraViewSizeIEnumerator(camera, min, max, time));
    }

    IEnumerator LerpCameraViewSizeIEnumerator(Camera camera, float min, float max, float time)
    {
        int count = (int)(time / 0.01f);
        float lerpTemp = 0;
        for (int i = 0; i < count; i++)
        {
            camera.orthographicSize = Mathf.Lerp(min, max, lerpTemp);
            yield return new WaitForSeconds(0.01f);
            lerpTemp += (1.0f / count);
        }
        EventDelegate.Execute(OnLerpFished);
        OnLerpFished.Clear();
    }







    public void LerpCameraFileOfView(Camera camera, float min, float max, float time)
    {
        StartCoroutine(LerpCameraFileOfViewIEnumerator(camera, min, max, time));
    }

    IEnumerator LerpCameraFileOfViewIEnumerator(Camera camera, float min, float max, float time)
    {
        int count = (int)(time / 0.01f);
        float lerpTemp = 0;
        for (int i = 0; i < count; i++)
        {
            camera.fieldOfView = Mathf.Lerp(min, max, lerpTemp);
            yield return new WaitForSeconds(0.01f);
            lerpTemp += (1.0f/count);
        }
        EventDelegate.Execute(OnLerpFished);
        OnLerpFished.Clear();
    }







    void Awake()
    {
        instance = this;
    }

    
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
