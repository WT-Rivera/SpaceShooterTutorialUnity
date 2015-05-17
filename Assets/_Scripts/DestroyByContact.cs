using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour 
{
    public GameObject explosion;
    public GameObject playerExplosion;

    //int for score
    public int scoreValue;

    //private reference for GameController Instance
    private GameController gameController;

    void Start()
    {
        //look for an instance of the GameController GameObject tagged with "GameController"
        GameObject gameControllerObject = GameObject.FindWithTag ("GameController");

        //if there is a reference to the gameController Object, 
        if (gameControllerObject != null)
        {
            //set the game controller reference to the game controller component on the game controller object
            gameController = gameControllerObject.GetComponent<GameController>();
        }

        //if there is no reference to the gameController Object
        if (gameController == null)
        {
            Debug.Log("Can't find GameController");
        }
    }

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

        //call AddScore() from GameController class and send scoreValue
        gameController.AddScore(scoreValue);

        //if other object tagged "Player" collides, instantiate player explosion at last position and rotation 
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);

            //call game over function
            gameController.GameOver();
        }
    }
}