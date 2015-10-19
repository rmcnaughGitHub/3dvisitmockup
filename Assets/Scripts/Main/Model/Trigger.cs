using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour
{
	public GoalData mGoalData;
	
	// Use this for initialization
	void Start ()
	{
		setupTriggerGoalTransform ();
		mGoalData.mIniator = gameObject;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	void OnMouseDown ()
	{
		notifyNewGoal ();
	}
	
	void notifyNewGoal ()
	{
		SendMessageUpwards (Messages.listenForNewGoal, mGoalData);
	}

	void setupTriggerGoalTransform ()
	{
		if (mGoalData.mTransform == null) {
			mGoalData.mTransform = findGoalTranformInChildrens ();
		}
		
		if (mGoalData.mTransform == null) {
			throw new UnityException ("No gameobject Goal founded below " + gameObject.name);	
		}
	}
	
	Transform findGoalTranformInChildrens ()
	{
	
		// Trying to find "Goal" transform if not set inside Trigger inspector
		Component[] childrensGameObject = gameObject.GetComponentsInChildren (typeof(Transform));
		Transform goalTransformFounded = null;
		foreach (Component c in childrensGameObject) {
			if (c.name.Equals ("Goal")) {
				goalTransformFounded = (Transform)c;
			}
		}		
		return goalTransformFounded;
		
	}
}
