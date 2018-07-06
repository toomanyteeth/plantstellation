using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour {

	Button button;
	GameObject canvas;

	// Use this for initialization
	void Start () {
    button = this.GetComponent<Button>();
    button.onClick.AddListener(TaskOnClick);
		canvas = GameObject.Find("Canvas");
	}

	void Update () {
		
	}

	// Update is called once per frame
	void TaskOnClick () {
		canvas.SetActive(false);
	}
}
