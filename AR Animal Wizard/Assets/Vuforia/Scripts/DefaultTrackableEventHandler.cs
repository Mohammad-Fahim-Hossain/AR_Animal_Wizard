/*==============================================================================
Copyright (c) 2017 PTC Inc. All Rights Reserved.

Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Vuforia;

/// <summary>
///     A custom handler that implements the ITrackableEventHandler interface.
/// </summary>
public class DefaultTrackableEventHandler : MonoBehaviour, ITrackableEventHandler
{
    #region PRIVATE_MEMBER_VARIABLES

    protected TrackableBehaviour mTrackableBehaviour;

	private Controller control;
	private GameObject Cat;
	private GameObject Dragon;
	private GameObject Wolf;
	private GameObject Zombie;
	private GameObject Dinosaur;
	private Vector3 PrePos;

	//private AudioSource[] AudioBank;
	//public  AudioSource Sound1, Sound2;



    #endregion // PRIVATE_MEMBER_VARIABLES

    #region UNTIY_MONOBEHAVIOUR_METHODS

    protected virtual void Start()
    {
		Cat = GameObject.Find ("Cat");
		Dragon = GameObject.Find ("Dragon");
		Wolf = GameObject.Find ("Wolf");
		Zombie = GameObject.Find ("Zombie");
		Dinosaur = GameObject.Find ("Dinosaur");
		PrePos = Wolf.transform.position;

		control = GameObject.FindObjectOfType<Controller> ();
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
    }

    #endregion // UNTIY_MONOBEHAVIOUR_METHODS

    #region PUBLIC_METHODS

    /// <summary>
    ///     Implementation of the ITrackableEventHandler function called when the
    ///     tracking state changes.
    /// </summary>
    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
            OnTrackingFound();
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NOT_FOUND)
        {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
            OnTrackingLost();
        }
        else
        {
            // For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
            // Vuforia is starting, but tracking has not been lost or found yet
            // Call OnTrackingLost() to hide the augmentations
            OnTrackingLost();
        }
    }

    #endregion // PUBLIC_METHODS

    #region PRIVATE_METHODS

    protected virtual void OnTrackingFound()
    {
        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);

        // Enable rendering:
        foreach (var component in rendererComponents)
            component.enabled = true;

        // Enable colliders:
        foreach (var component in colliderComponents)
            component.enabled = true;

        // Enable canvas':
        foreach (var component in canvasComponents)
            component.enabled = true;
		
		if (mTrackableBehaviour.Trackable.Name == "wolf") {

			Wolf.GetComponent<AudioSource> ().Play ();
			TrackObjectName ("WOLF");

		}
		if (mTrackableBehaviour.Trackable.Name == "KittyCat") {
			
			Cat.GetComponent<AudioSource> ().Play ();
			TrackObjectName ("CAT");

		} 
		if (mTrackableBehaviour.Trackable.Name == "dragon") {
			
			Dragon.GetComponent<AudioSource> ().Play ();
			TrackObjectName ("DRAGON");
		}
		if (mTrackableBehaviour.Trackable.Name == "Trex") {
			
			Dinosaur.GetComponent<AudioSource> ().Play ();
			TrackObjectName ("TREX");
		}
		if (mTrackableBehaviour.Trackable.Name == "Zombie") {
			
			Zombie.GetComponent<AudioSource> ().Play ();
			TrackObjectName ("ZOMBIE");
		}
    }


    protected virtual void OnTrackingLost()
    {
        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);

        // Disable rendering:
        foreach (var component in rendererComponents)
            component.enabled = false;

        // Disable colliders:
        foreach (var component in colliderComponents)
            component.enabled = false;

        // Disable canvas':
        foreach (var component in canvasComponents)
            component.enabled = false;
	
		Wolf.transform.position = PrePos;
		Cat.transform.position = PrePos;
		Dragon.transform.position = PrePos;
		Dinosaur.transform.position = PrePos;
		Zombie.transform.position = PrePos;

	


		Wolf.GetComponent<AudioSource> ().Stop ();
		Cat.GetComponent<AudioSource>().Stop ();
		Dragon.GetComponent<AudioSource> ().Stop ();
		Dinosaur.GetComponent<AudioSource> ().Stop ();
		Zombie.GetComponent<AudioSource> ().Stop ();
    }

	public string TrackObjectName(string Name){
		//Debug.Log (Name);
		return Name;
	}
		


    #endregion // PRIVATE_METHODS
}

