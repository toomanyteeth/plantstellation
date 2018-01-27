using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDistanceCalculator : MonoBehaviour {

static int NUM_OBJECTS = 7;

public GameObject[] targets = new GameObject[NUM_OBJECTS];
bool[] objectInScene = new bool[NUM_OBJECTS];

public GameObject[] objects = new GameObject[NUM_OBJECTS];
public float[,] distances = new float[NUM_OBJECTS, NUM_OBJECTS];

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		for(int i = 0; i < NUM_OBJECTS; i++) {
			for(int j = 0; j < NUM_OBJECTS; j++) {
				if(objects[i] != null && objects[j] != null){
					distances[i, j] = Vector3.Distance(objects[i].transform.position, objects[j].transform.position);
				}
			}
		}
	}
}
