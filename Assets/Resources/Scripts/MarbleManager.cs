using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarbleManager : MonoBehaviour
{
    public GameObject[] spawners;
    public List<MarbleSpawning> spawnersBehaviour;
    int totalCount = 0 ;
    public GameObject ballCountUI;
    Text uiScoreText;
    // Start is called before the first frame update
    void Start()
    {
        if (ballCountUI)
        {
            uiScoreText = ballCountUI.GetComponent<Text>();
        }
        foreach (GameObject spawner in spawners)
        {
            MarbleSpawning script = spawner.GetComponent<MarbleSpawning>();
            if(script)
            {
                spawnersBehaviour.Add(script);
                totalCount += script.spawnedMarbleCount;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        int totalRemainng = 0;
        foreach (MarbleSpawning behaviour in spawnersBehaviour)
        {
            totalRemainng += behaviour.spawnedMarbleCount;
            string text = totalRemainng.ToString() + "/" + totalCount.ToString();
            uiScoreText.text = text;
        }
    }
}
