using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGlooper : MonoBehaviour {

	int numBGPannels =12;

	float pipemax = 10f;
	float pipemin = 5.5f;

	void OnTriggerEnter(Collider collider)
	{

//		Debug.Log ("Triggered" + collider.name);


		float widthofBGobject= ((BoxCollider)collider).size.x;
		Vector3 pos = collider.transform.position;
		pos.x += widthofBGobject * numBGPannels;


		if (collider.tag == "Pipe") {
			pos.y = Random.Range (pipemin, pipemax);
		}
		collider.transform.position = pos;
	}



}
