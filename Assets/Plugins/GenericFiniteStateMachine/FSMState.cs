using System;
using UnityEngine;

public class FSMState <T, U>  {
	
	protected T mOwner;
	
	/// <summary>
	/// Registers the entity to the state
	/// </summary>
	/// <param name='owner'>
	/// Entity.
	/// </param>
	/// 
	public void RegisterState(T owner)
	{
		this.mOwner = owner;
	}
	
	virtual public U StateID 
	{
		get{
			throw new ArgumentException("State ID not spicified in child class");
		}
	}

	virtual public void Enter (){}
		
	virtual public void Execute (){}

	virtual public void Exit(){}
}
