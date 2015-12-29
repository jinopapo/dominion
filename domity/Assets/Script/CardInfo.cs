using UnityEngine;
using System.Collections;

public class CardInfo : MonoBehaviour {

	[SerializeField] Sprite front;
	[SerializeField] Sprite back;
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
	//public bool PlayNow{get{return playNow;}}
	//public GameObject Owner {get{return owner;}}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
