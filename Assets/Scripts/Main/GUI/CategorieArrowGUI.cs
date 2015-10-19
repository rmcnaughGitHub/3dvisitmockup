using UnityEngine;
using System.Collections;

public class CategorieArrowGUI : MonoBehaviour
{
	
	public enum Type
	{
		Previous,
		Next
	}
	public Type type;
	
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	void OnMouseDown ()
	{
		SendMessageUpwards (Messages.arrowPressedGUI, type);
	}
	
	void setGUIArrowPreviousVisible (bool visible)
	{
	
		if (type.Equals (Type.Previous)) {
			guiTexture.enabled = visible;
		}
		
	}
	
	void setGUIArrowNextVisible (bool visible)
	{
		if (type.Equals (Type.Next)) {
			guiTexture.enabled = visible;
		}
	}
	
}
