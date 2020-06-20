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
    private int MarbleValue;
    public float Force = 10;
    //Setup the marble based on colour
    public void SetupMarble(MarbleColour Colour)
    {
        MeshRenderer Mesh = this.GetComponent<MeshRenderer>();
        switch (Colour)
        {
            case MarbleColour.GREEN:
                MarbleValue = 10;
                Mesh.material = Resources.Load("Materials/Green", typeof(Material)) as Material;
                break;
            
            case MarbleColour.BLUE:
                MarbleValue = 20;
                Mesh.material = Resources.Load("Materials/Blue", typeof(Material)) as Material;
                break;

            case MarbleColour.YELLOW:
                Mesh.material = Resources.Load("Materials/Yellow", typeof(Material)) as Material;
                MarbleValue = 30;
                break;

            case MarbleColour.PURPLE:
                Mesh.material = Resources.Load("Materials/Purple", typeof(Material)) as Material;
                MarbleValue = 50;
                break;

            case MarbleColour.RED:
                Mesh.material = Resources.Load("Materials/Red", typeof(Material)) as Material;
                MarbleValue = -60;
                break;
          
        }

    }


    //Retrieve the marble value
    int GetPointValue()
    {
        return MarbleValue;
    }

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rigidbody = this.GetComponent<Rigidbody>();
        Vector3 direction = new Vector3(Random.insideUnitCircle.x, Random.insideUnitCircle.y, 1.0f) * Random.Range(-10.0f, 10.0f) * Force;
        rigidbody.AddForce(direction);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
