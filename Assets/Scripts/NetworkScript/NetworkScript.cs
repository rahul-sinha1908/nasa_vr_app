using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MyGame;
using System;

[RequireComponent(typeof(NetworkView))]
public class NetworkScript : MonoBehaviour {

	public Transform spawingPos;
	public NetworkView netView;
	public GameObject buttonHolder, buttonPrefab, playerPrefab;
	private int portNum;
	private string registeredName, gameName;
	
	// Use this for initialization
	void Start () {
		netView=GetComponent<NetworkView>();
		portNum=190897;
		registeredName="VRGameRegistered_1908";
		gameName="A game Name";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void connectToSever(){
		MasterServer.RequestHostList(registeredName);
	}

	public void createServer(){
		Network.InitializeServer(4, portNum, true);
		MasterServer.RegisterHost(registeredName, gameName, "Hey Join the game");
	}

	private void InstantiatePlayer(){
		Camera cam =Camera.main;
		Network.Instantiate(playerPrefab, spawingPos.position, Quaternion.identity, 0);
		cam.enabled=false;
	}

	/// <summary>
	/// Called on clients or servers when reporting events from the MasterServer.
	/// </summary>
	/// <param name="msEvent">The MasterServerEvent which ocurred.</param>
	void OnMasterServerEvent(MasterServerEvent msEvent)
	{
		if(msEvent == MasterServerEvent.RegistrationSucceeded){
			Dev.log(Tag.Network,"Successfully Registered");
			//MasterServer.RequestHostList(registeredName);
		}else if(msEvent == MasterServerEvent.HostListReceived){
			HostData[] host=MasterServer.PollHostList();
			Dev.log(Tag.Network,"Got the Hosts : "+host.Length);
			foreach(HostData h in host){
				Dev.log(Tag.Network,h.gameName+" : "+h.comment);
				addButton(h);
			}
			MasterServer.RequestHostList(registeredName);
		}else{

		}
	}

    private void addButton(HostData h)
    {
        GameObject go = GameObject.Instantiate(buttonPrefab,Vector3.zero, Quaternion.identity, buttonHolder.transform);
		Button but=go.GetComponent<Button>();
		but.onClick.AddListener(()=>callOnButtonPress(h));
    }

	private void callOnButtonPress(HostData h){
		Network.Connect(h);
	}

    /// <summary>
    /// Called on the server whenever a Network.InitializeServer was invoked and has completed.
    /// </summary>
    void OnServerInitialized()
	{
		
	}

	/// <summary>
	/// Called on the server whenever a new player has successfully connected.
	/// </summary>
	/// <param name="player">The NetworkPlayer which just connected.</param>
	void OnPlayerConnected(NetworkPlayer player)
	{
		
	}
}
