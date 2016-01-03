using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GameMaster : MonoBehaviour {

	GameObject[] players;
	public GameObject supply;
  [SerializeField] GameObject AI;
	GameObject mainPlayer;
	int nowPlayer;
  bool[] play;
  public List<GameObject> field;
  public List<GameObject> remove;
	public GameObject player;

	public GameObject MainPlayer{
		get{ return mainPlayer; }
	}

	void Awake(){
		players = new GameObject[4];
    play = new bool[4];
		for (int i = 0; i < 4; i++) {
      play[i] = false;
      GameObject clone;
      if(i==0)clone = (GameObject)Instantiate (player);
      else clone = (GameObject)Instantiate (AI);
			clone.transform.parent = transform;
			if (i % 2 == 0) {
				clone.transform.position = new Vector3 (0, 0, 0);
			} else {
				clone.transform.position = new Vector3 (0, -20, 0);
			}
			clone.transform.RotateAround(new Vector3(0,0,0), Vector3.forward, 90*i);
			players [i] = clone;
		}
    players[0].GetComponent<Player>().SetOtherPlayers(players[1], players[2], players[3]);
    players[1].GetComponent<Player>().SetOtherPlayers(players[2], players[3], players[0]);
    players[2].GetComponent<Player>().SetOtherPlayers(players[3], players[0], players[1]);
    players[3].GetComponent<Player>().SetOtherPlayers(players[0], players[1], players[2]);
		mainPlayer = players [0];
		transform.FindChild ("TurnEnd").GetComponent<TurnEnd> ().Player = players[0].GetComponent<Player>();
		players [0].GetComponent<Player> ().StartTurn ();
		nowPlayer = 0;
    play[0] = true;
	}

	public void NextPlayer(){
    play[nowPlayer] = false;
		nowPlayer++;
		nowPlayer = nowPlayer % 4;
    play[nowPlayer] = true;
		players [nowPlayer].GetComponent<Player>().StartTurn();
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (supply.GetComponent<Supply> ().IsEnd ()) {
      foreach (var p in players.Select((val,ind) => new {val,ind})) {
				p.val.GetComponent<Player> ().EndTurn ();
        print(p.ind.ToString() + " " + p.val.GetComponent<Player> ().CountVpoint ().ToString());
			}
		}
	}
}
