using UnityEngine;
using System.Collections;
using NCMB;
using System.Collections.Generic;

public class RankingController : MonoBehaviour {

	[SerializeField]
	int listLimit;

	/// <summary>
	/// スコアの保存.
	/// </summary>
	void HighScoreSetter(string playerName, int score){
		NCMBObject obj = new NCMBObject ("HighScore");
		obj ["Name"] = playerName;
		obj ["Score"] = score;
		obj.SaveAsync ();
	}

	/// <summary>
	/// ランキングの取得.
	/// </summary>
	void HighScoreGetter() {
		NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject> ("HighScore");

		// Scoreフィールドの降順でデータを取得.
		query.OrderByDescending("Score");

		// 検索件数を設定.
		query.Limit = listLimit;

		// データストアで検索を行う.
		query.FindAsync (( List<NCMBObject> objList, NCMBException e) => {
			if ( e != null) {
				// 検索失敗時の処理.
			} else {
				// 検索成功時の処理.
			}
		});
	}
}
