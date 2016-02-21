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
	public Color color = Color.white;
	[Range(0f, 1f)]
	public float innerRadius = 0.39f;
	[Range(0f, 1f)]
	public float outerRadius = 0.4f;
	[Range(0f, 1f)]
	public float innerBlurThickness = 0.002f;
	[Range(0f, 1f)]
	public float outerBlurThickness = 0.002f;
	public bool autoBlurFit = false;
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
		//ブラー
		float blurPar = 2f;
		if(autoBlurFit) {
			blurPar = (transform.localScale.x + transform.localScale.y) * 0.5f;
		}
		mat.SetFloat("_InnerBlurThickness", innerBlurThickness / blurPar);
		mat.SetFloat("_OuterBlurThickness", outerBlurThickness / blurPar);
		//レンダリング
		mat.SetPass(0);
		Graphics.DrawMeshNow(mesh, transform.localToWorldMatrix);
	}
#endregion
}