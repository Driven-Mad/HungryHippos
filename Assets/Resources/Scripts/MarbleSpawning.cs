using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleSpawning : MonoBehaviour
{
    public GameObject marble;
    private float force = 20.0f;
    bool doOnce = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAllMarbles());
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position, transform.position + (transform.forward * 10), Color.red,2,false);
    }

    public IEnumerator SpawnAllMarbles()
    {
        for (int x = 0; x < 10; x++)
        {
            //new Vector3(Random.insideUnitCircle.x, Random.insideUnitCircle.y, 1.0f) * Random.Range(-RangeSize, RangeSize) + transform.position
            SpawnMarble(MarbleBehaviour.MarbleColour.GREEN);
            SpawnMarble(MarbleBehaviour.MarbleColour.BLUE);
            yield return new WaitForSeconds(0.5f);
        }

    }
    void SpawnMarble(MarbleBehaviour.MarbleColour colour)
    {
        GameObject Instance = Instantiate(marble, Vector3.zero + transform.position, Quaternion.identity);
        if (Instance != null)
        {
            MarbleBehaviour MyScript = Instance.GetComponent<MarbleBehaviour>();
            
            if (MyScript != null)
            {
                MyScript.SetupMarble(colour);
            }

            Rigidbody rigidbody = Instance.GetComponent<Rigidbody>();
            rigidbody.AddForce(transform.forward * force, ForceMode.Impulse);
        }
        
    }

}
