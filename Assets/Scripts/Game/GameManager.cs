using UnityEngine;
using System.Collections;

public class GameManager : SingletonMonoBehaviour<GameManager> {
	// ゲームのスコア.
	public int score;
	// デプシー神殿のHP.
	public int HP;
	// Wave数
	public int waveCount;
	// ゲームのステータス.
	public enum State{WAIT,PLAY,RESULT,};
	public State state = State.PLAY;
	// これがtrueなら、ノーダメージ.
	public bool isNoDamage;
}