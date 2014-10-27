using UnityEngine;
using System.Collections;

namespace AW{
	public class AW_GameManager : AW_SimpleManagerFSM<AW_GameManager> {
	
		public class AW_GameState : AW_SimpleState{
			public const string INITING = "INITING";
			public const string STARTING = "STARTING";
			public const string PLAYING = "PLAYING";
			public const string OVER = "OVER";
		} 

		private string currentState;

		protected override void Initialize ()
		{
		}

		public override void ChangeState (string newState)
		{
			currentState = newState;
		}

		public event SimpleStateChangedHandler OnStateChangedEvt;

		IEnumerator Start(){
			//try to register events
			OnStateChangedEvt += HandleOnStateChangedEvt;

			yield return new WaitForSeconds(2.0f);
			//try to start game
			if (OnStateChangedEvt != null) 
				OnStateChangedEvt(AW_GameState.STARTING);
		}
/*----------------------------------------------
 * DEMO
 * ---------------------------------------------*/
		void HandleOnStateChangedEvt (string newState)
		{
			switch (newState){
				case AW_GameState.INITING:
					Debug.Log("game is initing");
					break;
				case AW_GameState.STARTING:
					Debug.Log("game is starting");
					//init player
					Instantiate(Resources.Load("prefabs/Player"));
					break;
				case AW_GameState.PLAYING:
					Debug.Log("game is playing");
					break;
			}//end switch
		}//end method

	}//end class

}//end namespace
