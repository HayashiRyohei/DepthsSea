using UnityEngine;
using System.Collections;
using NCMB;
using System.Collections.Generic;

public class UserAuth : SingletonMonoBehaviour<UserAuth> {

	private string currentPlayerName;

	// mobile backendに接続してログイン.
	public void LogIn(string id, string pw) {
		NCMBUser.LogInAsync(id, pw, (NCMBException e) => {
			// 接続成功したら.
			if (e == null) {
				currentPlayerName = id;
			}
		});
	}

	// mobile backendに接続して新規会員登録(メール有).
	public void SignUp(string id, string mail, string pw) {
		NCMBUser user = new NCMBUser ();
		user.UserName = id;
		user.Email = mail;
		user.Password = pw;
		user.SignUpAsync ((NCMBException e) => {
			if (e == null) {
				currentPlayerName = id;
			}
		});
	}

	// mobile backendに接続して新規会員登録(メール無).
	public void SignUp(string id, string pw) {
		NCMBUser user = new NCMBUser ();
		user.UserName = id;
		user.Password = pw;
		user.SignUpAsync ((NCMBException e) => {
			if (e == null) {
				currentPlayerName = id;
			}
		});
	}


	// mobile backendに接続してログアウト.
	public void LogOut() {
		NCMBUser.LogOutAsync ((NCMBException e) => {
			if (e == null) {
				currentPlayerName = null;
			}
		});
	}

	// 現在のプレイヤー名を返す.
	public string CurrentPlayer() {
		return currentPlayerName;
	}
}

/*
 * SignUpAsyncメソッドでメールアドレスの入力は必須ではない.
 * メールアドレスを登録するメリット.
 * ・パスワードのリセットができる.
 * ・登録時に本人確認のメールの送信ができる.
 */