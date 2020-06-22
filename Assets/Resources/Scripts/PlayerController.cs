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

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        if (scoreUI)
        {
            uiScoreText = scoreUI.GetComponent<Text>();
        }
    }

    // Update is called once per frame
    void Update()
    {
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
        //Change UI Score
        if(scoreUI)
        {
            uiScoreText.text = score.ToString();
        }

    }
    public IEnumerator EatMarble(GameObject marble)
    {
        MarbleBehaviour behaviour = marble.GetComponent<MarbleBehaviour>();
        score += behaviour.GetPointValue();
        yield return new WaitForSeconds(0.2f);
        behaviour.endMe = true;

    }
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Marble" && Input.GetKey(KeyCode.Space))
        {
            Debug.Log(other.gameObject.name);
            StartCoroutine(EatMarble(other.gameObject));
        }
    }


    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Marble")
        { Debug.Log("Marble hitting"); }
    }
}
