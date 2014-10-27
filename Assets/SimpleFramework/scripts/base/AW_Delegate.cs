using UnityEngine;
using System.Collections;

namespace AW{

	public delegate void VoidDelegate();
	public delegate void SimpleStateChangedHandler(string newState);
	public delegate void LayersStateChangedHandler(string layer, string state);

}