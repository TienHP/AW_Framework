using UnityEngine;
using System.Collections;

namespace AW{
	public class AW_PlayerController : AW_LayersFSM {
/*----------------------------------------------
 * DEFINING
 * ---------------------------------------------*/
		public class PlayerStateLayers : AW_SimpleState{
			public const string NORMAL = "NORMAL";
			public const string MOVING = "MOVING";
			public const string LIVING = "LIVING";
		}

		public class PlayerState : AW_SimpleState{
			public const string IDLE = "IDLE";
			public const string WALK = "WALK";
			public const string ALIVE = "ALIVE";
			public const string DIE = "DIE";
		}

		public event LayersStateChangedHandler OnLayersStateChangedEvt;

		public override void InitStates ()
		{
			layerStates.Add(PlayerStateLayers.MOVING, PlayerState.IDLE);
			layerStates.Add(PlayerStateLayers.LIVING, PlayerState.ALIVE);
		}
/*----------------------------------------------
 * UNITY
 * ---------------------------------------------*/
		void OnEnable(){
			base.OnEnable();
			OnLayersStateChangedEvt += HandleOnLayersStateChangedEvt;
		}

		IEnumerator Start(){
			Debug.Log("Player is created!");
			Debug.Log("moving state: "+layerStates[PlayerStateLayers.MOVING]);
			Debug.Log("living state: "+layerStates[PlayerStateLayers.LIVING]);

			yield return new WaitForSeconds(2.0f);
			//try to move
			if (OnLayersStateChangedEvt != null)
				OnLayersStateChangedEvt(PlayerStateLayers.MOVING, PlayerState.WALK);

			//try to stop
			yield return new WaitForSeconds(3.0f);
			//try to move
			if (OnLayersStateChangedEvt != null)
				OnLayersStateChangedEvt(PlayerStateLayers.MOVING, PlayerState.IDLE);

		}//end method
/*----------------------------------------------
 * TEST
 * ---------------------------------------------*/
		void HandleOnLayersStateChangedEvt (string layer, string state){
			Debug.Log("player change state: "+"("+ layer +","+state+")");
			switch (layer){
				case PlayerStateLayers.MOVING:
					switch (state){
						case PlayerState.WALK:
							Debug.Log("player walk");
							StartCoroutine(Walk (0.01f));
							break;
						case PlayerState.IDLE:
							Debug.Log("player stop");
							StopAllCoroutines();
							break;
					}
					break;
			}//end switch
		}//end method

		IEnumerator Walk(float timeStep){
			while (true){
				transform.Translate(new Vector3(0.02f, 0, 0), Space.Self);
				yield return new WaitForSeconds(timeStep);
			}
		}//end method

	}
}
