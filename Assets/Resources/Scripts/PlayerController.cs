using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    int score = 0;
    Animator animator;
    public GameObject scoreUI;
    Text uiScoreText;
    int wallAmount;
    int wallHighlight;
    float highlightChangeCountdown;
    public GameObject[] wallPanels;
    public Material arenaMaterial;
    public Material highlightMaterial;
    bool highligthReverse = false;
    public float force = 0;
    float forceCap = 2.0f;
    float forceAmplifier= 0.1f;



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        if (scoreUI)
        {
            uiScoreText = scoreUI.GetComponent<Text>();
        }
        wallAmount = wallPanels.Length;
        highlightChangeCountdown = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        highlightChangeCountdown -= Time.deltaTime;

        if(highlightChangeCountdown < 0)
        {
            wallPanels[wallHighlight].GetComponent<MeshRenderer>().material = arenaMaterial;
            wallHighlight += highligthReverse ? -1 : 1;

            if (wallHighlight == wallAmount-1 )
            {
                highligthReverse = true;
            }
            if (wallHighlight == 0)
            {
                highligthReverse = false ;
            }
            wallPanels[wallHighlight].GetComponent<MeshRenderer>().material = highlightMaterial;
            highlightChangeCountdown = 0.2f;
        }
        RaycastHit objectHit;
        Debug.DrawRay(wallPanels[wallHighlight].transform.position, -wallPanels[wallHighlight].transform.right * 30, Color.green);
        if (Physics.Raycast(wallPanels[wallHighlight].transform.position, -wallPanels[wallHighlight].transform.right, out objectHit, 30))
        {
            if (objectHit.collider.gameObject.tag == "Marble")
            {
                Debug.Log("Ray hit marble");
                objectHit.rigidbody.AddForce(-wallPanels[wallHighlight].transform.right * force, ForceMode.VelocityChange);

            }
        }
        Debug.Log(score);
        //play the neck animation
        if(Input.GetKey(KeyCode.Space))
        {
            if (animator)
            {
                Debug.Log("Pressing play animation");
                animator.Play("Base Layer.NeckAnim", 0, 0);
            }
        }
        if (Input.GetKey(KeyCode.W))
        {
            force = forceCap;
        }
        if (Input.GetKey(KeyCode.S))
        {
            force = -forceCap;
        }
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.W))
        {
            force = 0;
        }
        //Change UI Score
        if (scoreUI)
        {
            uiScoreText.text = score.ToString();
        }

    }
    public IEnumerator EatMarble(GameObject marble)
    {
        MarbleBehaviour behaviour = marble.GetComponent<MarbleBehaviour>();
        if (!behaviour.pendingEndMe)
        {
            behaviour.pendingEndMe = true;
            score += behaviour.GetPointValue();
            yield return new WaitForSeconds(0.5f);
            behaviour.endMe = true;
        }

    }
    
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Marble" && Input.GetKey(KeyCode.Space))
        {
            Debug.Log(other.gameObject.name);
            other.attachedRigidbody.velocity = Vector3.zero;
            StartCoroutine(EatMarble(other.gameObject));
        }
    }


    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Marble")
        { Debug.Log("Marble hitting"); }
    }
}
