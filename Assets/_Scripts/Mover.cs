using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour 
{
	public float speed;
	void Start()
	{
		//gives the rigibody a veloxity that travels on the z axis (forward) with the speed variable
		rigidbody.velocity = transform.forward * speed;
	}
}
