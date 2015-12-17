using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SkiScript : MonoBehaviour {

	public Rigidbody rb;

	void Update () {
	
		if (Input.GetKeyDown(KeyCode.Mouse0)) {
			rb.isKinematic = false;
		}
		if (Input.GetKeyDown(KeyCode.Mouse1)) {
			SceneManager.LoadScene("scene");
		}
	}
}
