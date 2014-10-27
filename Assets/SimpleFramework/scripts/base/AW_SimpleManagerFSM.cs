using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace AW{
	public class AW_SimpleManagerFSM<T_TYPE> : AW_Singleton<T_TYPE>, AW_IFSM where T_TYPE : AW_Singleton<T_TYPE>{
		#region implemented abstract members of AW_Singleton

		protected override void Initialize ()
		{
			throw new System.NotImplementedException ();
		}

		#endregion
		
		public void OnEnable(){
			InitStates();
		}//end method

		#region AW_IFSM implementation
		public virtual void InitStates ()
		{
		}
		public void OnStateCycle ()
		{
		}
		#endregion

		public virtual void ChangeState(string newState){
			throw new System.NotImplementedException();
		}//end method

	}//end class

}//end namespace
