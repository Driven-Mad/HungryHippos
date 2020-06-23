using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpponentBehaviour : MonoBehaviour
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

        //Change UI Score
        if (scoreUI)
        {
            uiScoreText.text = score.ToString();
        }
    }
    public IEnumerator EatMarble(GameObject marble)
    {
        MarbleBehaviour behaviour = marble.GetComponent<MarbleBehaviour>();
        if (behaviour.pendingEndMe != true)
        {
            behaviour.pendingEndMe = true;
            if (animator)
            {
                animator.Play("Base Layer.NeckAnim", 0, 0);
            }
            score += behaviour.GetPointValue();
            yield return new WaitForSeconds(0.2f);
            behaviour.endMe = true;
        }

    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Marble" )
        {
            Debug.Log(other.gameObject.name);
            other.attachedRigidbody.velocity = Vector3.zero;
            StartCoroutine(EatMarble(other.gameObject));
        }
    }
}
