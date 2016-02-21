using UnityEngine;
using System.Collections;
/// <summary>
/// 敵
/// </summary>
public class Enemy : MonoBehaviour {

	public string targetTag = "Ruin";
	[Range(1, 20)]
	public int hp = 2;
	private int nowHp;
	[Range(0.1f, 10f)]
	public float velocity = 1f;
	[Header("移動する方向")]
	public Vector3 direction;

#region MonoBehaviourEvent
	private void OnEnable() {
		nowHp = hp;
	}
	private void Update() {
		Move();
	}
	private void OnCollisionEnter(Collision co) {
		if(co.gameObject.tag.Equals(targetTag)) {
			TargetHit();
		} else {
			SubHP(1);
		}		
	}
#endregion
#region Function
	private void Move() {
		transform.position += direction * velocity * Time.deltaTime;
	}
	private void TargetHit() {
		GameManager.Instance.Damage();
		Destroy(gameObject);
	}
	private void SubHP(int sub) {
		nowHp -= sub;
		if(nowHp < 0) {
			nowHp = 0;
			Destroy(gameObject);
		}
	}
#endregion
}