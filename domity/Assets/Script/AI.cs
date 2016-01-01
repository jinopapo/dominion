using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class AI : MonoBehaviour {

  Player player;

  bool IsMove(){
    foreach (var obj in player.field){
      if (obj.GetComponent<Card>().IsMove){
        return true;
      }
    }
    return false;
  }

  int  CountSupply(){
    Supply s = player.supply;
    int end = 0;
    if (s.coppers.Count == 0) {
      end++;
    }
    if (s.slivers.Count == 0) {
      end++;
    }
    if (s.golds.Count == 0) {
      end++;
    }
    if (s.landtags.Count == 0) {
      end++;
    }
    if (s.mansions.Count == 0) {
      end++;
    }
    if (s.provinces.Count == 0) {
      end++;
    }
    foreach (var ss in s.supplys) {
      if (ss.Count == 0) {
        end++;
      }
    }
    return end;
  }

  int CompActionCard(GameObject a,GameObject b){
    if (a.GetComponent<Card>().Action < b.GetComponent<Card>().Action){
      return 1;
    } else if (a.GetComponent<Card>().Action > b.GetComponent<Card>().Action){
      return -1;
    } else{
      if (a.GetComponent<Card>().Draw < b.GetComponent<Card>().Draw){
        return 1;
      } else if (a.GetComponent<Card>().Draw > b.GetComponent<Card>().Draw){
        return -1;
      } else{
        return 0;
      }
    }
  }

  bool ActionInHand(){
    foreach (var obj in player.hands){
      if (obj.GetComponent<Card>().IsAction){
        return true;
      }
    }
    return false;
  }

  void PlayAction(){
    List<GameObject> plist = new List<GameObject>();
    if(ActionInHand()){
      foreach (var obj in player.hands){
        if (obj.GetComponent<Card>().IsAction){
          plist.Add(obj);
        }
      }
    }
    plist.Sort(CompActionCard);
    foreach(var card in plist){
      card.GetComponent<Card>().Play();
      print("player:" + card.name);
      if (player.Action <= 0)
        break;
    }
  }

  void SelectTrash(){
    player.selectMode = true;
    while (player.HandsCount() - player.CountSelected() > 3){
      bool flag = false;
      int action = 0;
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

  void GetDeckInfo(List<GameObject> list, ref int a, ref int aa, ref int m, ref int am, ref int d){
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

  bool BuyAction(int ave, int num){
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
    bool flag = true;
    foreach (var objs in player.supply.supplys){
      foreach (var obj in objs){
        if (obj.name == name){
          obj.GetComponent<Card>().Purued(player.gameObject);
          flag = false;
        }
      }
    }
    if (flag)
      name = "";
    print("buy:" + name);
    return name == "";
  }

  bool BuyMoney(){
    if (player.Money >= 6){
      print("buy:gold");
      foreach (var obj in  player.supply.golds){
        obj.GetComponent<Card>().Purued(player.gameObject);
      }
    } else if (player.Money >= 3){
      print("buy:silver");
      foreach (var obj in  player.supply.slivers){
        obj.GetComponent<Card>().Purued(player.gameObject);
      }
    } else{
      return false;
    }
    return true;
  }

  bool BuyVpoint(){
    if (player.Money >= 8){
      print("buy:province");
      player.supply.provinces[0].GetComponent<Card>().Purued(player.gameObject);
    } else if (CountSupply() >= 2){
      if (player.Money >= 5){
        print("buy:lnadtag");
        player.supply.landtags[0].GetComponent<Card>().Purued(player.gameObject);
      } else if (player.Money >= 2){
        print("buy:mansion");
        player.supply.mansions[0].GetComponent<Card>().Purued(player.gameObject);
      }
    } else{
      return false;
    }
    return true;
  }

  bool BuyCard(){
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
    if (player.Money < 8 || CountSupply() < 2){
      if (aveAction + 1 > actionCard / (deckNum / 5)){
        if (BuyAction(aveAction, actionCard / (deckNum / 5))){
          return BuyMoney();
        } else{
          return true;
        }
      } else{
        return BuyMoney();
      }
    } else{
      return BuyVpoint();
    }
  }

  public void Play(){
    if (!IsMove()){
      if (ActionInHand() && player.Action > 0){
        PlayAction();
    } else if (player.Purchase > 0 && BuyCard()){
    } else{
        if (gameObject.GetComponent<Player>().Turn){
          transform.GetComponentInParent<GameMaster>().NextPlayer();
      }
        gameObject.GetComponent<Player>().EndTurn();
    }
    }
	}

  // Use this for initialization
  void Start() {
    player = gameObject.GetComponent<Player>();
	}
	
  // Update is called once per frame
  void Update() {
    if (player.Turn){
      Play();
    }
    foreach (var card in player.field){
      if (card.GetComponent<Militia>() && card.GetComponent<Card>().Event){
        if (!player.DiscardAttackEnd(3)){
          SelectTrash();
        }
      }
  	}
  }
}
