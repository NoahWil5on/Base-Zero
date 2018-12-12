using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopRotate : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		this.gameObject.GetComponent<Transform>().Rotate(0,1,0);
	}
}
