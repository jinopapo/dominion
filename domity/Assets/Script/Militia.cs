using UnityEngine;
using System.Collections;

public class Militia : MonoBehaviour {
  Card card;

  void Action(){
    if (card.Owner.GetComponent<Player>().OtherDiscardAttackEnd(3)){
      card.EndEvent ();
      card.Owner.GetComponent<Player>().OtherDiscard();
    }
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
