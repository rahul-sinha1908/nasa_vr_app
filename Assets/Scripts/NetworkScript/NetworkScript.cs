using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGame;
using System;

[RequireComponent(typeof(NetworkView))]
public class NetworkScript : MonoBehaviour {

	public NetworkView netView;
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

	public void makeHost(){
		Network.InitializeServer(4, portNum, true);
		MasterServer.RegisterHost(registeredName, gameName, "Hey Join the game");
	}

	private void takeMeAsServer(){
		
	}

	private void takeMeAsHost(){

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
