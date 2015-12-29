using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class Player : MonoBehaviour{
  [SerializeField] private Vector3 handPosition;
  [SerializeField] private Vector3 removePosition;
  [SerializeField] private Vector3 trashPosition;
  [SerializeField] private Vector3 deckPosition;
  [SerializeField] GameObject copper;
  [SerializeField] GameObject mansion;

  public List<GameObject> deck;
  public List<GameObject> hands;
  public List<GameObject> trash;
  public List<GameObject> selected;
  public bool selectMode;
  public List<GameObject> field;
  public Supply supply;
  List<GameObject> remove;
  List<GameObject> otherPlayers = new List<GameObject>();
  bool turn;
  bool getAction;
  bool getMoney;
  bool getVpoint;
  bool getHand;
  int action;
  int money;
  int purchase;
  int cost;



  public bool Turn { get { return turn; } }

  public int Money { get { return money; } }

  public int Action { get { return action; } }

  public int Purchase { get { return purchase; } }

  public int Cost { get { return cost; } }

  public bool GetAction{ get { return getAction; } }

  public bool GetMoney{ get { return getMoney; } }

  public bool GetVpoint{ get { return getVpoint; } }

  public int HandsCount(){
    int num=0;
    foreach (var card in hands){
      if (!card.GetComponent<Card>().IsTrash){
        num++;
      }
    }
    return num;
  }


  void HandTrim(){
    foreach (var card in hands.Select((val,ind) => new {val,ind})) {
      if (card.val.GetComponent<Card>().IsSelected) {
        card.val.GetComponent<Card>().Move(new Vector3(card.ind * card.val.transform.localScale.x / 2 + handPosition.x, handPosition.y + 5, handPosition.z), (float)0.3);
	    } else {
        card.val.GetComponent<Card>().Move(new Vector3(card.ind * card.val.transform.localScale.x / 2 + handPosition.x, handPosition.y, handPosition.z), (float)0.3);
	    }
    }
  }

  void TrashUpdate(){
    foreach (var card in hands){
      if (card.GetComponent<Card>().IsTrash){
        if (card.GetComponent<Card>().IsMoney){
          money--;
        }
        trash.Add(card);
			}
		}
    foreach (var card in field){
      if (card.GetComponent<Card>().IsTrash){
        trash.Add(card);
			}
		}
    foreach (var card in selected){
      if (card.GetComponent<Card>().IsTrash){
        trash.Add(card);
			}
		}
    foreach (var card in deck){
      if (card.GetComponent<Card>().IsTrash){
        trash.Add(card);
			}
		}
    foreach (var card in trash) {
      field.Remove(card);
      hands.Remove(card);
      selected.Remove(card);
      deck.Remove(card);
      card.GetComponent<Card>().Move(trashPosition);
		}
	}

  void RemoveUpdate(){
    foreach (var card in hands){
      if (card.GetComponent<Card>().IsRemove){
        remove.Add(card);
      }
    }
    foreach (var card in field){
      if (card.GetComponent<Card>().IsRemove){
        remove.Add(card);
      }
    }
    foreach (var card in selected){
      if (card.GetComponent<Card>().IsRemove){
        remove.Add(card);
      }
    }
    foreach (var card in deck){
      if (card.GetComponent<Card>().IsRemove){
        remove.Add(card);
      }
    }
    foreach (var card in remove) {
      field.Remove(card);
      hands.Remove(card);
      selected.Remove(card);
      deck.Remove(card);
      card.GetComponent<Card>().Move(removePosition, local: false);
    }
  }


  void InitDeck(){
    for (int i = 0; i < 10; i++) {
      GameObject clone;
      if (i < 7) {
        clone = copper.GetComponent<Card>().SetInitDeck(deckPosition, transform.rotation, transform.parent.gameObject);
      } else {
        clone = mansion.GetComponent<Card>().SetInitDeck(deckPosition, transform.rotation, transform.parent.gameObject);
      }
      clone.GetComponent<Card>().Move(deckPosition);
      clone.GetComponent<Card>().SetOwner(gameObject);
      clone.transform.parent = transform;
      deck.Add(clone);
    }
    deck = new List<GameObject>(deck.OrderBy(i => Guid.NewGuid()).ToArray());
  }

  public bool DiscardAttackEnd(int num){
    foreach (var card in hands){
      if (card.GetComponent<Card>().IsReaction)
        return true;
    }
    return CountSelected() == num;
  }

  public bool OtherDiscardAttackEnd(int num){
    bool flag = true;
    foreach (var p in otherPlayers){
      if (!p.GetComponent<Player>().DiscardAttackEnd(p.GetComponent<Player>().HandsCount() - num)){
        flag = false;
      }
    }
    return flag;
  }

  public void OtherDiscard(){
    foreach (var p in otherPlayers){
      p.GetComponent<Player>().SelectedTrash();
    }
  }

  public void Draw(int num){
    for (int i = 0; i < num; i++) {
      if (deck.Count == 0) {
        if (trash.Count == 0)
          continue;
        foreach (var card in trash.Select((val,ind) => new {val,ind})) {
          card.val.GetComponent<Card>().SetDeck(deckPosition);
        }
        deck.AddRange(trash);
        deck = new List<GameObject>(deck.OrderBy(j => Guid.NewGuid()).ToArray());
        trash.Clear();
      }
      hands.Add(deck[0]);
      deck[0].GetComponent<Card>().DrawCard();
      deck.RemoveAt(0);
      CountMoney();
    }
  }

  void CountMoney(){
    money = 0; 
    foreach (var obj in hands) {
      var card = obj.GetComponent<Card>();
      if (card.IsMoney) {
        money += card.Money;
      }
    }
  }

  public int CountVpoint(){
    int num = 0;
    foreach (var card in hands){
      if (card.GetComponent<Card>().IsVpoint){
        num += card.GetComponent<Card>().Vpoint;
      }
    }
    foreach (var card in trash){
      if (card.GetComponent<Card>().IsVpoint){
        num += card.GetComponent<Card>().Vpoint;
      }
    }
    foreach (var card in deck){
      if (card.GetComponent<Card>().IsVpoint){
        num += card.GetComponent<Card>().Vpoint;
      }
    }
    return num;
  }

  public void SetGetParam(int n, bool isA = false, bool isM = false, bool isV = false, bool hand = false){
    cost += n;
    getAction = isA;
    getMoney = isM;
    getVpoint = isV;
    getHand = hand;
  }

  public void SetOtherPlayers(GameObject p1, GameObject p2, GameObject p3){
    otherPlayers.Add(p1);
    otherPlayers.Add(p2);
    otherPlayers.Add(p3);
  }

  public bool IsPlay(){
    return !selectMode && Cost == 0;
  }

  public int CountSelected(){
    int num = 0;
    foreach (var card in hands){
      if (card.GetComponent<Card>().IsSelected){
        num++;
			}
		}
    return num;
	}

  public bool IsSelectedMoney(){
    bool flag = false;
    foreach (var card in hands){
      if (card.GetComponent<Card>().IsMoney){
        flag = true;
      }
    }
    return flag;
  }

  public void EndTurn(){
    if (turn == true) {
      foreach (var card in hands) {
        card.GetComponent<Card>().Trash();
      }
      foreach (var card in field) {
        card.GetComponent<Card>().Trash();
      }
      Draw(5);
      turn = false;
    }
  }

  public void EndCellar(){
    foreach (var card in field) {
      if (card.GetComponent<Cellar>()) {
        card.GetComponent<Cellar>().EndAction();
        selectMode = false;
			}
		}
	}

  public void EndRemodel(){
    bool flag = true;
    foreach (var card in field) {
      if (card.GetComponent<Remodel>()) {
        flag = card.GetComponent<Remodel>().EndAction();
      }
    }
    if (flag)
      selectMode = false;
  }

  public void EndMine(){
    bool flag = true;
    foreach (var card in field) {
      if (card.GetComponent<Mine>()) {
        flag = card.GetComponent<Mine>().EndAction();
      }
    }
    if (flag)
      selectMode = false;
  }

  public void StartTurn(){
    turn = true;
    selectMode = false;
    getHand = false;
    money = 0;
    purchase = 1;
    action = 1;
    cost = 0;
    getAction = false;
    getMoney = false;
    getVpoint = false;
    CountMoney();
  }

  public void BuyCard(Card card){
    money -= card.Cost;
    purchase--;
    trash.Add(card.gameObject);
    card.Move(trashPosition);
    if (purchase == 0) {
      EndTurn();
      transform.GetComponentInParent<GameMaster>().NextPlayer();
	    }
	}

  public void GetCard(Card card){
    cost = 0;
    if (getHand){
      hands.Add(card.gameObject);
      card.GetHand();
    } else{
      trash.Add(card.gameObject);
      card.Move(trashPosition);
    }
  }

  public void SelectedTrash(){
    foreach (var card in hands){
      if (card.GetComponent<Card>().IsSelected){
        card.GetComponent<Card>().Trash();
			}
		}
	}

  public int SelectedRemove(){
    int n = 0;
    foreach (var card in hands){
      if (card.GetComponent<Card>().IsSelected){
        n += card.GetComponent<Card>().Cost;
        card.GetComponent<Card>().Remove();
      }
    }
    return n;
  }

  public void PlayCard(GameObject obj){
    Card card = obj.GetComponent<Card>();
    action += card.Action;
    if (card.IsAction) {
      action--;
    }
    if (!card.IsMoney) {
      money += card.Money;
    }
    purchase += card.Purchase;
    Draw(card.Draw);
    hands.Remove(obj);
    field.Add(obj);
	}

  // Use this for initialization
  void Start(){
    turn = true;
    selectMode = false;
    cost = 0;
    field = transform.parent.GetComponent<GameMaster>().field;
    remove = transform.parent.GetComponent<GameMaster>().remove;
    supply = transform.parent.GetComponent<GameMaster>().supply.GetComponent<Supply>();
    InitDeck();
    Draw(5);
    HandTrim();
  }

  // Update is called once per frame
  void Update(){
    HandTrim();
    TrashUpdate();
    RemoveUpdate();
  }

}
