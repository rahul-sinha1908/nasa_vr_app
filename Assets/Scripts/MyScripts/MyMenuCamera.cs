using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using MyGame;

public class MyMenuCamera : MonoBehaviour {

	public LayerMask colLayer;
	public Transform target, canvas;
	public NetworkScript netScript;
	private float timeHost, timeConnect;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		rayCaster();
	}

	private void rayCaster(){
		RaycastHit outP;
		if(Physics.Raycast(target.position, target.forward, out outP, Mathf.Infinity, colLayer)){
			//Dev.log(Tag.MyPlayerScript, "It Collided");
			if(outP.collider.name=="Host"){
				timeHost+=Time.deltaTime;
				timeConnect=0;
				if(timeHost>2){
					host();
				}
			}else if(outP.collider.name=="Connect"){
				timeHost=0;
				timeConnect+=Time.deltaTime;
				if(timeConnect>2){
					connect();
				}
			}
		}else{
			//Dev.log(Tag.MyPlayerScript, "It dint Collide");
			timeHost=0;
			timeConnect=0;
		}
	}


	private void host(){
		canvas.gameObject.SetActive(false);
		Dev.log(Tag.MyPlayerScript, "Hosting Successfull");
		netScript.createServer();
		//gameObject.SetActive(false);
	}
	private void connect(){
		canvas.gameObject.SetActive(false);
		Dev.log(Tag.MyPlayerScript, "Connecting Successfull");
		netScript.connectToSever();
		//gameObject.SetActive(false);
		//TODO Connect to the server
	}
}
