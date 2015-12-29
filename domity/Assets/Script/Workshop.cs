using UnityEngine;
using System.Collections;

public class Workshop : MonoBehaviour {

  Card card;

  public void Action(){
    card.Owner.GetComponent<Player>().SetGetParam(4,isA:true);
    card.EndEvent ();
  }

	// Use this for initialization
	void Start () {
    card = gameObject.GetComponent<Card>();
	}
	
	// Update is called once per frame
	void Update () {
    if (card.Event){
      Action();
    }
	}

}
