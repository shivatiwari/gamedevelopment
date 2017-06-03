using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Birdmovement : MonoBehaviour {

//	private float maxfall = -10f;
//	private float maxjump = 10f;

	public AudioClip jumpSound;
	public AudioClip collideSound;
	public AudioSource vsource;

	private float volLowRange = .5f;
	private float volHighRange = 1.0f;
	//Vector3 velocity = Vector3.zero;
//public Vector3 gravity;
	public float flapspeed = 200f;
//	public Vector3 jumpvel;
//	public float maxvel = 20f;
//	 float forwardSpeed = 2f;

	public float maxspeed = 100f;
	public float speedreduction = 1000f;

	bool didjump = false;
	public bool dead = false;
//	Animator animator;
	public Rigidbody2D rb;
	public string levelToLoad = "MainLevel";

	float deathCooldown;
	// Use this for initialization

	void Awake () {

		vsource = GetComponent<AudioSource>();

	}


	void Start () {
		if (Input.GetMouseButtonDown (0))
		{
			rb.bodyType = RigidbodyType2D.Dynamic;
		}

		GetComponent<Rigidbody>().velocity = new Vector3(10,0,0);
    

	}

	void Update()
	{




		if (dead) {
			deathCooldown -= Time.deltaTime;
	
			if (deathCooldown <= 0) {
				if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0))
					SceneManager.LoadScene (levelToLoad);
					//Application.LoadLevel (Application.loadedLevel);
			
			}
				

		} else { 
			if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0)) {
				didjump = true;
				float vol = Random.Range (volLowRange, volHighRange);
				vsource.PlayOneShot(jumpSound,vol);
			}
		}
		Vector3 Adjustment = Vector3.zero;
		//for reducing vertical max speed /jump/
		if (transform.GetComponent<Rigidbody>().velocity.y > maxspeed)
		{
			Adjustment.y += -speedreduction;
		}
		if (transform.GetComponent<Rigidbody>().velocity.y < -maxspeed)
		{
			Adjustment.y += speedreduction;
		}
		GetComponent<Rigidbody>().velocity += Adjustment;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (dead)
			return;

	

		if (didjump) {
			GetComponent<Rigidbody> ().AddForce (Vector2.up * flapspeed);


			didjump = false;
		}
		//for player rotation /animation/
		if (GetComponent<Rigidbody> ().velocity.y > 0) {
			transform.rotation = Quaternion.Euler (0, 0, 0);
		}
			else{
				
			float angle = Mathf.Lerp (0, -50, -GetComponent<Rigidbody>().velocity.y / 4f);
			transform.rotation = Quaternion.Euler (0, 0, angle);
		}

	}
	void OnCollisionEnter(Collision collision)
	{
		

		dead = true;
		deathCooldown = 0.5f;
		vsource.PlayOneShot (collideSound, 1f);

	}

}
