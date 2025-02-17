using UnityEngine;

public class waypoints : MonoBehaviour {

	[Header ("Unity Variables")]
	public static Transform[] wps; // Waypoint array

	//Find Objects that are a child of Waypoints 
	void Awake(){ 
		wps = new Transform[transform.childCount]; //X children

		for (int i = 0; i < wps.Length; i++) {
			wps[i] = transform.GetChild (i); //Set each child as a waypoint Transform object
		}
	}
}
