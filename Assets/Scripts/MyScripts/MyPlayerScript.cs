using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGame;

public class MyPlayerScript : MonoBehaviour {
	public LayerMask collidingLayer;
	public float speed=5;
	public NetworkView netView;
	//public GameObject myTarget, myGame;
	public GameObject myTarget;
	private Animator anim;
	public CharacterController controller;
	// Use this for initialization
	void Start () {
		anim=GetComponent<Animator>();
		netView=GetComponent<NetworkView>();
		// if(!netView.isMine)
		// 	myTarget.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(!netView.isMine)
			return;
		lookTowards();
		castRays();
	}

	public void initiate(GameObject obj){
		myTarget=obj;
	}
	private void castRays(){
		
		RaycastHit outP;
		if(Physics.Raycast(myTarget.transform.position, myTarget.transform.forward, out outP, 1000, collidingLayer)){
			Dev.log(Tag.MyPlayerScript, "Its here : 1");
			if(outP.collider.gameObject.layer==LayerMask.NameToLayer("Floor")){
				Dev.log(Tag.MyPlayerScript, "Its here : "+outP.point);
				movePlayer(outP.point);
			}else if(outP.collider.gameObject.layer==LayerMask.NameToLayer("Menu")){

			}else if(outP.collider.gameObject.layer==LayerMask.NameToLayer("Earth")){
				
			}else if(outP.collider.gameObject.layer==LayerMask.NameToLayer("")){
				
			}
		}else{
			anim.SetBool("Walk", false);
			netView.RPC("RPCCallMethod", RPCMode.Others,new object[]{true});
		}
	}
	private void movePlayer(Vector3 pos){
		Dev.log(Tag.MyPlayerScript,"Vector Pos : " +transform.forward * speed);
		
		// Vector3 ini = transform.position;
		// controller.SimpleMove(myGame.transform.forward);
		anim.SetBool("Walk", true);
		// transform.position = new Vector3(0, transform.position.y, 0);
		// myGame.transform.position = new Vector3(ini.x, myGame.transform.position.y, ini.z);
		netView.RPC("RPCCallMethod", RPCMode.Others,new object[]{true});
	}
	[RPC]
	private void RPCCallMethod(bool b){
		anim.SetBool("Walk", b);
	}
	private void lookTowards(){
		Quaternion quad = myTarget.transform.rotation;
		quad.x=0;
		quad.z=0;
		transform.rotation=quad;
	}
}

