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
	private void Update() {
		Move();
	}
	private void OnCollisionEnter(Collision co) {
		if(targetTag.Equals(targetTag)) TargetHit();
	}
#endregion
#region Function
	private void Move() {
		transform.position += direction * velocity * Time.deltaTime;
	}
	private void TargetHit() {
		Destroy(gameObject);
	}
#endregion
}