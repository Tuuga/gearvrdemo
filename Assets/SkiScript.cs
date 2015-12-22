using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SkiScript : MonoBehaviour {

	public GameObject vrCamera;
	public Transform cameraPos;
	public float startSpeed;
	Rigidbody rb;
	public float velocityBoostTime = 5.0f;
	float jumpTime;
	public float boostPerTime;
	public float jumpForce;
	public float airDrag;
	public float recoveryRot;
	public float slowingDrag;
	float startTimer;
	public AudioSource startSpeak;
	public AudioSource skiSound;
	public AudioSource endSpeak;
	public AudioSource windLoop;
	bool canGo;
	public float canGoTimer;


	void Start () {
		jumpTime = -1f;
		rb = GetComponent<Rigidbody>();
		Invoke("startSound", 5f);
    }

	void Update () {

		startTimer += Time.deltaTime;
		if (startTimer > canGoTimer && !canGo) {
			canGo = true;
			//Beep

		}

		vrCamera.transform.position = cameraPos.transform.position;
	
		if (Input.GetKeyDown(KeyCode.Mouse0) && canGo && jumpTime < 0f) {
			//windLoop.loop = false;
			//windLoop.Stop();
			skiSound.Play();
			rb.isKinematic = false;
			jumpTime = 0;
			rb.velocity = transform.forward * startSpeed;
		}
		if (Input.GetKeyDown(KeyCode.Mouse1)) {
			SceneManager.LoadScene("scene");
			
		}
		if (jumpTime >= 0f)
			jumpTime += Time.deltaTime;
		if (jumpTime < velocityBoostTime) {
			rb.AddForce(transform.forward * boostPerTime * Time.deltaTime, ForceMode.Acceleration);
		}
	}

	void OnTriggerEnter (Collider c) {
		if (c.tag == "Jump") {
			Debug.Log("Jump");
			rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
			rb.drag = airDrag;
		}
		if (c.tag == "Hill") {
			Debug.Log("Recovery");
			rb.AddTorque(recoveryRot, 0, 0);
		}
		if (c.tag == "Slow") {
			Debug.Log("Slow");
			rb.drag = slowingDrag;
			endSpeak.Play();
		}
	}
	void OnCollisionEnter (Collision c) {
		if (c.collider.tag == "Hill") {
			Debug.Log("Land");
			rb.drag = 0;
		}
	}
	void startSound () {
		startSpeak.Play();
	}
}
