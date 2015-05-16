using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour 
{
    //variable for seconds
    public float lifetime;

    void Start()
    {
        //destroy gameobject script is attached to after lifetime
        Destroy(gameObject, lifetime);
    }
}
