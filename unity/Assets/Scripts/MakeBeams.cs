using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBeams : MonoBehaviour {

	private ObjectManager objectManager;
	public GameObject beamPrefab;
	public float maxBeamDistance;
	private GameObject[,] beams;

	// Use this for initialization
	void Start () {
		GameObject main = GameObject.Find("Main");
		objectManager = main.GetComponent<ObjectManager>();
		beams = new GameObject[objectManager.distances.GetLength(0), objectManager.distances.GetLength(1)];
	}

	// Update is called once per frame
	void Update () {
		for(int i = 0; i < objectManager.distances.GetLength(0); i++) {
			for(int j = 0; j < objectManager.distances.GetLength(1); j++) {
				if(objectManager.distances[i, j] != null && objectManager.distances[i, j] > 0 && objectManager.distances[i, j] < maxBeamDistance){
					if(beams[i, j] == null) {
						beams[i, j] = Instantiate(beamPrefab, transform);
					}
					beams[i, j].GetComponent<LineRenderer>().SetPositions(new Vector3[] {objectManager.objects[i].transform.position, objectManager.objects[j].transform.position});
				} else if (beams[i, j] != null) {
					Destroy(beams[i, j]);
				}
			}
		}
	}
}
