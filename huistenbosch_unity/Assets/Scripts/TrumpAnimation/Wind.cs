using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Only for Trump
public class Wind : MonoBehaviour {

	public float coefficient;   // 空気抵抗係数
	public Vector3 velocity;    // 風速

	void OnTriggerStay(Collider col) {
		if ( col.GetComponentInParent<Rigidbody>() == null ) {
			return;
		}
		Debug.Log ("Hit");
		// 相対速度計算
		var relativeVelocity = velocity - col.GetComponentInParent<Rigidbody>().velocity;

		// 空気抵抗を与える
		col.GetComponentInParent<Rigidbody>().AddForce(coefficient * relativeVelocity);
	}
}
