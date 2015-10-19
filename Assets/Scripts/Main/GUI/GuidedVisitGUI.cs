using UnityEngine;
using System.Collections;
using System.Text;

public class GuidedVisitGUI : MonoBehaviour
{
	
	private string mDefaultText;
	
	void Start ()
	{
		guiText.material.color = Color.black;
		mDefaultText = guiText.text;
	}
	
	void OnMouseDown ()
	{
		SendMessageUpwards (Messages.guidedVisitRequested);
	}
	
	void guidedVisitRequested ()
	{
		guiText.text = ""; //"> Recommencer <";
	}

	void guidedVisitEnded ()
	{
		guiText.text = mDefaultText;
	}
}
