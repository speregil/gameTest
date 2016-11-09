using UnityEngine;
using System.Collections;

public class BasicAttack : MonoBehaviour {

	public GameObject basicAttackPrefab;

	public float xAttackOffset;
	public float yAttackOffset;
	public float zAttackOffset;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			GameObject attack = InstantiateAttack();
		}
	}

	private GameObject InstantiateAttack(){
		Vector3 spawnPos = GetComponentInChildren<SpawnAttackArea>().getSpawnPosition();
		GameObject attack = (GameObject)Instantiate (basicAttackPrefab,spawnPos, Quaternion.identity);
		attack.transform.SetParent (transform);
		return attack;
	}
}