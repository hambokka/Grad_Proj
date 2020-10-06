using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float speed;
	
	private Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
		rigid = GetComponent<Rigidbody2D>();
		
        Invoke("DestroyBullet", 2);
    }

    // Update is called once per frame
    void Update()
    {
		rigid.velocity = transform.right * speed;
        //transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
	
	
    void OnTriggerEnter2D(Collider2D collision)
    {
		/*
		if(other.tag == "Enemy"){
			//Play Particle or 음악재생
			ParticleSystem instance = Instantiate(explosionParticle, transform.position, Quaternion.identity);
			instance.Play();
			Destroy(instance.gameObject, instance.main.duration);
			
			//Take Dame
			//데이미처리 구현은 이부분부터
			
			Destroy(gameObject);
		}*/
		
        if(collision.gameObject.tag == "BorderBullet"){
			Destroy(gameObject);
		}
    }
	
	

}
