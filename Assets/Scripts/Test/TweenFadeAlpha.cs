using UnityEngine;
using System.Collections;

public class TweenFadeAlpha : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		Debug.Log ("Fade this");
		iTween.FadeTo (gameObject, 0.3f, 1);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	

}
