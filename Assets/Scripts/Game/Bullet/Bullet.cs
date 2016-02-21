using UnityEngine;
using System.Collections;
/// <summary>
/// 弾
/// </summary>
public class Bullet : MonoBehaviour {
	
	[SerializeField, Range(0.1f, 10f)]
	private float lifeTime = 1f;
	private float measureLifeTime = 0f;
	[SerializeField, Range(1f, 30f)]
	private float velocity = 1f;

#region MonoBehaviourEvent
	private void Update() {
		if(measureLifeTime > lifeTime) {
			Destroy(gameObject);
		} else {
			Move();
			measureLifeTime += Time.deltaTime;
		}
	}
	private void OnCollisionEnter(Collision coll) {
		Destroy(gameObject);
	}
#endregion
#region Function
	private void Move() {
		transform.Translate(Vector3.right * velocity * Time.deltaTime);
	}
#endregion
}