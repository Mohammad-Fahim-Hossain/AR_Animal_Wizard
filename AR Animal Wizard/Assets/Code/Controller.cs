using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Controller : MonoBehaviour {
	private Rigidbody RB;
	private Animation Anime;
	private DefaultTrackableEventHandler TrackingFunction;

	public bool isBool;




	// Use this for initialization
	void Start () {
		RB = GetComponent<Rigidbody> ();
		Anime = GetComponent<Animation> ();
		TrackingFunction = GameObject.FindObjectOfType<DefaultTrackableEventHandler> ();


	}

	// Update is called once per frame
	void Update () {
		float x = CrossPlatformInputManager.GetAxis ("Horizontal");
		float y = CrossPlatformInputManager.GetAxis("Vertical");
		 isBool=CrossPlatformInputManager.GetButton("Jump");

		Vector3 Movement = new Vector3 (x, 0, y);
		RB.velocity = Movement /10f;
		if (x != 0 && y != 0) {
			transform.eulerAngles = new Vector3 (transform.eulerAngles.x, Mathf.Atan2 (x, y) * Mathf.Rad2Deg, transform.eulerAngles.z);
		}


		if (isBool == true) {
			RB.velocity = Movement /5f;
			Anime.Play ("Dragon Fly");
			Anime.Play ("Cat Run");
			Anime.Play ("Wolf Run");
			Anime.Play ("Zombie Attacking");
			Anime.Play ("Dinosaur Roar");

		}
		else if (x != 0 || y != 0) {

			Anime.Play ("Cat Walk");
			Anime.Play ("Dragon Walk");
			Anime.Play ("Wolf Walk");
			Anime.Play ("Zombie Walk");
			Anime.Play ("Dinosaur Walk");

		} else {
			Anime.Play ("Cat Idle"); 
			Anime.Play ("Dragon Idle");
			Anime.Play ("Wolf Idle");
			Anime.Play ("Zombie Idle");
			Anime.Play ("Dinosaur Idle");
		}


	}



}
