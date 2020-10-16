using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
	public float ShakeAmout;
	//public Canvas canvas;
	float ShakeTime;
	Vector3 initialPosition;
	
	public void VibrateForTime(float time)
	{
		ShakeTime = time;
		//canvas.renderMode = RenderMode.ScreenSpaceCamera;
		//canvas.renderMode = RenderMode.WorldSpace;
	}
	
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = new Vector3(0f, 0f, -10f);
    }

    // Update is called once per frame
    void Update()
    {
        if(ShakeTime > 0){
			transform.position = Random.insideUnitSphere * ShakeAmout + initialPosition;
			ShakeTime -= Time.deltaTime;
		}
		else{
			ShakeTime = 0.0f;
			transform.position = initialPosition;
			//canvas.renderMode = RenderMode.ScreenSpaceCamera;
		}
    }
}
