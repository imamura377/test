using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class goal : MonoBehaviour {

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /*void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("OK");
        SceneManager.LoadScene("goal");
    }*/

    void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene("goal");
    }
}
