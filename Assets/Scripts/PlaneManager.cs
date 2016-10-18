﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlaneManager : MonoBehaviour {

	// the current plane/tile to spawn from
	public GameObject current;
	// the available planes/tiles to spawn
	public GameObject[] planes;

	// a stack of inactive left planes
	private Stack<GameObject> leftPlanes;
	// a stack of inactive top planes
	private Stack<GameObject> topPlanes;

	// the instance of the current PlaneManager
	private static PlaneManager instance;

	// static property of a PlaneManager 
	public static PlaneManager Instance {
		get { // an instance getter
			if (instance == null) {
				instance = GameObject.FindObjectOfType<PlaneManager> ();
			}
			return instance;
		}
	}

	// Use this for initialization
	void Start () {
		leftPlanes = new Stack<GameObject> ();
		topPlanes = new Stack<GameObject> ();

		CreatePlanes (100);

		for (int i = 0; i < 50; i++) {
			SpawnPlane ();
		}
	}

	public void CreatePlanes(int n) {
		for (int i = 0; i < n; i++) {
			leftPlanes.Push (Instantiate (planes [0]));
			topPlanes.Push (Instantiate (planes [1]));
			// deactivate objects
			leftPlanes.Peek ().SetActive (false);
			topPlanes.Peek ().SetActive (false);
		}
	}

	public void SpawnPlane() {
		if (leftPlanes.Count == 0 || topPlanes.Count == 0) {
			CreatePlanes (10);
		}

		// generating random number between 0 and the amount of available plane prefabs
		int rand = Random.Range (0, planes.Length);

		GameObject tmp = leftPlanes.Peek();
		if (rand == 0) {
			tmp = leftPlanes.Pop ();
		} else if (rand == 1) {
			tmp = topPlanes.Pop ();
		}

		tmp.SetActive (true);
		tmp.transform.position = current.transform.GetChild (0).transform.GetChild (rand).position;
		current = tmp;

		//current = (GameObject)Instantiate (planes[rand], current.transform.GetChild(0).transform.GetChild(rand).position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
