using UnityEngine;
using System.Collections;

public class DestoryByTime : MonoBehaviour {
	public float lifeTime;

	void Start () {
		Destroy (gameObject, lifeTime);
	}
}
