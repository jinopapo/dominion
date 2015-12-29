using UnityEngine;
using System.Collections;

public class Remodel : MonoBehaviour {
  Card card;


  public void Action(){
    int cost = card.Owner.GetComponent<Player>().SelectedRemove();
    card.Owner.GetComponent<Player>().SetGetParam(cost+2,true,true,true);
  }

  public bool EndAction(){
    if (card.Owner.GetComponent<Player>().CountSelected() > 1)
      return false;
    Action();
    card.EndEvent ();
    return true;
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
