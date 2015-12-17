using UnityEngine;
using System.Collections;

public class GearVRTouchpadMovement : MonoBehaviour {
    public float speed;
    Transform cam;
    Vector3 originalPosition;

	// Use this for initialization
	void Start () {
        cam = Camera.main.transform;
        originalPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxis("Mouse X") * speed * Time.deltaTime;
        float y = Input.GetAxis("Mouse Y") * speed * Time.deltaTime;
        transform.position += x * cam.right + y * cam.up;
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            transform.position = originalPosition;
        }

    }
}
