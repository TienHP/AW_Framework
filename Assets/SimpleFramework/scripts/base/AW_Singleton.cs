using UnityEngine;
using System.Collections;

/// <summary>
/// @ Author: 
/// @ Last modified date:
/// @ Purpose: singleton class
/// </summary>
namespace AW{
	public abstract class AW_Singleton<T_TYPE> : MonoBehaviour where T_TYPE : AW_Singleton<T_TYPE>{
		private static T_TYPE instance;
		
		public static T_TYPE GetInstance ()
		{
			if (instance == null) {
				instance = GameObject.FindObjectOfType (typeof(T_TYPE)) as T_TYPE;
			}//end if
			return instance;
		}//end method
		
		protected abstract void Initialize ();
		
		protected virtual void Awake ()
		{
			
			T_TYPE instance1 = GetInstance ();
			if (instance1 == null) {
				instance1 = this as T_TYPE;
			}//end if
			
			if (instance1 != (this as T_TYPE)) {
				Destroy (gameObject);
				return;
			}//end if
			
			instance = instance1;
			Initialize ();
			GameObject.DontDestroyOnLoad (gameObject);
		}//end method
	}//end class
}//end namespace
