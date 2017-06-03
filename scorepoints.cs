using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scorepoints : MonoBehaviour {


	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "Player") {
			Scored.AddPoint ();
		}
	}
}
