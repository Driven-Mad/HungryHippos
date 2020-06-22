using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleSpawning : MonoBehaviour
{
    //Game object we want to instantiate. 
    public GameObject marble;

    //Both lists should be exactly the same size as there'll always be a behaviour script attached to each marble. 
    private List<GameObject> spawnedMarbles = new List<GameObject>();
    private List<MarbleBehaviour> spawnedMarbleBehaviours = new List<MarbleBehaviour>();


    private float force = 20.0f;

    //public for visability for now. 
    public int spawnedMarbleCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        SpawnAllMarbles();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position, transform.position + (transform.forward * 10), Color.red, 2, false);
        checkForResets();

     
    }

    public void SpawnAllMarbles()
    {
        //TODO: Need to stagger these as well so that they finish first before next starts. 
        //TODO: Need to get the manager to distribute the balls being spawned. 
        int greenAmount = 4, blueAmout = 2, yellowAmount = 2, purpleAmount = 1, redAmount = 1;
        StartCoroutine(SpawnMarble(MarbleBehaviour.MarbleColour.GREEN, greenAmount)); 
        StartCoroutine(SpawnMarble(MarbleBehaviour.MarbleColour.BLUE , blueAmout));
        StartCoroutine(SpawnMarble(MarbleBehaviour.MarbleColour.YELLOW, yellowAmount));
        StartCoroutine(SpawnMarble(MarbleBehaviour.MarbleColour.PURPLE, purpleAmount));
        StartCoroutine(SpawnMarble(MarbleBehaviour.MarbleColour.RED, redAmount));
        spawnedMarbleCount = greenAmount + blueAmout + yellowAmount + purpleAmount + redAmount;

    }

    IEnumerator SpawnMarble(MarbleBehaviour.MarbleColour colour, int amount)
    {
        for (int it = 0; it < amount; it++)
        {
            //Create a marble
            GameObject Instance = Instantiate(marble, transform.position, Quaternion.identity);
            if (Instance != null)
            {
                //Grab the behaviour script
                MarbleBehaviour behaviour = Instance.GetComponent<MarbleBehaviour>();
                //Add to our instatiated gameobjects so that we're able to keep track of them. 
                spawnedMarbles.Add(Instance);
                //Setup marble behaviour from script. 
                if (behaviour != null)
                {
                    spawnedMarbleBehaviours.Add(behaviour);
                    //To do? Maybe change force per colour
                    behaviour.SetupMarble(colour);
                    //Should always have it, better safe than sorry though. 
                    if (behaviour.marbleRigidbody)
                    {
                        //Grab rigidbody so we can shoot it from our cannons. 
                        behaviour.marbleRigidbody.AddForce(transform.forward * force, ForceMode.Impulse);
                    }
                }
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    void checkForResets()
    {
        for(int it = 0; it < spawnedMarbles.Count; it++)
        {
            if (spawnedMarbles[it] != null)
            {
                GameObject marble = spawnedMarbles[it];
                MarbleBehaviour behaviour = spawnedMarbleBehaviours[it];
                if(behaviour)
                {
                    if (behaviour.resetMe)
                    {
                        //Reset the transform
                        marble.transform.position = transform.position;
                        marble.transform.rotation = new Quaternion(0.0f,0.0f,0.0f, 0.0f);
                        //reset force on the ball
                        behaviour.marbleRigidbody.velocity = Vector3.zero;
                        behaviour.marbleRigidbody.AddForce(transform.forward * force, ForceMode.Impulse);
                        behaviour.resetMe = false;
                    }
                    if(behaviour.endMe)
                    {
                        Destroy(marble);
                        spawnedMarbleCount -= 1;
                    }
                }
           
            }
            else
            {
                Debug.Log("Marble no longer exists.");
            }
        };
    }

}
