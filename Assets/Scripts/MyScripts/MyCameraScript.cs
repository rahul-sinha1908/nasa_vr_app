using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGame;

public class MyCameraScript : MonoBehaviour {

	public Transform  myPlayerPrefab, hostSpawnPosition, clientSpawnPosition;
	public Transform myPlayer;
	public Transform lookDir;
	// Use this for initialization
	void Start () {
		if(GameRunningScript.getInstance().isServer)
			myPlayer = (Transform) Network.Instantiate(myPlayerPrefab,hostSpawnPosition.position, Quaternion.identity,0);
		else
			myPlayer = (Transform) Network.Instantiate(myPlayerPrefab,clientSpawnPosition.position, Quaternion.identity,0);

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 vect = myPlayer.position;
		vect.y=transform.position.y;
		transform.position=vect;
	}
}
