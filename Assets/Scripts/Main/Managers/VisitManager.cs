using UnityEngine;
using System.Collections;
using Holoville.HOTween;
using Holoville.HOTween.Plugins;

public class VisitManager : MonoBehaviour
{
	
	/// <summary>
	/// The camera manager.
	/// </summary>
	private CameraManager mCameraManager;
	private bool mCameraMoving = false;
	
	/// <summary>
	/// The default plan goal data.
	/// </summary>
	public GoalData defaultPlanGoalData = null;
	
	/// <summary>
	/// The goals stack, the Ariane rope...
	/// </summary>
	public Stack mGoalsStack = new Stack ();
	
	/// <summary>
	/// The state of the visit.
	/// </summary>
	public VisitStates mVisitState = VisitStates.Plan;
	public int currentStackCount = 999999;
	
	
	// Use this for initialization
	void Start ()
	{

		mCameraManager = Camera.main.gameObject.GetComponent<CameraManager> (); // Getting camera manager refrence		
		
		// Init hotween config
		HOTween.Init (false, false, true);
		HOTween.EnableOverwriteManager (true);
		
		SendMessage (Messages.listenForNewGoal, defaultPlanGoalData);	// Notify the first goal data
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		currentStackCount = mGoalsStack.Count;
		
//		handleVisitFSM ();
		
		if (Input.GetKeyDown (KeyCode.Escape)) { // Back
			// If Camera don't moves
			// And we are not in visit guided then
			// We can get back into stack
			if (!mCameraMoving 
				&& mVisitState != VisitStates.Guided) {
				back ();
			}
		}
	}
	
	/// <summary>
	/// Handles the visit FSM.
	/// </summary>
	void handleVisitFSM ()
	{
		
		// What to do depending on state we are
		switch (mVisitState) {
						
		case VisitStates.Plan:
//				handleBack ();
			break;
			
		case VisitStates.Room:
//				handleBack ();
			break;
			
		case VisitStates.Art:
//				handleBack ();
			break;
		}
		
	}
	
	/// <summary>
	/// Handles the back.
	/// </summary>
	void back ()
	{
		
		// Return from Root State (Plan)
		if (mGoalsStack.Count == 1) {
			Debug.Log ("Exit");
			Application.Quit ();
			
		} else { // Return from NonRoot State ( Room, Art, ...)
		
			// Reactivate "disabled collider" on last element
			// This ensure to reclick/touch it back
			GoalData currentGoalData = (GoalData)mGoalsStack.Peek ();
			currentGoalData.mIniator.collider.enabled = true;
				
			// then remove it 
			mGoalsStack.Pop (); 
				
			// Now get back to previous goal
			GoalData previousGoalData = (GoalData)mGoalsStack.Peek ();
				
			mCameraManager.moveToGoal (previousGoalData); // Move cam to previous
				
			changeState (previousGoalData.mVisitStateLevel); // Change state
		}
		
	}
	
	/// <summary>
	/// Listens for new goal.
	/// </summary>
	/// <param name='goalData'>
	/// Goal data.
	/// </param>
	void listenForNewGoal (GoalData goalData)
	{
		
		if (!mCameraMoving) {
		
			// Switch state from new goal
			changeState (goalData.mVisitStateLevel); 
			
			// Push new goal wanted to stack
			mGoalsStack.Push (goalData); 
			
			// Move that f**king cam to the given goal
			mCameraManager.moveToGoal (goalData); 
			
			// Desactivate Goal Collider we have touched/clicked
			// This to avoid to reclick again on 
			// And ensure that stack is not increased with same goal
			if (goalData.mIniator != null) {
				goalData.mIniator.collider.enabled = false;
			}
			
		}

	}
	
	/// <summary>
	/// Changes the state and perfom some actions
	/// </summary>
	/// <param name='newState'>
	/// New state.
	/// </param>
	void changeState (VisitStates newState)
	{
		mVisitState = newState;
		/*
		// What to do depending on state when just changing state
		switch (newState) {
						
			case CategoriesState.Plan:
				notifyWallsToBeTransparent (false);
			break;
			
			case CategoriesState.Room:
				notifyWallsToBeTransparent (true);
			break;
			
			case CategoriesState.Art:
				notifyWallsToBeTransparent (false);
			break;
		}*/
		
		BroadcastMessage (Messages.stateChanged, mVisitState); // Prevent others component...
	}
	
	#region Camera message receivers
	void cameraMoveStart ()
	{
		mCameraMoving = true;
	}

	void cameraMoveComplete ()
	{
		mCameraMoving = false;
	}
	#endregion
	
	#region Guided visit messages
	
	void guidedVisitRequested ()
	{
		changeState (VisitStates.Guided); 
		BroadcastMessage ("launchGuidedVisit"); // TODO ...
//		mCameraMoving = true;
	}

	void guidedVisitEnded ()
	{
		
		if (mVisitState == VisitStates.Guided) {
			
			GoalData latestGoalData = (GoalData)mGoalsStack.Peek ();
			mCameraManager.moveToGoal (latestGoalData);
			changeState (latestGoalData.mVisitStateLevel); // Change state
			
//			SendMessage(Messages.listenForNewGoal, defaultPlanGoalData); // Get back to default plan
		}
	}
	
	#endregion
	
	#region GetSet
	public CameraManager CameraManager {
		get {
			return this.mCameraManager;
		}
		set {
			mCameraManager = value;
		}
	}
	#endregion
}
