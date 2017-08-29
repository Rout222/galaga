using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float Velocity;
    public GameObject SpawnLeftShoot;
    public GameObject SpawnRightShoot;
    public GameObject Missle;

    private bool leftShoting;
    private float shotingSpeed;

    // Use this for initialization
    void Start () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.name == "Enemy(Clone)")
        {
            GetComponent<Animator>().SetBool("Death", true);
        }
    }

    // Update is called 50 times per second
    void FixedUpdate () {
        float x     = Input.GetAxisRaw("Horizontal");
        float y     = Input.GetAxisRaw("Vertical");
        float shooting = Input.GetAxisRaw("Fire1");

        GameObject spawn;
        GameObject firedMissle;

        GetComponent<Rigidbody2D>().velocity = new Vector2(x * Velocity, y * Velocity);
        if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Explosion_Nave"))
        {
            return;
        }
        if(shooting > 0 && shotingSpeed < 0)
        {
            spawn = leftShoting ? SpawnLeftShoot : SpawnRightShoot;
            leftShoting = !leftShoting;
            firedMissle = Instantiate(Missle, spawn.transform.position, Quaternion.identity);
            shotingSpeed = 0.3f;
            Physics2D.IgnoreCollision(firedMissle.GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);
        } else
        {
            shotingSpeed -= Time.fixedDeltaTime;
        }
    }

    private void LateUpdate()
    {
        if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Explosion_Nave") && GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            GetComponent<Animator>().SetBool("Death", false);
            transform.position = new Vector2();
        }
    }
}
