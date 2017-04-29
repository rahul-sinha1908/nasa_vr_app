using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGame;

[RequireComponent(typeof(NetworkView))]
[RequireComponent(typeof(CharacterController))]
public class MyPlayerScript : MonoBehaviour {
	
	public LayerMask collidingLayer;
	private NetworkView netView;
	private CharacterController controller;
	// Use this for initialization
	void Start () {
		netView=GetComponent<NetworkView>();
		controller=GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void castRays(){
		Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
		RaycastHit outP;
		if(Physics.Raycast(ray, out outP, 1000, collidingLayer)){
			if(outP.collider.gameObject.layer==LayerMask.NameToLayer("Floor")){
				movePlayer(outP.point);
			}else if(outP.collider.gameObject.layer==LayerMask.NameToLayer("Menu")){

			}else if(outP.collider.gameObject.layer==LayerMask.NameToLayer("Earth")){
				
			}else if(outP.collider.gameObject.layer==LayerMask.NameToLayer("")){
				
			}
		}
	}
	private void movePlayer(Vector3 pos){

	}
}
