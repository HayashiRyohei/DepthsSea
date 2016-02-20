using UnityEngine;
using System.Collections;
/// <summary>
/// 敵の生成
/// </summary>
public class EnemyEmitter : MonoBehaviour {
	
	//生成するプレハブ
	public GameObject emitPrefab;
	//生成間隔
	public float emitInterval;
	private float measureEmitInterval;
	//生成位置
	public Vector3 emitAreaScale = Vector3.one;

#region MonoBehaviourEvent
	private void OnEnable() {
		measureEmitInterval = 0f;
	}
	private void Update() {
		if(emitPrefab) {
			if(measureEmitInterval >= emitInterval) {
				Emit();
				measureEmitInterval = 0f;
			} else {
				measureEmitInterval += Time.deltaTime;
			}
		}
	}
#endregion
#region Function
	/// <summary>
	/// 生成
	/// </summary>
	private void Emit() {
		//位置
		Vector3 harf = emitAreaScale * 0.5f;
		Vector3 pos = new Vector3(
			Random.Range(-harf.x, harf.x),
			Random.Range(-harf.y, harf.y),
			Random.Range(-harf.z, harf.z));
		//生成
		Instantiate(emitPrefab, pos + transform.position, emitPrefab.transform.rotation);
	}
#endregion
}