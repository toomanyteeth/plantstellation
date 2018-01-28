using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamManager : MonoBehaviour {

	private ObjectManager objectManager;
	public GameObject beamPrefab;
	public float maxBeamDistance;
	private GameObject[,] beams;

	// Use this for initialization
	void Start () {
		GameObject main = GameObject.Find("Main");
		objectManager = main.GetComponent<ObjectManager>();
		beams = new GameObject[objectManager.objects.Length, objectManager.objects.Length];
	}

	// Update is called once per frame
	void Update () {
		for(int i = 0; i < objectManager.objects.Length; i++) {
			for(int j = 0; j < objectManager.objects.Length; j++) {
				if(objectManager.distances[i, j] != null && objectManager.distances[i, j] > 0 && objectManager.distances[i, j] < maxBeamDistance){
					if(!beams[i, j]) {
						beams[i, j] = Instantiate(beamPrefab, transform);
					}
					beams[i, j].GetComponent<Beam>().UpdateBeam(objectManager.objects[i].transform.position, objectManager.objects[j].transform.position);
				} else if (beams[i, j]) {
					Destroy(beams[i, j]);
				}
			}
		}
	}
}
