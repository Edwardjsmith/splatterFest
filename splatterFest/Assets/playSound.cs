using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSound : MonoBehaviour {

    public AudioSource shotEffect;

	// Use this for initialization
	void Start ()
    {
        shotEffect.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
