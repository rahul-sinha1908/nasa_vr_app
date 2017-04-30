using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGame;

public class MyCameraScript : MonoBehaviour {

	public Transform  myPlayerPrefab, hostSpawnPosition, clientSpawnPosition;
	public Transform myPlayer;
	public Transform lookDir, popUp;
	// Use this for initialization
	void Start () {
		GameObject go;
		if(GameRunningScript.getInstance().isServer){
			Dev.log(Tag.MyPlayerScript, "Server Connected");
			myPlayer = (Transform) Network.Instantiate(myPlayerPrefab,hostSpawnPosition.position, Quaternion.identity,0);
		}else{
			Dev.log(Tag.MyPlayerScript, "Client Connected");
			myPlayer = (Transform) Network.Instantiate(myPlayerPrefab,clientSpawnPosition.position, Quaternion.identity,0);
		}
		//myPlayer =  GameObject.Instantiate(myPlayerPrefab,hostSpawnPosition.position, Quaternion.identity);
		//myPlayer = go.transform;
		if(myPlayer!=null)
			myPlayer.GetComponent<MyPlayerScript>().initiate(GetComponent<Transform>().FindChild("LookDir").gameObject, popUp);
			//game.GetComponent<MyPlayerScript>().initiate(gameObject);
		else
			Dev.log(Tag.MyPlayerScript, "Error Cant Find");
	}
	
	// Update is called once per frame
	void Update () {
		if(myPlayer==null)
			return;
		Vector3 vect = myPlayer.position;
		vect.y=transform.position.y;
		transform.position=vect;
	}
}
