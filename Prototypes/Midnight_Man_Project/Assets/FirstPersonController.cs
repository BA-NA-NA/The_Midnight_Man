using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour {
	
	public float movementSpeed = 5.0f;
	public float mouseSensitivity = 5.0f;
	public float jumpSpeed = 20.0f;
	
	float verticalRotation = 0f;
	float horizontalRotation = 0f;
	public float upDownRange = 60.0f;
	
	float verticalVelocity = 0f;
	
	CharacterController characterController;
	
	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
		characterController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		// Rotation
		
		float rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
		transform.Rotate(0f, rotLeftRight, 0f);
		
		
		verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
		horizontalRotation += Input.GetAxis("Mouse X") * mouseSensitivity;
		verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
		Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, horizontalRotation, 0);
		
		// Movement
		
		float forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
		float sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;
		
		if( characterController.isGrounded && Input.GetButton("Jump") ) {
			verticalVelocity = jumpSpeed;
		}
		
		Vector3 speed = new Vector3( sideSpeed, 0f, forwardSpeed );
		
		speed = transform.rotation * speed;

		verticalVelocity += Physics.gravity.y * Time.deltaTime;

		speed.y = verticalVelocity;

		characterController.Move( speed * Time.deltaTime );

	}
}
