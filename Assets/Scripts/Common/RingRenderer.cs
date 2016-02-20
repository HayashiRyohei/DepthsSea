using UnityEngine;
using System.Collections;
/// <summary>
/// 輪を描画
/// </summary>
[ExecuteInEditMode]
public class RingRenderer : MonoBehaviour {
	
	public Shader shader;
	public Mesh mesh;
	private Material mat;

	[Header("パラメータ")]
	[SerializeField]
	private Color color = Color.white;
	[SerializeField, Range(0f, 1f)]
	private float innerRadius = 0.2f;
	[SerializeField, Range(0f, 1f)]
	private float outerRadius = 0.2f;
	[SerializeField, Range(0f, 1f)]
	private float innerBlurThickness = 0.002f;
	[SerializeField, Range(0f, 1f)]
	private float outerBlurThickness = 0.002f;

#region MonoBehaviourEvent
	private void OnEnable() {
		if(!mat) {
			mat = new Material(shader);
		}
	}
	private void OnRenderObject() {
		//値を設定
		mat.SetColor("_Color", color);
		mat.SetFloat("_InnerRadius", innerRadius);
		mat.SetFloat("_OuterRadius", outerRadius);
		mat.SetFloat("_InnerBlurThickness", innerBlurThickness);
		mat.SetFloat("_OuterBlurThickness", outerBlurThickness);
		//レンダリング
		mat.SetPass(0);
		//Graphics.DrawMeshNow(mesh, transform.position, transform.rotation);
		Graphics.DrawMeshNow(mesh, transform.localToWorldMatrix);
	}
#endregion
}