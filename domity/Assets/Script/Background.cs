using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

	public const float PixelToUnits = 100.0f; 
	public const int BaseScreenWidth = 1080; 
	public const int BaseScreenHeight = 720; 

	// Use this for initialization
	void Start () {
		var camera = gameObject.GetComponent<Camera>();
		camera.orthographicSize = BaseScreenHeight / PixelToUnits / 2; 
		float baseAspect = (float)BaseScreenHeight / (float)BaseScreenWidth; 
		float nowAspect = (float)Screen.height/(float)Screen.width; 
		float changeAspect; 

		if( baseAspect > nowAspect ) 
		{ 
			changeAspect = nowAspect / baseAspect; 
			camera.rect = new Rect( ( 1.0f - changeAspect ) * 0.5f, 0.0f, changeAspect, 1.0f ); 
		} 
		else 
		{ 
			changeAspect = baseAspect / nowAspect; 
			camera.rect = new Rect( 0.0f, ( 1.0f - changeAspect ) * 0.5f, 1.0f, changeAspect ); 
		} 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
