using UnityEngine;
using System.Collections;

public class CardManager : MonoBehaviour {

	const int InSupply = 0;
	const int InDeck = 1;
	const int InHand = 2;
	const int InField = 3;
	const int InTrash = 4;

	[SerializeField]Sprite front;
	[SerializeField]Sprite back;
	[SerializeField]int state=-1;
	[SerializeField]int purchase;
	[SerializeField]int cost;
	[SerializeField]int money;
	[SerializeField]int action;
	[SerializeField]int draw;
	[SerializeField]int vpoint;
	[SerializeField]bool isAction;
	[SerializeField]bool isMoney;
	[SerializeField]bool isVpoint;
	[SerializeField]GameObject perfab;
	GameObject owner;
	GameObject master;
	bool playNow;

	public int State{get{return state;}}
	public int Purchase {get{return purchase;}}
	public int Cost{get{return cost;}}
	public int Money{get{return money;}}
	public int Action {get{return action;}}
	public int Draw{get{return draw;}}	
	public int Vpoint{get{return vpoint;}}	
	public bool IsMoney{get{return isMoney;}}	
	public bool IsAction{get{return isAction;}}	
	public bool IsVpoint{get{return isVpoint;}}	
	public bool PlayNow{get{return playNow;}}
	public GameObject Owner {get{return owner;}}

	public void EndPlay(){
		playNow = false;
	}

	public void StartPlay(){
		playNow = true;
	}

	// Use this for initialization
	void Start () {
		playNow = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
