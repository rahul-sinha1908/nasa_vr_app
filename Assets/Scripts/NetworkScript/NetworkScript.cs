using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NetworkView))]
public class NetworkScript : MonoBehaviour {

	public NetworkView netView;
	// Use this for initialization
	void Start () {
		netView=GetComponent<NetworkView>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
