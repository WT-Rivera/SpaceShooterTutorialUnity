using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour 
{
    public GameObject explosion;
    public GameObject playerExplosion;

    void OnTriggerEnter(Collider other)
    {
        //Checks to see what the collided object is tagged with
        if (other.tag == "Boundary")
        {
            return;     //Ends the function without execution
        }
        //Destory other Gameobject and Gameobject script is attached to 
        Destroy(other.gameObject);
        Destroy(gameObject);
        Instantiate (explosion, transform.position, transform.rotation);
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
        }
    }
}