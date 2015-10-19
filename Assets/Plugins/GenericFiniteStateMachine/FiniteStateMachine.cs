using UnityEngine;
using System.Collections.Generic;
using System;

public class FiniteStateMachine <T,U>  {
	private T mOwner;
	private FSMState<T,U> mCurrentState;
	private FSMState<T,U> mPreviousState;
	private FSMState<T,U> mGlobalState;
	
	private Dictionary<U,FSMState<T,U>> stateRef;
	
	public void Awake()
	{		
		mCurrentState = null;
		mPreviousState = null;
		mGlobalState = null;
	}
	
	public FiniteStateMachine(T owner) {
		mOwner = owner;
		stateRef = new Dictionary<U, FSMState<T, U>>();
	}

	public void  Update()
	{
		if (mGlobalState != null)  mGlobalState.Execute();
		if (mCurrentState != null) mCurrentState.Execute();
	}
 
	public void  ChangeState(FSMState<T,U> NewState)
	{	
		mPreviousState = mCurrentState;
 
		if (mCurrentState != null)
			mCurrentState.Exit();
 
		mCurrentState = NewState;
 
		if (mCurrentState != null)
			mCurrentState.Enter();
	}
 
	public void  RevertToPreviousState()
	{
		if (mPreviousState != null)
			ChangeState(mPreviousState);
	}
		
	//Changing state via enum
	public void ChangeState(U stateID)
	{
		try
        {
            FSMState<T, U> state = stateRef[stateID];
			ChangeState(state);

        }
        catch (KeyNotFoundException)
        {
          	throw new Exception("There is no State <" + stateID + "> associated with that definition");
        }

	}
	
	public FSMState<T, U> RegisterState(FSMState<T,U> state)
	{
		state.RegisterState(mOwner);
		stateRef.Add(state.StateID, state);
		return state;
	}
	
	public void UnregisterState(FSMState<T,U> state)
	{
		stateRef.Remove(state.StateID);
		
	}

	public FSMState<T, U> CurrentState {
		get {
			return this.mCurrentState;
		}
		set {
			mCurrentState = value;
		}
	}

	public FSMState<T, U> PreviousState {
		get {
			return this.mPreviousState;
		}
		set {
			mPreviousState = value;
		}
	}
};