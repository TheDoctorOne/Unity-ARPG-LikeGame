using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMovementManager : MonoBehaviour
{
	public Transform playerCam, character, centerPoint;



	private float mouseX, mouseY;

	public float mouseSensitivity = 10f;

	public float mouseYPosition = 1f;
	private float moveFB, moveLR;

	public float moveSpeed = 2f;
	private float zoom;

	public float zoomSpeed = 2;
	public float zoomMin = -2f;

	public float zoomMax = -10f;
	public float rotationSpeed = 5f;



	// Use this for initialization

	void Start()
	{

	}



	// Update is called once per frame

	void Update()
	{
		/*playerCam = this.transform;

		zoom = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;

		if (zoom < zoomMin)
			zoom = zoomMin;

		if (zoom > zoomMax)
			zoom = zoomMax;

		if(Input.GetAxis("Mouse ScrollWheel") != 0f)
			playerCam.transform.localPosition = new Vector3(playerCam.localPosition.x, playerCam.localPosition.y, playerCam.localPosition.z+zoom);

		if (Input.GetMouseButton(1))
		{
			mouseX += Input.GetAxis("Mouse X");
			mouseY -= Input.GetAxis("Mouse Y");


			Quaternion turnAngle = Quaternion.Euler(0, centerPoint.eulerAngles.y, 0);



			character.rotation = Quaternion.Slerp(character.rotation, turnAngle, Time.deltaTime * rotationSpeed);
		}

		mouseY = Mathf.Clamp(mouseY, -60f, 60f);


		centerPoint.localRotation = Quaternion.Euler(mouseY, mouseX, 0);

		//playerCam.LookAt(centerPoint);

		moveFB = Input.GetAxis("Vertical") * moveSpeed;

		moveLR = Input.GetAxis("Horizontal") * moveSpeed;


		centerPoint.position = new Vector3(character.position.x, character.position.y + mouseYPosition, character.position.z);
		Vector3 movement = new Vector3(moveLR, 0, moveFB);

		movement = character.rotation * movement;

		character.GetComponent<CharacterController>().Move(movement * Time.deltaTime);

		centerPoint.position = new Vector3(character.position.x, character.position.y + mouseYPosition, character.position.z);*/



		/*if (Input.GetAxis("Vertical") > 0 | Input.GetAxis("Vertical") < 0)
		{






		}*/



	}

}
