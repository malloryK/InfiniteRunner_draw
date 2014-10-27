using UnityEngine;
using System.Collections;

public class trailOnClick : MonoBehaviour {

	public GameObject circle;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 mousePos = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10f));
		circle.transform.position = new Vector3 (mousePos.x, mousePos.y, circle.transform.position.z);
	
		if (Input.GetMouseButton (0)) {
			this.transform.position = new Vector3 (mousePos.x, mousePos.y, circle.transform.position.z);
		}
	}
}