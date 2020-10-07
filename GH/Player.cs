using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public float speed;
	public bool isTouchTop;
	public bool isTouchBottom;
	public bool isTouchRight;
	public bool isTouchLeft;
	
	public GameObject bulletObjA;
	public GameObject bulletObjB;
	
	public Transform pos;
	public Sprite CurrentSprite;
	public Sprite NextSprite;
	
	public bool ani_ing;
	//public AniPlane aniPlane;
	
	private BoxCollider2D boxCollider;
	private SpriteRenderer spriteRenderer;
	
	private bool sit_ing;
	
	Animator anim;
    // Start is called before the first frame update
    void Start()
    {
		boxCollider = GetComponent<BoxCollider2D>();
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = CurrentSprite;
    }

    // Update is called once per frame
    void Update()
    {
		//ani_ing = aniPlane.ani_playing;
		
		//추후에 점프중이 아닌 상태검사로 아래코드들 감싸주기
		//앉기
		if(Input.GetKey(KeyCode.DownArrow)){
			spriteRenderer.sprite = NextSprite;
			sit_ing = true;
			
			//박스콜라이더 줄이는 부분
			boxCollider.size = new Vector2(0.2f, 0.6f);
			boxCollider.offset = new Vector2(0f, 0f);
		}
		
		//일어서기
		if(Input.GetKeyUp(KeyCode.DownArrow)){
			spriteRenderer.sprite = CurrentSprite;
			sit_ing = false;
			
			//박스콜라이더 원상복귀 부분
			boxCollider.size = new Vector2(0.2f, 0.8f);
			boxCollider.offset = new Vector2(0f, 0f);
		}
		//transform.Rotate(0, 0, 360 * Time.deltaTime);
    }
	
}
