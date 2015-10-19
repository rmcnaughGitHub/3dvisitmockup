using UnityEngine;
using System.Collections;
using Holoville.HOTween;
using Holoville.HOTween.Plugins;

public class CamMoves : MonoBehaviour
{

	public Transform goal, lookPoint;
//	Tweener tw;
	// Use this for initialization
	void Start ()
	{
	
		HOTween.Init (false, false, true);
		HOTween.EnableOverwriteManager (false);
		

	}
	
	// Update is called once per frame
	void Update ()
	{
	
		if (Input.GetKeyDown (KeyCode.R)) {
		
			//tw.Rewind(1.0f);
//			tw.Reverse();
			Vector3[] pathPositions = new Vector3[]{transform.position,goal.position};

			HOTween.To (gameObject.transform, 3.0f, new TweenParms ().Prop ("position", 
			new PlugVector3Path (pathPositions, EaseType.EaseInOutQuad, PathType.Curved).LookAt (lookPoint)).AutoKill (false));		

		}
		
		
	}
}
