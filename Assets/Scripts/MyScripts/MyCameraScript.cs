using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGame;

public class MyCameraScript : MonoBehaviour {

	public Transform myPlayer;
	public Transform lookDir;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 vect = myPlayer.position;
		vect.y=transform.position.y;
		transform.position=vect;
	}
}
