using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class UIFunctions : MonoBehaviour {

	private bool flashIsOn = false;

	public void OpenURL(string url) {
		Application.OpenURL(url);
	}

	public void TurnOnFlash() {
		flashIsOn = !flashIsOn;
		CameraDevice.Instance.SetFlashTorchMode(flashIsOn);
	}

}
