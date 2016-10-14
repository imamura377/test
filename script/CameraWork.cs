using UnityEngine;
using System.Collections;

public class CameraWork : MonoBehaviour {

	private Transform target;

	// Use this for initialization
	void Start () {

		target = GameObject.Find ("Player").transform;
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (target.position.x, target.position.y, transform.position.z);
	
	}
}
