using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public List<Vector2> points;
    public float newPointThreshold = 0.2f;
    Vector2 lastPosition;
    LineRenderer lineRenderer;
    Vector2 currentPosition;
    Rigidbody2D rb;
    float speed;
    public AnimationCurve landing;
    float landingTimer;

    List<Sprite> spritesList;
    public Sprite s1;
    public Sprite s2;
    public Sprite s3;
    public Sprite s4;
    
    SpriteRenderer spriteRenderer;
    Vector3 myPosition;

    

    void Start()
    {
        Vector3 myPosition = transform.position;
        myPosition.x = Random.Range(-5, 5);
        myPosition.y = Random.Range(-5, 5);
        Quaternion myRotation = transform.rotation;
        myRotation.z = Random.Range(0, 360);
        speed = Random.Range(1, 3);
        

        spriteRenderer = GetComponent<SpriteRenderer>();
        spritesList = new List<Sprite>();
        spritesList.Add(s1);
        spritesList.Add(s2);
        spritesList.Add(s3);
        spritesList.Add(s4);
        spriteRenderer.sprite = spritesList[Random.Range(0,3)];

        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);

        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        currentPosition = transform.position;
        if (points.Count > 0)
        {
            Vector2 direction = points[0] - currentPosition;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            rb.rotation = -angle;
        }
        rb.MovePosition(rb.position + (Vector2)transform.up * speed * Time.deltaTime);
    }

    void Update()
    {
        Vector3 myPosition = transform.position;
        if (Input.GetKey(KeyCode.Space))
        {
            landingTimer += 0.1f * Time.deltaTime;
            float interpolation = landing.Evaluate(landingTimer);
            if(transform.localScale.z < 0.1f)
            {
                Destroy(gameObject);
            }
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, interpolation);
        }

        lineRenderer.SetPosition(0, transform.position);
        if (points.Count > 0)
        {
            if(Vector2.Distance(currentPosition, points[0]) < newPointThreshold)
            {
                points.RemoveAt(0);
                
                for (int i = 0; i < lineRenderer.positionCount -2; i++)
                {
                    lineRenderer.SetPosition(i, lineRenderer.GetPosition(i + 1));
                }
                if (lineRenderer.positionCount != 0) lineRenderer.positionCount--;
            }
        }

        
        if (myPosition.x < -10 || myPosition.x > 10 || myPosition.y < -5 || myPosition.y > 5)
        {
            Destroy(gameObject);
        }
        

    }

    void OnMouseDown()
    {
        points = new List<Vector2>();
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        points.Add(newPosition);
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);

    }

    void OnMouseDrag() 
    {
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(Vector2.Distance(lastPosition, newPosition) > newPointThreshold )
        {
            points.Add(newPosition);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, newPosition);
            lastPosition = newPosition;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        spriteRenderer.color = Color.red;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        spriteRenderer.color = Color.white;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        float dist = Vector3.Distance(collision.gameObject.transform.position, transform.position);
        
        if(dist < 2)
        {
            spriteRenderer.color = Color.red; //signifier for the player
        }
        
        if (dist < 0.75)
        {
            Destroy(gameObject);
        }

    }


}
