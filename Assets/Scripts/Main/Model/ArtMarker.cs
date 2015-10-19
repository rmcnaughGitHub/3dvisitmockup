using UnityEngine;
using System.Collections;

public class ArtMarker : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SetVisible(false);
	}
	
	/// <summary>
	/// MessageReceiver : Enables the marker by tag.
	/// </summary>
	/// <param name='artMarkerMessage'>
	/// Art marker message.
	/// </param>
	void enableMarkerByTag(ArtMarkerMessage artMarkerMessage) {
		
		if(gameObject.tag.Equals(artMarkerMessage.Tag)) {
			SetVisible(artMarkerMessage.Visible);
		}
	}
	/// <summary>
	/// MessageReceiver : Shows the only marker by tag.
	/// </summary>
	/// <param name='artMarkerTag'>
	/// Art marker tag.
	/// </param>
	void showOnlyMarkerByTag(string artMarkerTag) {
		if(gameObject.tag.Equals(artMarkerTag)) {
			SetVisible(true);
		} else {
			SetVisible(false);
		}
	}
	/// <summary>
	/// MessageReceiver : Hides the maker.
	/// </summary>
	void hideMaker() {
		SetVisible(false);
	}
	
	void SetVisible(bool visible) {
		renderer.enabled = visible;
	}

}
