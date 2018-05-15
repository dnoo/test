using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	Spaceship spaceship;

	IEnumerator Start () {
		spaceship = GetComponent<Spaceship> ();
		spaceship.Move (transform.up * -1);

		if (spaceship.canShot == false) {
			yield break;
		}

		while (true) {
			for (int i = 0; i < transform.childCount; i++) {
				Transform shotPosion = transform.GetChild (i);
				spaceship.Shot (shotPosion);
			}
			yield return new WaitForSeconds (spaceship.shotDelay);
		}
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D c) {
		// レイヤー名を取得
		string layerName = LayerMask.LayerToName(c.gameObject.layer);

		// レイヤー名がBullet (Player)以外の時は何も行わない
		if( layerName != "Bullet(player)") return;

		// 弾の削除
		Destroy(c.gameObject);

		// 爆発
		spaceship.Explosion();

		// エネミーの削除
		Destroy(gameObject);
	}
}
