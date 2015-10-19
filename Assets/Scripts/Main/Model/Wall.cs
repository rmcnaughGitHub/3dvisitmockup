using UnityEngine;
using System.Collections;
using Holoville.HOTween;
using Holoville.HOTween.Plugins;

public class Wall : MonoBehaviour
{
	
	public float defaultAlphaTransparency = 0.5f;
	
	void wallsTransparent (bool isTransparent)
	{
		float alpha = (isTransparent) ? defaultAlphaTransparency : 1.0f;
		Color tmpColor = renderer.material.color;
		tmpColor.a = alpha;
		HOTween.To (gameObject.renderer.material, 1, new TweenParms ().Prop ("color", tmpColor));
	}
}
