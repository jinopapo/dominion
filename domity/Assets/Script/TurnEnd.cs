using UnityEngine;
using System.Collections;

public class TurnEnd : MonoBehaviour {

	Player player;

	public Player Player{
		set{
			if (player == null) {
				player = value;
			}
		}
		get{ return player; }
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		if (!player.selectMode) {
			player.EndTurn ();
			transform.GetComponentInParent<GameMaster> ().NextPlayer ();
		} else {
			player.EndCellar ();
      player.EndRemodel ();
      player.EndMine();
		}
	}
}
