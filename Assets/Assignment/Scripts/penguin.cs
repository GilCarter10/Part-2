using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SocialPlatforms.Impl;
using JetBrains.Annotations;

public class penguin : MonoBehaviour
{

    //variable definitions
    Animator animator;
    Rigidbody2D rb;
    public Vector2 walkDestination;
    public Vector2 walkMovement;
    public float speed;
    bool sliding;
    float slideTimer = 0;
    public float savedY;
    public Vector3 pos;
    public GameObject blockGroup;
    bool stopMoving;
    int raceActive;
    public float stamina;

    void Start()
    {
        //gets references to compenents on the penguin object
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();


        speed = 3; //speed for point/click movement
        sliding = false; //bool for whether sliding is active

        //i made this player pref to see if the race is active because i wanted stamina to only start running when the race is going
        raceActive = PlayerPrefs.GetInt("raceActive"); 

        pos = transform.position;

        //the savedY variable is for saving the y value across scenes (if you end at the top of the scene you start there in the next one)
        savedY = PlayerPrefs.GetFloat("savedY");
        transform.position = new Vector3 (-8, savedY, 0);

        //for point and click movement
        walkDestination = transform.position;

        //player pref so stamina bar is consistant over the scenes
        stamina = PlayerPrefs.GetFloat("stamina");
        SendMessage("UpdateStamina", stamina);

    }

    private void FixedUpdate()
    {
        //this code executes the point and click movement
        walkMovement = walkDestination - (Vector2)transform.position; //finds direction and distance between the desired direction and the current position
        if (walkMovement.magnitude < 0.1) //stops the penguin if the distance to the desination is very small to prevent bugs
        {
            walkMovement = Vector2.zero;
        }

        
        rb.MovePosition(rb.position + walkMovement.normalized * speed * Time.deltaTime); //moves the rigidbody position to the unit vector of the walk movement vector
    }


    void Update()
    {
        pos = transform.position; //updates position variable

        //stamina
        if (stamina < 100 && raceActive == 1) //if the stamina is less than 100 and the race is going
        {
            stamina += Time.deltaTime * 10; //increase stamina every second
            SendMessage("UpdateStamina", stamina); //update the slider
            PlayerPrefs.SetFloat("stamina", stamina); //save to the player pref
        }
        
        //walking
        if (Input.GetMouseButtonDown(0)) //if LEFT click is pressed
        {
            walkDestination = Camera.main.ScreenToWorldPoint(Input.mousePosition); //set a new walk destination value
        }
        animator.SetFloat("walkMovement", walkMovement.magnitude); //activates walk movement animation

        //slide
        if (walkMovement.magnitude > 0.1) //you must be moving for slide to work
        {
            if (stamina >= 99) //ensures there is enough stamina
            {
                if (Input.GetKey(KeyCode.Space)) //on space pressed
                {
                    sliding = true; 
                    stamina = 0; //deplet stamina
                    PlayerPrefs.SetFloat("stamina", stamina); //save stamina player pref
                }
            }
        }

        if (sliding) //when you are sliding...
        {
            animator.SetBool("isSlide", true); //begin slide animation
            speed = 7; //increase speed while sliding
            slideTimer += Time.deltaTime; //begin the slide timer
            blockGroup.BroadcastMessage("Attack"); //be able to destroy blocks while sliding
            if (slideTimer > 0.9) //once sliding is done
            {
                sliding = false;
                animator.SetBool("isSlide", false); //stop sliding animation
                speed = 3; //revert speed to normal
                slideTimer = 0; //reset slide timer


            }
        }


        if (Input.GetMouseButtonDown(1)) //if RIGHT click is pressed
        {
            animator.SetTrigger("isAttack"); //attack animation
            blockGroup.BroadcastMessage("Attack"); //send attack message to all ice block objects
        }


        if (stopMoving) //if you have been stopped by an iceblock
        {
            if (Input.GetMouseButtonDown(0)) //the next movement click will be an attack
            {
                animator.SetTrigger("isAttack"); //attack animation
                blockGroup.BroadcastMessage("Attack"); //attack message
                stopMoving = false; //you are no longer stopped
            }
        }
    }

    public void StopMoving() //if receive stop moving message
    {
        stopMoving = true;
        walkMovement = Vector2.zero; //do not move anywhere
        walkDestination = pos;
    }

    private void OnCollisionEnter2D(Collision2D collision) //if you collide with an ice block
    {
        if (sliding == false) //if you are sliding you would destroy the ice block and keep moving
        {
            StopMoving(); //stop moving
        }

    }

    public void SaveY() //save Y at the end of scenes
    {
        PlayerPrefs.SetFloat("savedY", pos.y); //saves the savedY player pref
        savedY = PlayerPrefs.GetFloat("savedY");
    }

    public void ResetPlayer()
    {
        //resets all important values in the very first scene
        stamina = 0;
        SendMessage("UpdateStamina", stamina);
        PlayerPrefs.SetFloat("stamina", stamina);
        raceActive = 0;
        PlayerPrefs.SetInt("raceActive", 0);
        PlayerPrefs.SetFloat("savedY", 0.49f);

    }

    public void StartRace()
    {
        //when the race starts activate the raceActive variable
        //it was originally a bool but I needed to store it in a player pref
        //1 is race active, 0 is race not active
        raceActive = 1;
        PlayerPrefs.SetInt("raceActive", raceActive);
    }

    public void EndRace() //once the race ends
    {
        //resets all important values once the race is over
        PlayerPrefs.SetFloat("savedY", 0.49f);
        raceActive = 0;
        PlayerPrefs.SetInt("raceActive", 0);
        PlayerPrefs.SetFloat("stamina", 0);
    }

    public void MaxStamina()
    {
        //this is for when you pick up a fish
        //make stamina the max value (100)
        stamina = 100;
        SendMessage("UpdateStamina", stamina); //store this in the player pref
        PlayerPrefs.SetFloat("stamina", stamina);
    }

}
