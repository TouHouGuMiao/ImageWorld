using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitInfo;
			if (Physics.Raycast(ray, out hitInfo,10,1<<LayerMask.NameToLayer("Countries")))
			{
				Debug.DrawLine(ray.origin, hitInfo.point);
				if (hitInfo.collider.name == "dream")
				{
					
				}
			}
		}
	
	}

}
