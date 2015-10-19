using UnityEngine;
using System.Collections;

public class GuiDebug : MonoBehaviour {
	
	public GUIText mVisitText;
	
	void Awake() {
		mVisitText.material.color = Color.black;
	}
	
	/// <summary>
	/// States the changed received here from VisitManager
	/// </summary>
	/// <param name='state'>
	/// State given by the Visit Manager
	/// </param>
	void stateChanged (VisitStates state) {
		mVisitText.text = state.ToString();
	}
}
