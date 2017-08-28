using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missle : MonoBehaviour {

    public float missleSpeed;
    public float acceleration;

    // Use this for initialization
    void Start () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, missleSpeed);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        GetComponent<Rigidbody2D>().AddForce(transform.up * acceleration);
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(gameObject);
        }
            

	}
}
