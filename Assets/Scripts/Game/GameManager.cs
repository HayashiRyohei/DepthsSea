using UnityEngine;
using System.Collections;
using System.Text;

public class GameManager : SingletonMonoBehaviour<GameManager> {
	// ゲームのスコア(初期状態は0).
	private  int score;
	public int Score{
		get{return this.score;}
	}
	//デプシー神殿の最大HP.
	private int maxHp;
	public int MaxHP {
		get {return maxHp;}
	}
	// デプシー神殿のHP.
	private int hp;
	public int HP{
		get{return this.hp;}
	}
	// Wave数(初期状態は0).
	private int waveCount;
	public int WaveCount {
		get{return this.waveCount;} 
	}
	// 全体のコスト.
	private int unitCost;
	public int UnitCost { 
		get{ return this.unitCost; }
	}
	// ゲームのステータス.
	public enum State{
		NONE,	//初期
		WAIT,	//待機(ユニット配置)
		PLAY,	//ゲーム
		RESULT	//結果発表
	};
	public State state = State.NONE;
	// 選択されているマーカー
	private GameObject selectMarker;
	public GameObject Marker {
		get{ return this.selectMarker; }
		set { this.selectMarker = value; }
	}
	//タイマー
	public Timer timer;
	//背景アニメータ
	public Animator backgroundAnimator;
	//リザルト画面UI
	public ResultUI resultUI;
	//スコア関連
	private int destroyEnemy;						//撃破数
	private const int destroyEnemyBonus = 100;		//撃破ボーナス
	private int oneWaveDamage;					//1Waveで受けたダメージ
	private const int oneWaveDamageBonus = -10;	//ダメージボーナス
	private const int noDamageBonus = 1000;		//ノーダメージボーナス

#region MonoBehaviourEvent
	private void Awake() {
		InitManager ();
		//とりあえずプレイに
		ChangeState(State.PLAY);
	}
#endregion
#region StateFunction
	public void ChangeState(State nextState) {
		if(state == nextState) return;
		switch(nextState) {
			case State.NONE:
				ChangeState_None();
			break;
			case State.PLAY:
				ChangeState_Play();
			break;
			case State.RESULT:
				ChangeState_Result();
			break;
			case State.WAIT:
				ChangeState_Wait();
			break;
		}
		state = nextState;
	}
	//状態変更用
	private void ChangeState_None() {

	}
	private void ChangeState_Play() {
		//初期化
		waveCount++;
		destroyEnemy = 0;
		oneWaveDamage = 0;
		//アニメータ開始
		backgroundAnimator.SetBool("play", true);
		//タイマー開始
		timer.Play(60f, gameObject, "OnPlayTimeEnd");
		//ウェーブ開始
		WaveManager.Instance.WaveStart(waveCount);
	}
	private void ChangeState_Result() {
		if(hp != 0) {
			//表示用テキスト
			int addScore;
			string resultText = GetWaveResultString(out addScore);
			score += addScore;
			//リザルト画面表示
			resultUI.Indicate(resultText, false);
		} else {
			//リザルト画面表示
			resultUI.Indicate(score.ToString(), true);
		}
	}
	private void ChangeState_Wait() {
		
	}
	//Play状態
	public void OnPlayTimeEnd() {
		//ウェーブ終了
		WaveManager.Instance.WaveEnd();
		//背景アニメーションの停止
		backgroundAnimator.SetBool("play", false);
		//リザルト状態に移動
		ChangeState(State.RESULT);
	}
#endregion
	/// <summary>
	/// 初期化用.
	/// </summary>
	private void InitManager() {
		this.score = 0;
		this.hp = this.maxHp = 100;
		this.waveCount = 0;
		selectMarker = null;
	}
	/// <summary>
	/// HPを削る.
	/// </summary>
	public void Damage(int damage) {
		this.hp -= damage;
		oneWaveDamage += damage;
		if(this.hp <= 0) {
			this.hp = 0;
			//リザルト表示
			ChangeState(State.RESULT);
		}
	}
	/// <summary>
	/// Wave数を増やす.
	/// </summary>
	public void AddWave() { 
		waveCount++;
	}
	/// <summary>
	/// コストを増減させる.
	/// </summary>
	public void CalcCost(int cost) {
		unitCost += cost;
	}
	/// <summary>
	/// 敵の撃破数を増やす
	/// </summary>
	public void AddDestroyEnemy() {
		destroyEnemy++;
	}
	/// <summary>
	/// ウェーブのリザルト用文字列を返す
	/// </summary>
	private string GetWaveResultString(out int addScore) {
		StringBuilder sb = new StringBuilder();
		addScore = 0;
		//撃破ボーナス
		int destroyBonus = destroyEnemy * destroyEnemyBonus;
		addScore += destroyBonus;
		sb.AppendLine("Destroy..." + destroyEnemy + " × " + destroyEnemyBonus);
		//ダメージボーナス
		int damageBonus = oneWaveDamage * oneWaveDamageBonus;
		addScore += damageBonus;
		sb.AppendLine("Damage..." + oneWaveDamage + " × " + oneWaveDamageBonus);
		//ノーダメージボーナス
		if (oneWaveDamage == 0) {
			addScore += noDamageBonus;
			sb.AppendLine("    NoDamage!..." + noDamageBonus);
		}
		sb.AppendLine("");
		//追加スコア		
		sb.AppendLine("Score..." + addScore);
		//合計スコア
		sb.Append("TotalScore..." + (addScore + score));
		return sb.ToString();
	}
}