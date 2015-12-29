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

  void GetDeckInfo(List<GameObject> list,ref int a,ref int aa,ref int m,ref int am,ref int d){
    foreach (var obj in list){
      Card card = obj.GetComponent<Card>();
      if (card.IsMoney){
        m++;
        am += card.Money;
      }
      if (card.IsAction){
        a++;
        aa += card.Action;
      }
      d++;
    }
  }

  bool BuyAction(int ave,int num){
    string name = "";
    if (player.Money >= 5){
      name = "Market";
    } else if (ave > num){
      if (player.Money >= 4){
        name = "Blacksmith";
      } else if (player.Money >= 2){
        name = "Moat";
      }
    } else if (player.Money >= 3){
      name = "Village";
    }
    foreach (var objs in player.supply.supplys){
      foreach (var obj in objs){
        if (obj.name == name){
          obj.GetComponent<Card>().Purued(player.gameObject);
        }
      }
    }
    return name == "";
  }

  void BuyMoney(){
    if (player.Money >= 6){
      foreach (var obj in  player.supply.golds){
        obj.GetComponent<Card>().Purued(player.gameObject);
      }
    } else if (player.Money >= 3){
      foreach (var obj in  player.supply.slivers){
        obj.GetComponent<Card>().Purued(player.gameObject);
      }
    }
  }

  void BuyVpoint(){
    if (player.Money >= 8){
      player.supply.provinces[0].GetComponent<Card>().Purued(player.gameObject);
    }
  }

  void BuyCard(){
    int actionCard = 0;
    int aveMoney = 0;
    int moneyCard = 0;
    int aveAction = 0;
    int deckNum = 0;
    GetDeckInfo(player.hands, ref actionCard, ref aveAction, ref moneyCard, ref aveMoney, ref deckNum);
    GetDeckInfo(player.deck, ref actionCard, ref aveAction, ref moneyCard, ref aveMoney, ref deckNum);
    GetDeckInfo(player.trash, ref actionCard, ref aveAction, ref moneyCard, ref aveMoney, ref deckNum);
    if (actionCard != 0){
      aveAction /= (deckNum / 5);
    }
    if (moneyCard != 0){
      aveMoney /= (deckNum / 5);
    }
    if (player.Money < 8){
      if (aveAction + 1 > actionCard / (deckNum / 5)){
        if (!BuyAction(aveAction, actionCard / (deckNum / 5))){
          BuyMoney();
        }
      } else{
        BuyMoney();
      }
    } else{
      BuyVpoint();
    }
  }

	public void Play(){
    BuyCard();
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
        if (!player.DiscardAttackEnd(3)){
          SelectTrash();
        }
      }
  	}
  }
}
