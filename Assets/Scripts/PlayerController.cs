﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	private float storedSpeed;
	private Vector3 dir;

	public int pickUpCount;
	public Text countText;
	public Text onYourMarkText;

	private Rigidbody rb;
	private int count;

	public GameObject plane;

	// materials for each level
	public Material[] materials;

	// the instance of the current PlaneManager
	private static PlayerController instance;

	// static property of a PlaneManager 
	public static PlayerController Instance {
		get { // an instance getter
			if (instance == null) {
				instance = GameObject.FindObjectOfType<PlayerController> ();
			}
			return instance;
		}
	}

	void Start() {
		rb = GetComponent<Rigidbody>();
		count = 0;
		storedSpeed = speed;
		dir = Vector3.forward;
//		onYourMarkText.text = "";
//		SetCountText ();
//		StartCoroutine(OnYourMark());
	}

	//wait for 5 seconds to start the game & display starting text
//	IEnumerator OnYourMark() {
//		this.speed = 0;
//		onYourMarkText.text = "On Your Mark";
//		yield return new WaitForSeconds (2);
//		onYourMarkText.text = "Get Set";
//		yield return new WaitForSeconds (2);
//		onYourMarkText.text = "Go!!";
//		yield return new WaitForSeconds (1);
//		onYourMarkText.text = "";
//		this.speed = storedSpeed;
//	}

	//controls the movement of the ball
	void Update() {
		if (plane.CompareTag ("TopPlane")) {
			if (Input.GetKey (KeyCode.RightArrow)) {
				dir = Vector3.right;
			} else if (Input.GetKey (KeyCode.LeftArrow)) {
				dir = Vector3.left;
			} else {
				dir = Vector3.forward;
			}
		} else if (plane.CompareTag ("LeftPlane")) {
			if (Input.GetKey (KeyCode.DownArrow)) {
				dir = Vector3.back;
			} else if (Input.GetKey (KeyCode.UpArrow)) {
				dir = Vector3.forward;
			} else {
				dir = Vector3.left;
			}
		}
		float amountToMove = speed * Time.deltaTime;
//		transform.Rotate (-dir * amountToMove);
		transform.Translate (dir * amountToMove);
	}
		
	//****we may want to move this to another class!****
	void OnTriggerEnter (Collider other){
		if (other.gameObject.CompareTag ("LeftPlane") || other.gameObject.CompareTag("TopPlane")) {
			plane = other.gameObject;
		}
		else if (other.gameObject.CompareTag("EasterEgg")){
			CollectObject (other);
			SetCountText ();
		}
		else if (other.gameObject.CompareTag("Jackolantern")){
			CollectObject (other);
			SetCountText ();
		}
		else if (other.gameObject.CompareTag("Ornament")){
			CollectObject (other);
			SetCountText ();
		}
		else if (other.gameObject.CompareTag("Present")){
			CollectObject (other);
			SetCountText ();
		}
		else if (other.gameObject.CompareTag("CandyCane")){
			CollectObject (other);
			SetCountText ();
		}
		else if (other.gameObject.CompareTag("TeddyBear")){
			CollectObject (other);
			SetCountText ();
		}
		//if hit skeleton -- lose points?!
	}

	void SetCountText (){
		countText.text = "Count: " + count.ToString ();
	}

	void CollectObject (Collider other){
		Destroy (other.gameObject);
		count++;
	}
}
