using UnityEngine;
using System.Collections;

public class CardMove : MonoBehaviour {
  private float startTime;
  private Vector3 startPosition;
  private Vector3 endPosition;
  public Vector3 movePoint;
  float time;

  public bool IsMove {get {return endPosition != transform.localPosition;}}

  public void PositionUpdate(Vector3 position, float t = (float)0.5, bool local = true){
    GameObject owner = gameObject.GetComponent<Card>().Owner;
    if (position != endPosition) {
      if (owner != null){
        transform.rotation = owner.transform.rotation;
      }
      time = t;
      startPosition = transform.localPosition;
      if (local) {
        endPosition = position;
      } else {
        endPosition = transform.InverseTransformDirection(position);
      }
      startTime = Time.timeSinceLevelLoad;
    }
  }

  void Move(){
    var diff = Time.timeSinceLevelLoad - startTime;
    if (diff > time) {
      transform.localPosition = endPosition;
    }
    if (endPosition != transform.localPosition) {
      float rate = 0.0f;
      if(time != 0)rate = diff / time;
      transform.localPosition = Vector3.Lerp(startPosition, endPosition, rate);
    }
  }

	// Use this for initialization
	void Awake () {
    endPosition = transform.position;
    startTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
    Move();
	}
}
