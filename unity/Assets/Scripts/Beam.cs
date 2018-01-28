using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour {

	Vector3 startPoint = Vector3.zero;
	Vector3 endPoint = Vector3.zero;
	GameObject particleStopper;

	// Use this for initialization
	void Start () {
		particleStopper = gameObject.transform.GetChild(0).gameObject;
		UpdateBeam(startPoint, endPoint);
	}

	public void UpdateBeam(Vector3 newStartPoint, Vector3 newEndPoint) {
		startPoint = newStartPoint + Vector3.up*0.1f;
		endPoint = newEndPoint + Vector3.up*0.1f;
		transform.position = startPoint;
		transform.rotation = Quaternion.LookRotation(endPoint - startPoint);
		if(particleStopper) {
			particleStopper.transform.position = endPoint;
		}
		gameObject.GetComponent<LineRenderer>().SetPositions(new Vector3[] {startPoint, endPoint});
	}

	// Update is called once per frame
	void Update () {
	}
}
