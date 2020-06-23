using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MarbleBehaviour : MonoBehaviour
{

    //Enum for handling different types of marbles
    public enum MarbleColour
    {
        GREEN,
        BLUE,
        YELLOW,
        PURPLE,
        RED
    };

    //Value for storing point system
    private int marbleValue;
    public Rigidbody marbleRigidbody;
    public bool resetMe = false;
    public bool endMe = false;
    public bool pendingEndMe = false;
    public MeshRenderer marbleMeshRenderer;

    //Setup the marble based on colour
    public void SetupMarble(MarbleColour Colour)
    {
        marbleMeshRenderer = this.GetComponent<MeshRenderer>();
        marbleRigidbody = this.GetComponent<Rigidbody>();
        switch (Colour)
        {
            case MarbleColour.GREEN:
                marbleValue = 10;
                marbleMeshRenderer.material = Resources.Load("Materials/Green", typeof(Material)) as Material;
                break;
            
            case MarbleColour.BLUE:
                marbleValue = 20;
                marbleMeshRenderer.material = Resources.Load("Materials/Blue", typeof(Material)) as Material;
                break;

            case MarbleColour.YELLOW:
                marbleMeshRenderer.material = Resources.Load("Materials/Yellow", typeof(Material)) as Material;
                marbleValue = 30;
                break;

            case MarbleColour.PURPLE:
                marbleMeshRenderer.material = Resources.Load("Materials/Purple", typeof(Material)) as Material;
                marbleValue = 50;
                break;

            case MarbleColour.RED:
                marbleMeshRenderer.material = Resources.Load("Materials/Red", typeof(Material)) as Material;
                marbleValue = -60;
                break;
          
        }

    }


    //Retrieve the marble value
    public int GetPointValue()
    {
        return marbleValue;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Handling falling out of map
        if(transform.position.y < -20.0f)
        {
            resetMe = true;
        }
        Debug.DrawRay(transform.position, (transform.forward *2), Color.cyan);
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            resetMe = true;
            Debug.Log("Hitting wall");
        }
    }
}
