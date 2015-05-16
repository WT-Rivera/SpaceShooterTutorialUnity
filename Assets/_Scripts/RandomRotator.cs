using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour 
{
    public float tumble;

    void Start ()
    {
        //adds an angular velocity rotation for the asteroid and sets it to a random Vector3 rotation value from insideUnitSphere with the set tumble speed
        rigidbody.angularVelocity = Random.insideUnitSphere * tumble;
    }
}
