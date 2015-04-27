using UnityEngine;
using System.Collections;

public class MyShip : MonoBehaviour {

	bool pressedUp;
	bool pressedDown;
	bool pressedRight;
	bool pressedLeft;

	const float moveSpeed = 0.15f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			pressedUp = true;
			pressedDown = false;
		} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			pressedDown = true;
			pressedUp = false;
		}
		if (Input.GetKeyUp(KeyCode.UpArrow)) {
			pressedUp = false;
		}
		if (Input.GetKeyUp(KeyCode.DownArrow)) {
			pressedDown = false;
		}

		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			pressedRight = true;
			pressedLeft = false;
		} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			pressedLeft = true;
			pressedRight = false;
		}
		if (Input.GetKeyUp(KeyCode.RightArrow)) {
			pressedRight = false;
		}
		if (Input.GetKeyUp(KeyCode.LeftArrow)) {
			pressedLeft = false;
		}

		Vector3 move = Vector3.zero;
		if (pressedUp) {
			move.y += (pressedRight || pressedLeft)? moveSpeed/2 : moveSpeed;
		} else if (pressedDown) {
			move.y -= (pressedRight || pressedLeft)? moveSpeed/2 : moveSpeed;
		}
		if (pressedRight) {
			move.x += (pressedUp || pressedDown)? moveSpeed/2 : moveSpeed;
		} else if (pressedLeft) {
			move.x -= (pressedUp || pressedDown)? moveSpeed/2 : moveSpeed;
		}
		transform.position += move;
	}
}
