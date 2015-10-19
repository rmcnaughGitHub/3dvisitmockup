using UnityEngine;
using System.Collections;

public class CategoriesManager : MonoBehaviour
{
	
	#region Static classes for management
	public static class CategoriesTags
	{
		public const string ArtMarkerFamous = "ArtMarkerFamous";
		public const string ArtMarkerModern = "ArtMarkerModern";
		public const string ArtMarkerSculpture = "ArtMarkerSculpture";
	}

	public static class CategoriesId
	{
		public const int None = 0;
		public const int Famous = 1;
		public const int Modern = 2;
		public const int Sculpture = 3;
	}
	#endregion
	
	public GameObject mCategorieGUI;
	public GUIText mCatTitle;
	private string[] mCategoriesList = new string[]{"Catégories\nd'Oeuvres", "Célèbres", "Modernes", "Sculptures"};
	private int mCurCatId = CategoriesId.None;
	
	// Use this for initialization
	void Start ()
	{
		if(mCategoriesList.Length == 0) {
			throw new UnityException("mCategoriesList cannot be empty. Please add Categories inside GO inspector");
		}
		// Setup defaults
		updateCategorieTitle ();
		updateVisibleMarkers ();
		updateVisibleGUIArrows ();
	}
	
	/// <summary>
	/// Arrows pressed. Message send by CategorieArrowGUI behaviour
	/// Tell if user pressed Previous or Next arrow
	/// </summary>
	/// <param name='arrowType'>
	/// Arrow type.
	/// </param>
	void arrowPressedGUI(CategorieArrowGUI.Type arrowType) {
		
		// Next presed
		if(arrowType.Equals (CategorieArrowGUI.Type.Next)) {
			if(mCurCatId < mCategoriesList.Length - 1) {
				mCurCatId++; // Increment
			}
			
		} 
		// Previous presed
		else if(arrowType.Equals (CategorieArrowGUI.Type.Previous)) {
			
			mCurCatId--; // Descrease
			if(mCurCatId < 0) mCurCatId = CategoriesId.None;
		}
		
		updateCategorieTitle ();
		updateVisibleMarkers ();
		updateVisibleGUIArrows ();
	}

	void updateCategorieTitle ()
	{
		mCatTitle.text = mCategoriesList[mCurCatId];
	}

	void updateVisibleMarkers ()
	{
		
		switch(mCurCatId) {
			
			case CategoriesId.None:
				hideAllMarkers();
			break;
			
			case CategoriesId.Famous:
				showOnlyMakersWithTag(CategoriesTags.ArtMarkerFamous);
			break;
			
			case CategoriesId.Modern:
				showOnlyMakersWithTag(CategoriesTags.ArtMarkerModern);
			break;
			
			case CategoriesId.Sculpture:
				showOnlyMakersWithTag(CategoriesTags.ArtMarkerSculpture);
			break;
			
		}
	}

	void updateVisibleGUIArrows ()
	{
		if(mCurCatId == 0) {
			BroadcastMessage("setGUIArrowPreviousVisible", false);
		} else {
			BroadcastMessage("setGUIArrowPreviousVisible", true);
		}
		
		if(mCurCatId == mCategoriesList.Length - 1) {
			BroadcastMessage("setGUIArrowNextVisible", false);
		}else {
			BroadcastMessage("setGUIArrowNextVisible", true);
		}
	}
	
	/// <summary>
	/// Shows the only makers with tag.
	/// </summary>
	/// <param name='artMarkerTag'>
	/// Art marker tag.
	/// </param>
	void showOnlyMakersWithTag (string artMarkerTag)
	{
		BroadcastMessage (Messages.showOnlyMarkerByTag, artMarkerTag);	
	}
	
	/// <summary>
	/// Hides all markers.
	/// </summary>
	/// <exception cref='System.NotImplementedException'>
	/// Is thrown when the not implemented exception.
	/// </exception>
	void hideAllMarkers() {
		BroadcastMessage (Messages.hideMaker);	
	}
	
	/// <summary>
	/// States the changed received here from VisitManager
	/// </summary>
	/// <param name='state'>
	/// State given by the Visit Manager
	/// </param>
	void stateChanged (VisitStates state)
	{
		bool inPlanState = (state == VisitStates.Plan);
		mCategorieGUI.SetActive(inPlanState);
		if(inPlanState) {
			updateVisibleMarkers();
		} else {
			hideAllMarkers();	
		}
	}
}
