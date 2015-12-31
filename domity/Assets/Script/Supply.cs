using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Supply : MonoBehaviour {

	[SerializeField]List<GameObject> supply;
	[SerializeField] GameObject copper;
	[SerializeField] GameObject sliver;
	[SerializeField] GameObject gold;
	[SerializeField] GameObject mansion;
	[SerializeField] GameObject landtag;
	[SerializeField] GameObject province;
	[SerializeField] Vector3 copperPosition;
	[SerializeField] Vector3 sliverPosition;
	[SerializeField] Vector3 goldPosition;
	[SerializeField] Vector3 mansionPosition;
	[SerializeField] Vector3 landtagPosition;
	[SerializeField] Vector3 provincePositon;
	[SerializeField] List<Vector3> supplyPositions;
	public List<List<GameObject>> supplys = new List<List<GameObject>>();
	public List<GameObject> coppers = new List<GameObject>();
	public List<GameObject> slivers = new List<GameObject>();
	public List<GameObject> golds = new List<GameObject>();
	public List<GameObject> landtags = new List<GameObject>();
	public List<GameObject> mansions = new List<GameObject>();
	public List<GameObject> provinces = new List<GameObject>();

	List<GameObject> RemoveBoughtCard(List<GameObject> list){
		return new List<GameObject>(list.Where(c => c.GetComponent<Card>().Owner == null));
	}

	public bool IsEnd(){
		int end = 0;
		if (coppers.Count == 0) {
			end++;
		}
		if (slivers.Count == 0) {
			end++;
		}
		if (golds.Count == 0) {
			end++;
		}
		if (landtags.Count == 0) {
			end++;
		}
		if (mansions.Count == 0) {
			end++;
		}
		if (provinces.Count == 0) {
			end++;
		}
		foreach (var s in supplys) {
			if (s.Count == 0) {
				end++;
			}
		}
		if (end >= 3) {
			return true;
		} else {
			return false;
		}
	}

	// Use this for initialization
	void Start () {
		GameObject main = transform.parent.gameObject;
		for (int i = 0; i < 32; i++) {
			GameObject clone = copper.GetComponent<Card> ().SetInitSupply (copperPosition, transform,main);
			coppers.Add (clone);
		}
		for (int i = 0; i < 40; i++) {
			GameObject clone = sliver.GetComponent<Card> ().SetInitSupply (sliverPosition, transform,main);
			slivers.Add (clone);
		}
		for (int i = 0; i < 30; i++) {
			GameObject clone = gold.GetComponent<Card> ().SetInitSupply (goldPosition, transform,main);
			golds.Add (clone);
		}
		for (int i = 0; i < 12; i++) {
			GameObject clone = mansion.GetComponent<Card> ().SetInitSupply (mansionPosition, transform,main);
			mansions.Add (clone);
		}
		for (int i = 0; i < 12; i++) {
			GameObject clone = landtag.GetComponent<Card> ().SetInitSupply (landtagPosition, transform,main);
			landtags.Add (clone);
		}
		for (int i = 0; i < 12; i++) {
			GameObject clone = province.GetComponent<Card> ().SetInitSupply (provincePositon, transform,main);
			provinces.Add (clone);
		}

		foreach (var s in supply.Select((val,ind) => new {val=val, pos=supplyPositions[ind]})) {
			supplys.Add(new List<GameObject>());
			for (int i = 0; i < 10; i++) {
				GameObject clone = s.val.GetComponent<Card> ().SetInitSupply (s.pos, transform, main);
        clone.name = s.val.name;
				supplys[supplys.Count-1].Add (clone);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		coppers = RemoveBoughtCard (coppers);
		slivers = RemoveBoughtCard (slivers);
		golds = RemoveBoughtCard (golds);
		mansions = RemoveBoughtCard (mansions);
		landtags = RemoveBoughtCard (landtags);
		provinces = RemoveBoughtCard (provinces);
    for(int i=0;i<10;i++) {
      supplys[i] = RemoveBoughtCard (supplys[i]);
		}
	}
}
