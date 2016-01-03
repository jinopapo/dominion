using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class PlayerDraw : MonoBehaviour {
  public int draw;

  public void DrawCard(){
    Player player = gameObject.GetComponent<Player>();
    if (!player.IsMove()){
      for (int i = 0; i < draw; i++) {
        if (player.deck.Count == 0) {
          if (player.trash.Count == 0)
            continue;
          foreach (var card in player.trash.Select((val,ind) => new {val,ind})) {
            card.val.GetComponent<Card>().SetDeck(player.deckPosition);
          }
          player.deck.AddRange(player.trash);
          player.deck = new List<GameObject>(player.deck.OrderBy(j => Guid.NewGuid()).ToArray());
          player.trash.Clear();
        }
        player.hands.Add(player.deck[0]);
        player.deck[0].GetComponent<Card>().DrawCard();
        player.deck.RemoveAt(0);
        player.CountMoney();
      }
      draw = 0;
    }
  }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
