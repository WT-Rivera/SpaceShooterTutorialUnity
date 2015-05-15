using UnityEngine;
using System.Collections;

//Serializable public class for boundary variables that can be acccessed by other classes.
[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;

}

/*
 * Can make a publically accesible structure for the same thing, since a struct and a class is essentially the same thing.
 * 
[System.Serializable]
public struct Boundary
{
	public float xMin, xMax, zMin, zMax;
}
*/

public class PlayerController : MonoBehaviour 
{
	public float speed;
	public Boundary boundary;
	public float tilt;

	public GameObject shot;
	public Transform shotSpawn;

	public float fireRate;
	public float nextFire;

	void Update()
	{
		if (Input.GetButton ("Fire1") && Time.time > nextFire) 
		{
			nextFire =  Time.time + fireRate;
			//GameObject clone = 
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation); // as GameObject;
		}
	}

	void FixedUpdate()
	{
		//automatically mapped to WASD, varaibles for movment
		float moveHoritzontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		//define new movement with inputs on Vertical and Horizontal axes
		Vector3 movement = new Vector3 (moveHoritzontal, 0.0f, moveVertical); 
		rigidbody.velocity = movement * speed; //velocity determined by movement varible * speed variable

		//boundary code
		rigidbody.position = new Vector3 //make new positions
		(
			//clamp min and max positions on x and z axes.
			Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp (rigidbody.position.z, boundary.zMin, boundary.zMax)
		);

		//tilt code that takes the rigidbody velocity value on the x axis and multiplies it by the editor set tilt value in negative so it tilts the opposite way. 
		rigidbody.rotation = Quaternion.Euler (0.0f,0.0f,rigidbody.velocity.x * -tilt);
	}
}
