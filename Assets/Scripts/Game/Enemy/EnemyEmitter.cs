using UnityEngine;
using System.Collections;
/// <summary>
/// 敵の生成
/// </summary>
public class EnemyEmitter : MonoBehaviour {

	//生成オプション
	public int emitLevel = 1;				//生成レベル
	public GameObject emitPrefab;		//生成プレハブ
	public float baseEmitInterval;			//基本生成間隔
	private float emitInterval;				//生成間隔
	private float measureEmitInterval;		//計測生成間隔
	public Vector3 emitArea = Vector3.one;	//生成範囲

#region MonoBehaviourEvent
	private void OnEnable() {
		measureEmitInterval = 0f;
		//生成間隔
		emitInterval = Mathf.Lerp(baseEmitInterval, 0.1f, emitLevel / 100f);
	}
	private void Update() {
		if(emitPrefab) {
			if(measureEmitInterval >= baseEmitInterval) {
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
		Vector3 harf = emitArea * 0.5f;
		Vector3 pos = new Vector3(
			Random.Range(-harf.x, harf.x),
			Random.Range(-harf.y, harf.y),
			Random.Range(-harf.z, harf.z));
		//生成
		GameObject obj = (GameObject)Instantiate(emitPrefab, pos + transform.position, emitPrefab.transform.rotation);
		obj.transform.parent = transform;
	}
	/// <summary>
	/// 生成したオブジェクトを全て削除
	/// </summary>
	public void EmitObjectDestroy() {
		if(transform.childCount <= 0) return;
		foreach(Transform child in transform) {
			Destroy(child.gameObject);
		}
	}
#endregion
}