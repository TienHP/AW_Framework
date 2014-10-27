using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace AW{
	public class AW_LayersFSM : MonoBehaviour, AW_IFSM {
		#region AW_IFSM implementation
		public virtual void InitStates ()
		{
			throw new System.NotImplementedException ();
		}
		public virtual void OnStateCycle ()
		{
			throw new System.NotImplementedException ();
		}
		#endregion

		//current states in layers
		public Dictionary<string, string> layerStates = new Dictionary<string, string>();
		
		public virtual void FireStateChangedEvt(string layer, string newState){
			throw new System.NotImplementedException();
		}//end method
/*----------------------------------------------
 * UNITY
 * ---------------------------------------------*/
		public void OnEnable(){
			InitStates();
		}//end method
	}//end class
}//end namespace
