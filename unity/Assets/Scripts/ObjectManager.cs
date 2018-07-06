using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

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
			objectInScene[i] = false;
			targets[i] = objects[i].transform.parent.gameObject;
			targets[i].GetComponent<Target>().index = i;
		}
	}

	// Update is called once per frame
	void Update () {

	}

	public void UpdateDistances (int i, bool inScene) {
		objectInScene[i] = inScene;
		if(inScene) {
			for(int j = 0; j < objects.Length; j++) {
				if(objectInScene[j]) {
					distances[i, j] = Vector3.Distance(objects[i].transform.position, objects[j].transform.position);
				} else {
					distances[i, j] = 0;
				}
			}
		} else {
			for(int j = 0; j < objects.Length; j++) {
				distances[i, j] = 0;
			}
		}
	}
}
