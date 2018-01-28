using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour {

	GameObject[] targets;
	[HideInInspector]
	public bool[] objectInScene;

	public GameObject[] objects;
	[HideInInspector]
	public float[,] distances;

	// Use this for initialization
	void Start () {
		distances = new float[objects.Length, objects.Length];
		objectInScene = new bool[objects.Length];
		targets = new GameObject[objects.Length];
		for(int i = 0; i < objects.Length; i++) {
			targets[i] = objects[i].transform.parent.gameObject;
		}
	}

	// Update is called once per frame
	void Update () {
		for(int i = 0; i < objects.Length; i++) {
			objectInScene[i] = targets[i].GetComponent<DefaultTrackableEventHandler>().tracked;
			for(int j = 0; j < objects.Length; j++) {
				if(objectInScene[i] && objectInScene[j]) {
					distances[i, j] = Vector3.Distance(objects[i].transform.position, objects[j].transform.position);
				} else {
					distances[i, j] = 0;
				}
			}
		}
	}
}
