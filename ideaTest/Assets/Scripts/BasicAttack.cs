using UnityEngine;
using System.Collections;

public class BasicAttack : MonoBehaviour {

//---------------------------------------------------------------------------------------------------
// Atributes
//---------------------------------------------------------------------------------------------------

//Prefabs
	public GameObject basicAttackPrefab;

//Editable Values
	public float attackVel;

//Private Values
	private GameObject attack;
	private float initAttackTimer;
	private Transform currentAnchor;

//Flags
	private bool onAttack;

//---------------------------------------------------------------------------------------------------
// Initialization
//---------------------------------------------------------------------------------------------------

	void Start () {
		currentAnchor = transform.Find ("AttackAnchor").transform;
		onAttack = false;
	}

//---------------------------------------------------------------------------------------------------
// Behaviour
//---------------------------------------------------------------------------------------------------

	void Update () {
		if (Input.GetMouseButtonDown (0) && !onAttack) {
			attack = InstantiateAttack();
			initAttackTimer = Time.time;
			onAttack = true;
		}

		if (onAttack) {
			if (Time.time >= initAttackTimer + attackVel) {
				onAttack = false;
			}
		}
	}

	private GameObject InstantiateAttack(){
		GameObject attack = (GameObject)Instantiate (basicAttackPrefab,currentAnchor.position, currentAnchor.rotation);
		attack.transform.SetParent (transform);
		return attack;
	}	
}