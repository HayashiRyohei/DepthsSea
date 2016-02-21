using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/// <summary>
/// リザルト用UI
/// </summary>
public class ResultUI : MonoBehaviour {

	//UIパーツ
	public Text score;
	public GameObject nextButton;
	public GameObject titleButton;
	public Image forground;
	public Color normalColor = Color.blue;
	public Color gameOverColor = Color.red;

#region MonoBehaviourEvent
	private void Awake() {
		if(gameObject.activeInHierarchy) {
			Hide();
		}
	}
#endregion
#region Function
	/// <summary>
	/// 表示
	/// </summary>
	public void Indicate(string scoreText, bool isGameOver) {
		gameObject.SetActive(true);
		//スコア表示
		score.text = scoreText;
		//その他表示
		if(!isGameOver) {
			forground.color = normalColor;
			nextButton.SetActive(true);
			titleButton.SetActive(false);
		} else {
			forground.color = gameOverColor;
			nextButton.SetActive(false);
			titleButton.SetActive(true);
		}
	}
	/// <summary>
	/// 非表示
	/// </summary>
	public void Hide() {
		gameObject.SetActive(false);
	}
#endregion
#region UIEvent
	public void OnNextButtonClicked() {
		GameManager.Instance.ChangeState(GameManager.State.PLAY);
		Hide();
	}
	public void OnTitleButtonClicked() {
		//とりあえず仮
	}
#endregion
}