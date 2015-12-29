using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cellar : MonoBehaviour {

  Card card;


  void Action(int count){
		card.Owner.GetComponent<Player>().SelectedTrash();
	  card.Owner.GetComponent<Player>().Draw(count);
  }

  public void EndAction(){
		Action(card.Owner.GetComponent<Player>().CountSelected());
		card.EndEvent ();
  }
	
  // Use this for initialization
  void Start () {
    card = gameObject.GetComponent<Card>();
  }

  // Update is called once per frame
  void Update () {
    if (card.Event){
      card.Owner.GetComponent<Player>().selectMode = true;
    }
  }
}
