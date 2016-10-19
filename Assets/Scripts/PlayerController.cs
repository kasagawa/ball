﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed;
	private Vector3 dir;
	public int pickUpCount;
	public Text countText;
	private Rigidbody rb;
	private int count;

	void Start() {
		dir = Vector3.zero;
		rb = GetComponent<Rigidbody>();
		count = 0;
//		SetCountText ();
	}

	void Update() {
		if (Input.GetKey (KeyCode.RightArrow)) {
			dir = Vector3.right;
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			dir = Vector3.left;
		} else {
			dir = Vector3.forward;
		}

		float amountToMove = speed * Time.deltaTime;
		//		transform.Rotate (dir * amountToMove);
		transform.Translate (dir * amountToMove);
	}
//		
//	//****we may want to move this to another class!****
//	void OnTriggerEnter (Collider other){
//		if (other.gameObject.CompareTag("EasterEgg")){
//			CollectObject (other);
//			SetCountText ();
//		}
//		if (other.gameObject.CompareTag("Jackolantern")){
//			CollectObject (other);
//			SetCountText ();
//		}
//		if (other.gameObject.CompareTag("Ornament")){
//			CollectObject (other);
//			SetCountText ();
//		}
//		if (other.gameObject.CompareTag("Present")){
//			CollectObject (other);
//			SetCountText ();
//		}
//		if (other.gameObject.CompareTag("CandyCane")){
//			CollectObject (other);
//			SetCountText ();
//		}
//		if (other.gameObject.CompareTag("TeddyBear")){
//			CollectObject (other);
//			SetCountText ();
//		}
//		//if hit skeleton -- lose points?!
//	}
//
//	void SetCountText (){
//		countText.text = "Count: " + count.ToString ();
//	}
//
//	void CollectObject (Collider other){
//		Destroy (other.gameObject);
//		count++;
//	}
}
