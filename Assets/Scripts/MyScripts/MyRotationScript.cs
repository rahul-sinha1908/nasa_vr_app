using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGame;

public class MyRotationScript : MonoBehaviour {

	public List<Transform> rotationPos;
	public Transform lookAtPos;
	public Transform cameraObj;
	private int ind;
	public float speed;
	// Use this for initialization
	void Start () {
		ind=0;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up * Time.deltaTime*speed);
		//revolution();
	}

	private void revolution(){
		if(GameMethods.getCloseNot(transform.position, rotationPos[ind].position, 100)){
			ind++;
		}
		if(ind == rotationPos.Capacity){
			ind=0;
		}
		transform.position=GameMethods.getProjectionWithSpeed(rotationPos[ind].position, transform.position, speed, Time.deltaTime);
		//cameraObj.LookAt(lookAtPos);
		
	}
}
