using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGame;

[RequireComponent(typeof(NetworkView))]
public class MyPlayerScript : MonoBehaviour {
	
	public LayerMask collidingLayer;
	private NetworkView netView;

	// Use this for initialization
	void Start () {
		netView=GetComponent<NetworkView>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void castRays(){
		Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
		RaycastHit outP;
		if(Physics.Raycast(ray, out outP, 1000, collidingLayer)){
			
		}
	}
}
