using UnityEngine;
using System.Collections;

public class GoogleAnalyticsClient : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
		
		if (Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork) {
			GoogleAnalyticsHelper.Settings ("UA-40552192-1", "http://www.g3zarstudios.com");
//		    logEvent ("lauchapp", "start", 0);

		}
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
