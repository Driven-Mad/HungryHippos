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

    //Setup the marble based on colour
    public void SetupMarble(MarbleColour Colour)
    {
        MeshRenderer Mesh = this.GetComponent<MeshRenderer>();
        switch (Colour)
        {
            case MarbleColour.GREEN:
                marbleValue = 10;
                Mesh.material = Resources.Load("Materials/Green", typeof(Material)) as Material;
                break;
            
            case MarbleColour.BLUE:
                marbleValue = 20;
                Mesh.material = Resources.Load("Materials/Blue", typeof(Material)) as Material;
                break;

            case MarbleColour.YELLOW:
                Mesh.material = Resources.Load("Materials/Yellow", typeof(Material)) as Material;
                marbleValue = 30;
                break;

            case MarbleColour.PURPLE:
                Mesh.material = Resources.Load("Materials/Purple", typeof(Material)) as Material;
                marbleValue = 50;
                break;

            case MarbleColour.RED:
                Mesh.material = Resources.Load("Materials/Red", typeof(Material)) as Material;
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

    }
}
