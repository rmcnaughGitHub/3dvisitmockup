using UnityEngine;
using System.Collections;
using Holoville.HOTween;
using Holoville.HOTween.Plugins;


public class CameraManager : MonoBehaviour
{
	
	public Camera mCamera;
	
	void Start ()
	{
		if(mCamera == null) {
			mCamera = Camera.main;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	public void moveToGoal (GoalData goalData)
	{
		tweenTransformFromTo(transform, goalData.mTransform, goalData.mMoveTime);
	}

	void tweenTransformFromTo (Transform source, Transform goal, float time)
	{
		Vector3[] pathPositions = new Vector3[]{source.transform.position, goal.transform.position};
		
		HOTween.To (this.transform, time, 
			new TweenParms ()
			.Prop ("position", 
				new PlugVector3Path (pathPositions, EaseType.EaseInOutQuad, PathType.Curved))
			.Prop ("rotation", new PlugQuaternion (goal.rotation, EaseType.EaseInOutQuad)).AutoKill (true)
			.OnStart(() => {
				SendMessageUpwards(Messages.cameraMoveStart);
			})
			.OnComplete(() =>  {
				SendMessageUpwards(Messages.cameraMoveComplete);
	         })
		);		
		
	}
}
