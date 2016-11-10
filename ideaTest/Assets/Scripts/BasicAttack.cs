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
	public float attackMaxDistance;

//Private Values
	private GameObject attack;
	private Vector3 initialPosition;
	private float minDifference;

//Flags
	private bool onAttack;

//---------------------------------------------------------------------------------------------------
// Initialization
//---------------------------------------------------------------------------------------------------

	void Start () {
		minDifference = 9.0f;
		onAttack = false;
	}

//---------------------------------------------------------------------------------------------------
// Behaviour
//---------------------------------------------------------------------------------------------------

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			attack = InstantiateAttack();
			initialPosition = attack.transform.position;
			onAttack = true;
			//StartCoroutine (PerformAttack (attack));
		}

		if (onAttack) {
			Vector3 faceDir = attack.transform.forward;
			//attack.transform.position = Vector3.Lerp(attack.transform.position,faceDir*2,0.5f * Time.deltaTime);
			attack.transform.Translate (faceDir*attackVel*Time.deltaTime);
			Debug.Log ("Max distance: " + initialPosition*attackMaxDistance);
			Debug.Log ("Distance: " + Vector3.Distance(attack.transform.position, initialPosition*attackMaxDistance));
			if (Vector3.Distance(attack.transform.position, initialPosition*attackMaxDistance) >= minDifference) {
				onAttack = false;
				//Destroy (attack);
			}
		}
	}

	private GameObject InstantiateAttack(){
		Vector3 spawnPos = GetComponentInChildren<SpawnAttackArea>().getSpawnPosition();
		GameObject attack = (GameObject)Instantiate (basicAttackPrefab,spawnPos, Quaternion.identity);
		attack.transform.SetParent (transform);
		return attack;
	}

	private IEnumerator PerformAttack(GameObject attack){
		yield return new WaitForSeconds(0.1f);
		Vector3 faceDir = attack.transform.forward;
		attack.transform.Translate (faceDir*2*Time.deltaTime);
		//Destroy (attack);
	}

	private bool hasReachedMax(Vector3 initial, Vector3 max, int axis){
		switch (axis) {
		case 1:
			break;
		case 2:
			break;
		case 3:
			break;
		}
	}
}