using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Target : DefaultTrackableEventHandler {

	private ObjectManager objectManager;
	[HideInInspector]
	public int index = 0;

	// Use this for initialization
	protected override void Start () {
		base.Start();
		GameObject main = GameObject.Find("Main");
		objectManager = main.GetComponent<ObjectManager>();
	}

	// Update is called once per frame
	void Update () {

	}

	public override void OnTrackableStateChanged (TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus) {
		base.OnTrackableStateChanged(previousStatus, newStatus);
		if(objectManager) switch(newStatus) {
			case TrackableBehaviour.Status.LIMITED:
			case TrackableBehaviour.Status.TRACKED:
			case TrackableBehaviour.Status.EXTENDED_TRACKED:
				objectManager.UpdateDistances(index, true);
				break;
			default:
				objectManager.UpdateDistances(index, false);
				break;
		}
	}

}
