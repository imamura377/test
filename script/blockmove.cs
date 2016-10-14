using UnityEngine;
using System.Collections;

public class blockmove : MonoBehaviour {
    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update() {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(Mathf.Sin(Time.time) * 100f, 0f);
	
	}
}
