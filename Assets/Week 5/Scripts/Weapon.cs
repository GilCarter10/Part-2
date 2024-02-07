using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Weapom : MonoBehaviour
{
    public float speed = 5;
    float timer;
    public GameObject knight;
    CapsuleCollider2D capsuleCollider;
    void Start()
    {
        timer = 0;
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.Translate(0, speed * Time.deltaTime, 0);
        if (timer > 3)
        {
            Destroy(gameObject);
        }
            
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        knight.SendMessage("TakeDamage", 1);
        Destroy(gameObject);
    }

}
