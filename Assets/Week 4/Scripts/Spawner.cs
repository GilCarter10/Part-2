using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefab;
    float time;
    float timerTarget;
    void Start()
    {
        time = 0;
        timerTarget = Random.Range(1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > timerTarget)
        {
            Instantiate(prefab, transform.position, transform.rotation);
            time = 0;
            timerTarget = Random.Range(1, 5);
        }
        
    }
}
