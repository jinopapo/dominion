using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Card : MonoBehaviour {


  const int InSupply = 0;
  const int InDeck = 1;
  const int InHand = 2;
  const int InField = 3;
  const int InTrash = 4;
  const int InSelected = 5;
  const int InRemove = 6;

  [SerializeField] Sprite front;
  [SerializeField] Sprite back;
  [SerializeField]int state = -1;
  [SerializeField]int purchase;
  [SerializeField]int cost;
  [SerializeField]int money;
  [SerializeField]int action;
  [SerializeField]int draw;
  [SerializeField]int vpoint;
  [SerializeField]bool isAction;
  [SerializeField]bool isMoney;
  [SerializeField]bool isVpoint;
  [SerializeField]bool isReaction;
  [SerializeField]GameObject perfab;
  [SerializeField]int eventNum;
  bool playNow;
  int eventCount;
  GameObject owner;
  GameObject master;
  bool eventFlag;

  float time;

  private float startTime;
  private Vector3 startPosition;
  private Vector3 endPosition;
  public Vector3 movePoint;

  private Vector3 fieldPosition = new Vector3(20, -10, 0);


  public int State{ get { return state; } }

  public int Purchase { get { return purchase; } }

  public int Cost{ get { return cost; } }

  public int Money{ get { return money; } }

  public int Action { get { return action; } }

  public int Draw{ get { return draw; } }

  public int Vpoint{ get { return vpoint; } }

  public bool IsMoney{ get { return isMoney; } }

  public bool IsAction{ get { return isAction; } }

  public bool IsReaction{ get { return isReaction; } }

  public bool IsVpoint{ get { return isVpoint; } }

  public bool PlayNow{ get { return playNow; } }

  public GameObject Owner { get { return owner; } }

  public bool Event { get { return eventFlag; } }

  public bool IsSelected { get { return state == InSelected; } }

  public bool IsTrash { get { return state == InTrash; } }

  public bool IsRemove { get { return state == InRemove; } }


  private GameObject clone(Vector3 position, Quaternion rot){
    return (GameObject)Instantiate(perfab, position, rot);
  }

  private void PlayCard(){
    if (eventFlag && state != InField){
      state = InField;
      owner.GetComponent<Player>().PlayCard(gameObject);
      Move(fieldPosition, (float)0.5, false);
      eventCount--;
    }
  }

  public void Selected(){
    if (owner != null && owner.GetComponent<Player>().selectMode){
      if (state == InHand){
        state = InSelected;
      } else if (state == InSelected){
        state = InHand;
      }
    }
  }

  bool IsMatchType(bool isA, bool isM, bool isV){
    if (isA && isAction){
      return true;
    }
    if (isM && isMoney){
      return true;
    }
    if (isV && isVpoint){
      return true;
    }
    return false;
  }

  public void EndEvent(){
    eventCount--;
  }

  public void SetOwner(GameObject p){
    if (owner == null) {
      owner = p;
    }
  }

  public GameObject SetInitDeck(Vector3 position, Quaternion rot, GameObject gmaster){
    GameObject obj = clone(position, rot);
    obj.GetComponent<Card>().master = gmaster;
    obj.GetComponent<Card>().Move(position);
    state = InDeck;
    return obj;
  }

  public GameObject SetInitSupply(Vector3 position, Transform t, GameObject gmaster){
    GameObject obj = clone(position, t.rotation);
    obj.GetComponent<Card>().state = InSupply;
    obj.transform.parent = t.parent;
    obj.GetComponent<Card>().master = gmaster;
    return obj;
  }

  public void Move(Vector3 position, float t = (float)0.5, bool local = true){
    if (position != endPosition) {
      if (owner != null){
        transform.rotation = owner.transform.rotation;
      }
      time = t;
      startPosition = transform.localPosition;
      if (local) {
        endPosition = position;
      } else {
        endPosition = transform.TransformDirection(position);
      }
      startTime = Time.timeSinceLevelLoad;
    }
  }

  public bool IsGet(Player buyer, bool isA, bool isM, bool isV){
    if (state == InSupply) {
      if (buyer.Cost >= cost && IsMatchType(isA,isM,isV)) {
        return true;
      }
    }
    return false;
  }

  public bool IsPlay(){
    if (state == InHand && owner == master.GetComponent<GameMaster>().MainPlayer && owner.GetComponent<Player>().IsPlay()) {
      if (isAction && owner.GetComponent<Player>().Action > 0) {
        return true;
      }
      if (isMoney) {
        return true;
      }
    }
    return false;
  }

  public bool IsBuy(Player buyer){
    if (state == InSupply) {
      if (buyer.Money >= cost && buyer.Purchase > 0 && buyer.Cost == 0) {
        return true;
      }
    }
    return false;
  }

  public void Trash(){
    /*if (state == InDeck) {
			owner.GetComponent<Player> ().RemoveDeck (gameObject);
		} else if (state == InHand) {
			owner.GetComponent<Player> ().RemoveHand (gameObject);
		}
    	owner.GetComponent<Player>().AddTrash (gameObject);*/
    state = InTrash;
  }

  public void Remove(){
    state = InRemove;
  }

  public void GetHand(){
    state = InHand;
  }

  public void DrawCard(){
    if (state == InDeck) {
      state = InHand;
      gameObject.GetComponent<SpriteRenderer>().sprite = front;
    }
  }

  /*public void TrashCard(Vector3 position){
    state = InTrash;
    Move (position, (float)0.3);
  }*/

  public void SetDeck(Vector3 position){
    state = InDeck;
    gameObject.GetComponent<SpriteRenderer>().sprite = back;
    Move(position, (float)0.3);
  }

  public void Play(){
    if (IsPlay()) {
      eventFlag = true;
      eventCount = eventNum;
    }
  }

  public void Get(GameObject buyer){
    Player player = buyer.GetComponent<Player>();
    if (IsGet(buyer.GetComponent<Player>(), player.GetAction, player.GetMoney, player.GetVpoint)){
      state = InTrash;
      owner = buyer;
      buyer.GetComponent<Player>().GetCard(gameObject.GetComponent<Card>());
      transform.parent = buyer.gameObject.transform;
    }
  }

  public void Purued(GameObject buyer){
    if (IsBuy(buyer.GetComponent<Player>())) {
      state = InTrash;
      owner = buyer;
      buyer.GetComponent<Player>().BuyCard(gameObject.GetComponent<Card>());
      transform.parent = buyer.gameObject.transform;
    }
  }

  // Use this for initialization
  void Start() {
    playNow = false;
    eventCount = 0;
    endPosition = transform.position;
    if (state == InDeck) {
      gameObject.GetComponent<SpriteRenderer>().sprite = back;
    } else {
      gameObject.GetComponent<SpriteRenderer>().sprite = front;
    }
    eventFlag = false;
  }

  // Update is called once per frame
  void Update() {
    var diff = Time.timeSinceLevelLoad - startTime;
    if (diff > time) {
      transform.localPosition = endPosition;
    }
    if (endPosition != transform.localPosition) {
      var rate = diff / time;
      transform.localPosition = Vector3.Lerp(startPosition, endPosition, rate);
    }
    if (eventCount == 0){
      eventFlag = false;
    }
    if (eventFlag){
      PlayCard();
    }
  }

  void OnMouseDown(){
    GameObject pObj = master.GetComponent<GameMaster>().MainPlayer;
    Play();
    Selected();
    Get(pObj);
    Purued(pObj);
  }
}
