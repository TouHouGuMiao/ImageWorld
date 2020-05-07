using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverPanel : MonoBehaviour {
	private static  UILabel desLabel;
	private static  UILabel nameLabel;
	private static GameObject bg;
    private static TweenPosition bgTp;
 
	// Use this for initialization
	void Start () {
		desLabel = transform.FindRecursively("desLabel").GetComponent<UILabel>();
		nameLabel = transform.FindRecursively("nameLabel").GetComponent<UILabel>();
		bg = transform.FindRecursively("bg").gameObject;
        bgTp = bg.GetComponent<TweenPosition>();
      
    }

    // Update is called once per frame
    void Update()
    {
      
    }
	
	public static void ShowDesLabel(CountryData data)
	{
		desLabel.text = data.des;
		nameLabel.text = data.name;
		bg.gameObject.SetActive(true);
		desLabel.gameObject.SetActive(true);
		nameLabel.gameObject.SetActive(true);
        bgTp.enabled = true;
        bgTp.from = new Vector3(0, -452, 0);
        bgTp.to = new Vector3(0, -266, 0);
        bgTp.duration = 0.3f;
        bgTp.ResetToBeginning();

    }

	public static void ShowDesLabel(PlaceData data)
	{
		desLabel.text = data.des;
		nameLabel.text = data.name;
		bg.gameObject.SetActive(true);
		desLabel.gameObject.SetActive(true);
		nameLabel.gameObject.SetActive(true);
        bgTp.enabled = true;
        bgTp.from = new Vector3(0, -452, 0);
        bgTp.to = new Vector3(0, -266, 0);
        bgTp.duration = 0.3f;
        bgTp.ResetToBeginning();
    }

    public static void ShowDesLabel(CityPlaceData data)
    {
        desLabel.text = data.des;
        nameLabel.text = data.name;
        bg.gameObject.SetActive(true);
        desLabel.gameObject.SetActive(true);
        nameLabel.gameObject.SetActive(true);
        bgTp.enabled = true;
        bgTp.from = new Vector3(0, -452, 0);
        bgTp.to = new Vector3(0, -266, 0);
        bgTp.duration = 0.3f;
        bgTp.ResetToBeginning();
    }



    public static void CloseDesLabel()
	{
        bgTp.enabled = true;
        bgTp.to = new Vector3(0, -452, 0);
        bgTp.from = new Vector3(0, -266, 0);
        bgTp.duration = 0.3f;
        bgTp.ResetToBeginning();
    }

}
