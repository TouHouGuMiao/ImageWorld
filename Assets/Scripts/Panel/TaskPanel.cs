using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskPanel : MonoBehaviour {
	private static UISprite npcIcon;
	private static UILabel weiTuoRenNameLabel;
	private static UILabel taskDesLabel;
	private static UILabel drawDesLabel;
	private static UILabel timeLabel;
	private static UILabel taskGiftLabel;
	private static UILabel specicalGiftLabel;
	private static GameObject panel;
	// Use this for initialization
	void Start () {
		npcIcon = transform.FindRecursively("npcIcon").GetComponent<UISprite>();
		weiTuoRenNameLabel = transform.FindRecursively("weiTuoRenName").GetComponent<UILabel>();
		taskDesLabel = transform.FindRecursively("taskDes").GetComponent<UILabel>();
		drawDesLabel = transform.FindRecursively("drawDes").GetComponent<UILabel>();
		timeLabel = transform.FindRecursively("time").GetComponent<UILabel>();
		taskGiftLabel = transform.FindRecursively("taskGift").GetComponent<UILabel>();
		specicalGiftLabel = transform.FindRecursively("specicalGift").GetComponent<UILabel>();
		panel = transform.gameObject;
	}
	

	public static void ShowTaksPanel(int taskId)
	{
		panel.SetActive(true);
		TaskData data = TaskManager.instance.GetDataById(taskId);
		npcIcon.spriteName = data.taskSpriteName;
		weiTuoRenNameLabel.text = data.peopleName;
		taskDesLabel.text = data.taskDes;
		drawDesLabel.text = data.drawDes;
		timeLabel.text = data.time.ToString();
		taskGiftLabel.text = data.completMoney.ToString();
		specicalGiftLabel.text = data.speicalGift.ToString();
	}

	// Update is called once per frame
	void Update () {
		
	}
}
