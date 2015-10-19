using System;

public static class Messages
{
	
	#region Camera messages
	public const string cameraMoveComplete = "cameraMoveComplete";
	public const string cameraMoveStart = "cameraMoveStart";
	#endregion
	
	#region Visit state messages
	public const string listenForNewGoal = "listenForNewGoal";
	public const string stateChanged = "stateChanged";
	public const string wallsTransparent = "wallsTransparent";
	public const string guidedVisitRequested = "guidedVisitRequested";
	public const string guidedVisitEnded = "guidedVisitEnded";
	
	#endregion
	
	#region Markers and GUI messages
	public const string enableMarkerByTag = "enableMarkerByTag";
	public const string showOnlyMarkerByTag = "showOnlyMarkerByTag";
	public const string hideMaker = "hideMaker";
	public const string arrowPressedGUI = "arrowPressedGUI";
	#endregion
}


