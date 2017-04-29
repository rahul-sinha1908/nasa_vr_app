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
		GameObject go;
		if(GameRunningScript.getInstance().isServer)
			go = (GameObject) Network.Instantiate(myPlayerPrefab,hostSpawnPosition.position, Quaternion.identity,0);
		else
			go = (GameObject) Network.Instantiate(myPlayerPrefab,clientSpawnPosition.position, Quaternion.identity,0);
		myPlayer =  GameObject.Instantiate(myPlayerPrefab,clientSpawnPosition.position, Quaternion.identity);
		Transform game = myPlayer.FindChild("SS");
		if(game!=null)
			game.GetComponent<MyPlayerScript>().initiate(GetComponent<Transform>().FindChild("LookDir").gameObject);
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
