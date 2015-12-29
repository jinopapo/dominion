
using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {

  Player player;

  void SelectTrash(){
    player.selectMode = true;
    while (player.HandsCount() - player.CountSelected() > 3){
      int ind = (int)(Random.value * (player.HandsCount() - player.CountSelected()));
      if(!player.hands[ind].GetComponent<Card>().IsSelected)player.hands[ind].GetComponent<Card>().Selected();
    }
    player.selectMode = false;
  }

	public void Play(){
		gameObject.GetComponent<Player> ().EndTurn ();
		transform.GetComponentInParent<GameMaster> ().NextPlayer ();
	}

	// Use this for initialization
	void Start () {
    player = gameObject.GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
    foreach (var card in player.field){
      if (card.GetComponent<Militia>() && card.GetComponent<Card>().Event){
        if (!player.DiscardAttackEnd(3)/*player.HandsCount() - player.CountSelected() > 3 && player.HandsCount() > 3*/){
          SelectTrash();
        }
      }
  	}
  }
}
