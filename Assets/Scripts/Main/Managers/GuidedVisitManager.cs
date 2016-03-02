using UnityEngine;
using System.Collections;
using Holoville.HOTween;
using Holoville.HOTween.Plugins;

public class GuidedVisitManager : MonoBehaviour
{
	
	public Transform	mCamera;
	public float 		mVisitGuidedTime = 90;
	public float 		mCameraDropTime = 1.5f;
	public Transform[]	path;
	private Tweener 	currentTween;
	
	// Use this for initialization
	void Start ()
	{	
		HOTween.showPathGizmos = true;
	}
	
	void launchGuidedVisit ()
	{
		// Find good orientation at path startup
		Quaternion cameraOrientationAtPathStarup = Quaternion.LookRotation (path [1].position - path [0].position);

		// Place camera first
		currentTween = HOTween.To (mCamera, mCameraDropTime, new TweenParms ()
										.Prop ("position", new PlugVector3Path (new Vector3[]{mCamera.transform.position, path [0].position}, PathType.Curved))
										.Prop ("rotation", new PlugQuaternion (cameraOrientationAtPathStarup, EaseType.EaseInOutQuad)).AutoKill (true)
										.Ease (EaseType.EaseOutQuad)
										.OnComplete (() => {
			doPath ();
		}));
	}

	void doPath ()
	{
		currentTween = HOTween.To (mCamera, mVisitGuidedTime, new TweenParms ()
										.Prop ("position", new PlugVector3Path (convertTransformArrayToVector3 (path), PathType.Curved)
										.OrientToPath (0.075f))
										.Ease (EaseType.Linear)
										.OnComplete (onSequenceCompleted));
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			BroadcastMessageUpDown (Messages.guidedVisitEnded); // Get back to default plan
		}

	}

	void onSequenceCompleted ()
	{
		BroadcastMessageUpDown (Messages.guidedVisitEnded); //
		
	}
	
	/// <summary>
	/// Converts the transform array to vector3 array.
	/// </summary>
	/// <param name='trArray'>
	/// Tr array.
	/// </param>
	Vector3[] convertTransformArrayToVector3 (Transform[] trArray)
	{
		Vector3[] v3Array = new Vector3[trArray.Length];
		for (int i =0; i < trArray.Length; i++) {
			v3Array [i] = trArray [i].position;
		}
		return v3Array;
	}
	
	void BroadcastMessageUpDown (string message)
	{
		SendMessageUpwards (message);	
		BroadcastMessage (message);
	}
	
	void OnGUI ()
	{
	
//		if (currentTween != null) {
//			currentTween.timeScale = GUILayout.HorizontalSlider (currentTween.timeScale, -5.0F, 5.0F);
//			GUILayout.Label ("This text makes just space");
//		}
	}
	
}
