using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilCubeAI : MonoBehaviour {

    Transform nearestCollector;

    public float collectorInterestedTime = 5.0f;
    public float speed = 3.0f;
    float timeSinceChosenCollector = 10000f;

    private bool markedForDeath;

	// Use this for initialization
	void Start () {
        ChooseNearestCollector();
        markedForDeath = false;
	}
	
	// Update is called once per frame
	void Update () {
        timeSinceChosenCollector += Time.deltaTime;
        if(timeSinceChosenCollector > collectorInterestedTime)
        {
            ChooseNearestCollector();
        }
        MoveTowardChosenCollector();
	}

    void MoveTowardChosenCollector()
    {
        this.transform.position += (nearestCollector.position - this.transform.position).normalized * speed * Time.deltaTime;
    }

    void ChooseNearestCollector()
    {
        GameObject[] collectors = GameObject.FindGameObjectsWithTag("Collector");
        float minimumDistance = float.MaxValue;
        float tempDistance = 0;
        foreach(GameObject col in collectors)
        {
            tempDistance = (col.transform.position - this.transform.position).magnitude;
            if(tempDistance < minimumDistance)
            {
                this.nearestCollector = col.transform;
                minimumDistance = tempDistance;
            }
        }
        timeSinceChosenCollector = 0;
    }

    public void Collect()
    {
        /*
        this.markedForDeath = true;
        TurnInvisible();
        Debug.Log("I got called");
        */
        
    }

    void TurnInvisible()
    {
        this.GetComponent<MeshRenderer>().enabled = false;
    }

    
}
