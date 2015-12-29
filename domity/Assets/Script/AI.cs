using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class AI : MonoBehaviour {

  Player player;

  void SelectTrash(){
    player.selectMode = true;
    while (player.HandsCount() - player.CountSelected() > 3){
      bool flag = false;
      int action=0;
      int actionNum = 0;
      List<GameObject> actions = new List<GameObject>();
      foreach (var card in player.hands){
        if (!card.GetComponent<Card>().IsAction && !card.GetComponent<Card>().IsMoney && !flag && !card.GetComponent<Card>().IsSelected){
          card.GetComponent<Card>().Selected();
          flag = true;
        }
        if (card.GetComponent<Card>().IsAction && !card.GetComponent<Card>().IsSelected){
          actions.Add(card);
          action += card.GetComponent<Card>().Action;
          actionNum++;
        }
      }
      if (!flag){
        if (action < actionNum && actions.Count > 0){
          actions[0].GetComponent<Card>().Selected();
        } else{
          GameObject minObj = player.hands[0];
          int minMoney = 100;
          foreach (var card in player.hands){
            if (minMoney < card.GetComponent<Card>().Money){
              minObj = card;
            }
          }
          minObj.GetComponent<Card>().Selected();
        }
      }
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
