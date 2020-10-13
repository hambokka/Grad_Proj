using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public float speed;
	public float jumpPower;
	//public bool isTouchTop;
	//public bool isTouchBottom;
	//public bool isTouchRight;
	//public bool isTouchLeft;
	public bool isStand = true;
    public bool isProne = false;
    public bool isCrouch = false;
    
	
	public GameObject bulletObjA;
	public GameObject bulletObjB;
	
	public Transform pos;
	public Sprite CurrentSprite; // 평상시 서있는 스프라이트
	public Sprite Sprite_00;	// 앉는 스프라이트
	public Sprite Sprite_01;	// 엎드리는 스프라이트
	
	//public bool ani_ing;
	//public AniPlane aniPlane;
	
	private BoxCollider2D boxCollider;
	private SpriteRenderer spriteRenderer;
	private Rigidbody2D rigid;
	
	private bool sit_ing;
	private bool right = true;
	private bool isGrounded = true;
	
	Animator anim;
    // Start is called before the first frame update
    void Start()
    {
		rigid = GetComponent<Rigidbody2D>();
		boxCollider = GetComponent<BoxCollider2D>();
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = CurrentSprite;
    }

    // Update is called once per frame
    void Update()
    {
		//ani_ing = aniPlane.ani_playing;
		Vector2 len = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		
		//방향전환
		if (len.x < -0.3){
			if(right == true){
				transform.Rotate(0,180,0);
				right = false;
			}
        }
		if (len.x > 0.3){
			if(right == false){
				transform.Rotate(0,180,0);
				right = true;
			}
        }
		
		//이동
		if (Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("Horizontal") < 0){
            if (isStand){
				if(right){
					transform.Translate(new Vector2(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0f));
				}
				else{
					transform.Translate(new Vector2(-1*Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0f));
				}
            }
            else if (isCrouch){
				if(right){
					transform.Translate(new Vector2(Input.GetAxisRaw("Horizontal") * speed * 0.5f * Time.deltaTime, 0f));
				}
				else{
					transform.Translate(new Vector2(-1*Input.GetAxisRaw("Horizontal") * speed * 0.5f * Time.deltaTime, 0f));
				}
            }
            else if (isProne){
				if(right){
					transform.Translate(new Vector2(Input.GetAxisRaw("Horizontal") * speed * 0.2f * Time.deltaTime, 0f));
				}
				else{
					transform.Translate(new Vector2(-1*Input.GetAxisRaw("Horizontal") * speed * 0.2f * Time.deltaTime, 0f));
				}
            }
        }
		
		//점프중이 아닌 상태검사로 아래코드들 감싸준 부분
		if(isGrounded == true){
			//점프
			if(Input.GetKey(KeyCode.UpArrow) && Mathf.Abs(rigid.velocity.y) < 0.01f){
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            //isGrounded = false; 계속 false로 된다ㅠㅠ
			}
			
			//앉기
			if(Input.GetKey(KeyCode.DownArrow)){
				spriteRenderer.sprite = Sprite_00;
				sit_ing = true;
				
				//박스콜라이더 줄이는 부분
				boxCollider.size = new Vector2(0.2f, 0.6f);
				boxCollider.offset = new Vector2(0f, 0f);
			}
			//앉기-일어서기 복구
			if(Input.GetKeyUp(KeyCode.DownArrow)){
				spriteRenderer.sprite = CurrentSprite;
				sit_ing = false;
				
				//박스콜라이더 원상복귀 부분
				boxCollider.size = new Vector2(0.2f, 0.8f);
				boxCollider.offset = new Vector2(0f, 0f);
			}
			
			//엎드리기
			if(Input.GetKey(KeyCode.C)){
				spriteRenderer.sprite = Sprite_01;
				sit_ing = true;
				
				//박스콜라이더 줄이는 부분
				boxCollider.size = new Vector2(0.836f, 0.3f);
				boxCollider.offset = new Vector2(0f, 0f);
			}
			//엎드리기-일어서기 복구
			if(Input.GetKeyUp(KeyCode.C)){
				spriteRenderer.sprite = CurrentSprite;
				sit_ing = false;
				
				//박스콜라이더 원상복귀 부분
				boxCollider.size = new Vector2(0.2f, 0.8f);
				boxCollider.offset = new Vector2(0f, 0f);
			}
		}
		//transform.Rotate(0, 0, 360 * Time.deltaTime);
    }
	
	void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            //print("1");
            isGrounded = true;
        }
    }
	
}
