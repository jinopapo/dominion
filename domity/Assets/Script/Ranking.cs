using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Ranking : MonoBehaviour {
  public GameMaster gameMaster;
  public int rank;
  public Text first;
  public Text second;
  public Text theard;
  public Text forth;

  List<GameObject> players ;

  int CompPlayer(GameObject a,GameObject b){
    if (a.GetComponent<Player>().CountVpoint() < b.GetComponent<Player>().CountVpoint()){
      return 1;
    } else if (a.GetComponent<Player>().CountVpoint() > b.GetComponent<Player>().CountVpoint()){
      return -1;
    } else{
      return 0;
    }
  }

	// Use this for initialization
	void Start () {
    players = new List<GameObject>();
    players.AddRange(gameMaster.players);
    players.Sort(CompPlayer);
    first.text = "1st:" + players[0].name + " " + players[0].GetComponent<Player>().CountVpoint().ToString();
    second.text = "2nd:" + players[1].name + " " + players[1].GetComponent<Player>().CountVpoint().ToString();
    theard.text = "3rd:" + players[2].name + " " + players[2].GetComponent<Player>().CountVpoint().ToString();
    forth.text = "4th:" + players[3].name + " " + players[3].GetComponent<Player>().CountVpoint().ToString();
	}
	
	// Update is called once per frame
	void Update () {
	  
	}
}
