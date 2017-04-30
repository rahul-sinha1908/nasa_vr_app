using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame{
	public class GameRunningScript{
		public Transform lookDir;
		public GameRunningScript localScript, networkScript;
		public bool netLooking, localLooking;
		public bool isServer;
		private static GameRunningScript instance;
		public static GameRunningScript getInstance(){
			if(instance==null)
				instance=new GameRunningScript();
			return instance;
		}

	}
}
