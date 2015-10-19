using System;

public class ArtMarkerMessage
{
	private string tag;
	private bool visible;

	public ArtMarkerMessage (string tag, bool visible)
	{
		this.tag = tag;
		this.visible = visible;
	}

	public string Tag {
		get {
			return this.tag;
		}
	}

	public bool Visible {
		get {
			return this.visible;
		}
	}
}


