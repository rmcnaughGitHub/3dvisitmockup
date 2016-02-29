using UnityEngine;
using System.Collections;
using System.Text;

public class GuidedVisitGUI : MonoBehaviour
{
	
	private string mDefaultText;
	
	void Start ()
	{
		GetComponent<GUIText>().material.color = Color.black;
		mDefaultText = GetComponent<GUIText>().text;
	}
	
	void OnMouseDown ()
	{
		SendMessageUpwards (Messages.guidedVisitRequested);
	}
	
	void guidedVisitRequested ()
	{
		GetComponent<GUIText>().text = ""; //"> Recommencer <";
	}

	void guidedVisitEnded ()
	{
		GetComponent<GUIText>().text = mDefaultText;
	}
}
