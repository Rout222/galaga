using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Explosion_Enemy"))
        {
            Destroy(gameObject);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.name == "Missle(Clone)")
        {
            GetComponent<Animator>().SetBool("Death", true);
            Destroy(collision.gameObject);
        } else if(collision.collider.name == "EnemyTarget1")
        {   
            Destroy(gameObject);
        }
        
    }
}
