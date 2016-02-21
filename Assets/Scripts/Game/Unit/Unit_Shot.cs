using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// 何かを撃つユニット
/// </summary>
public class Unit_Shot : UnitBase{
	[Header("パラメータ")]
	[SerializeField, Range(0.1f, 10f)]
	private float attackInterval = 1f;
	public float AttackInterval {
		get {return attackInterval;}
		set {
			attackInterval = value;
			measureAttackInterval = 0f;
		}
	}
	private float measureAttackInterval = 0f;
	[SerializeField, Range(1f, 20f)]
	private float attackRange = 8f;
	public float AttackRange {
		get {return attackRange;}
		set {
			attackRange = value;
			if(attackRangeObject) {
				attackRangeObject.transform.localScale = new Vector3(attackRange, attackRange, 1f);
			}
		}
	}
	public GameObject attackRangeObject;
	private List<GameObject> targetList;
	private GameObject target;
	public GameObject bullet;

#region MonoBehaviourEvent
	private void OnEnable() {
		AttackRange = attackRange;
		targetList = new List<GameObject>();
	}
	private void Update() {
		SeTarget();
		if(measureAttackInterval > attackInterval) {
			if (target) {				
				Shot();
				measureAttackInterval = 0f;
			}			
		} else {
			measureAttackInterval += Time.deltaTime;
		}
	}
	private void OnTriggerEnter(Collider coll) {
		targetList.Add(coll.gameObject);
	}
	private void OnTriggerExit(Collider coll) {
		if(targetList.Contains(coll.gameObject)) {
			targetList.Remove(coll.gameObject);
		}
		if (target == coll.gameObject) {
			target = null;
		}
	}
#endregion
#region Function
	private void SeTarget() {
		if (target || targetList.Count <= 0) return;
		target = targetList[0];
		targetList.Remove(target);
	}
	private void Shot() {
		if(bullet) {
			GameObject bul = (GameObject)Instantiate(bullet, transform.position, Quaternion.identity);
			//角度調整
			Vector3 from, to;
			from = transform.position;
			to = target.transform.position;
			float angle = Mathf.Atan2(to.y - from.y, to.x - from.x) * Mathf.Rad2Deg;

			bul.transform.eulerAngles = new Vector3(0f, 0f, angle);
		}
	}
#endregion
}