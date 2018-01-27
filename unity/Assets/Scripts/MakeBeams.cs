using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBeams : MonoBehaviour {

	float[,] distances;
	public GameObject beamPrefab;
	public float maxBeamDistance;
	private GameObject[,] beams;
	private GameObject[] objects;

	// Use this for initialization
	void Start () {
		GameObject main = GameObject.Find("Main");
		ObjectDistanceCalculator odc = main.GetComponent<ObjectDistanceCalculator>();
		distances = odc.distances;
		beams = new GameObject[distances.GetLength(0), distances.GetLength(1)];
		objects = odc.objects;
	}

	// Update is called once per frame
	void Update () {
		for(int i = 0; i < distances.GetLength(0); i++) {
			for(int j = 0; j < distances.GetLength(1); j++) {
				if(distances[i, j] != null && distances[i, j] > 0 && distances[i, j] < maxBeamDistance){
					if(beams[i, j] == null) {
						beams[i, j] = Instantiate(beamPrefab, transform);
					}
					beams[i, j].GetComponent<LineRenderer>().SetPositions(new Vector3[] {objects[i].transform.position, objects[j].transform.position});
				} else if (beams[i, j] != null) {
					Destroy(beams[i, j]);
				}
			}
		}
	}
}
