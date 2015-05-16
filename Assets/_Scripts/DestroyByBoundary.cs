using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour 
{
    //When something collides with the boundary box fro the inside...
	void OnTriggerExit(Collider other)
	{
        //destroy that object
		Destroy (other.gameObject);
	}
}
