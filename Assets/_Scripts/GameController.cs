using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
    public GameObject hazard;

    //used to make publically accessible Vector3 values that can be set in Unity Editor
    public Vector3 spawnValues;

    //integer 
    public int hazardCount;

    //public value for seconds before loop
    public float spawnWait;

    //variable for slight pause before waves begin
    public float startWait;

    //amount of time between waves
    public float waveWait;

    //Gui var for score
    public GUIText scoreText;

    //int for score;  ints should be used more than floats for scores because ints only count whole numbers
    private int score;

    void Start()
    {
        //set score to zero at start of game
        score = 0;

        //then call UpdateScore function to update score value
        UpdateScore();

        //Starts coroutine SpawnWaves
        Debug.Log("starting corutine");
        StartCoroutine (SpawnWaves());
    }

    //Changed fucntion to IEnumerator for use as a coroutine.
    IEnumerator SpawnWaves()
    {
        Debug.Log("starting block");
        //yields and then executes WaitForSeconds(startWait)
        yield return new WaitForSeconds(startWait);

        //while loop is a loop that checks if certain conditions are met for a parented loop too begin, in this case, while the for loop is true
        while(true)
        {
        //for loop that checks a number against the hazard count, and then adds to that number through every iteration until limit is met.
            for (int i = 0; i < hazardCount; i++)      //i = iteration
            {
                Debug.Log("starting loop");
                //Creates a spawn position with a random range for the spawnValues on the X axis, and the set value for the Z aixs outside game space
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);

                //Quaternion.identity corresponds with no rotation of game object
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);

                //yields logic and then executes WaitForSeconds(spawnWait)
                yield return new WaitForSeconds(spawnWait);
            }

            //wait for seconds until while loop is executed again
            yield return new WaitForSeconds(waveWait);
        }
    }

    //funtion for adding to score on destruction of gameobject
    public void AddScore(int newScoreValue)
    {
        //update score with scoreValue
        score += newScoreValue;

        //call UpdateScore()
        UpdateScore();

    }

    //new function for scoring
    void UpdateScore()
    {
        //scoretext text is written next to "Score: " and incremented by score
        scoreText.text = "Score: " + score;
    }
}
