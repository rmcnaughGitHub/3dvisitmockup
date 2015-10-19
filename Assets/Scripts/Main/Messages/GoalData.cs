using UnityEngine;
using System.Collections;

[System.Serializable]
public class GoalData
{
	
	public Transform mTransform;
	public float mMoveTime = 2.0f;
	public VisitStates mVisitStateLevel;
	public GameObject mIniator;
	public string comments;
	
	public GoalData (Transform mTransform, float mMoveTime, VisitStates mVisitStateLevel, GameObject iniator)
	{
		this.mTransform = mTransform;
		this.mMoveTime = mMoveTime;
		this.mVisitStateLevel = mVisitStateLevel;
		this.mIniator = iniator;
	}

}
