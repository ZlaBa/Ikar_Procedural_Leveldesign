using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    //Inserts
    public Rigidbody2D body;
    public SpriteRenderer SpriteRenderer;

    //Spriteliste
    //WALK
    public List<Sprite> Walk_S_Sprites;
    public List<Sprite> Walk_SW_Sprites;
    public List<Sprite> Walk_W_Sprites;
    public List<Sprite> Walk_NW_Sprites;
    public List<Sprite> Walk_N_Sprites;
    public List<Sprite> Walk_NE_Sprites;
    public List<Sprite> Walk_E_Sprites;
    public List<Sprite> Walk_SE_Sprites;

    //IDLE
    public List<Sprite> Idle_S_Sprites;
    public List<Sprite> Idle_SW_Sprites;
    public List<Sprite> Idle_W_Sprites;
    public List<Sprite> Idle_NW_Sprites;
    public List<Sprite> Idle_N_Sprites;
    public List<Sprite> Idle_NE_Sprites;
    public List<Sprite> Idle_E_Sprites;
    public List<Sprite> Idle_SE_Sprites;

    //Variablen
    public float walkSpeed;
    public int frameRate;

    float idleTime;
    //Spriteliste ENDE

    Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //get direction of input
        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

        //set walkbased direction
        body.velocity = direction * walkSpeed;

        List<Sprite> directionSprites = GetSpriteDirection();

        if (directionSprites != null) //holding a direction
        {
            float playTime = Time.time - idleTime; //time walking
            //Debug.Log(playTime);
            int totalFrames = (int)(playTime * frameRate); //total frames since start
            int frame = totalFrames % directionSprites.Count; //current frame

            SpriteRenderer.sprite = directionSprites[frame];
        }
        else // holding nothing, input is neutral
        {
            idleTime = Time.time;
            //Debug.Log("idle Time = " + Time.time);
        }
    }

    List<Sprite> GetSpriteDirection()
    {
        List<Sprite> selectedSprites = null;

        if (direction.y > 0) //north
        {
            if (direction.y > 0 && direction.x > 0) //north+east
            {
                selectedSprites = Walk_NE_Sprites;
                Debug.Log("Walking NE");
            }

            else if (direction.y > 0 && direction.x < 0) //north+west
            {
                selectedSprites = Walk_NW_Sprites;
                Debug.Log("Walking NW");
            }

            else
            {
            selectedSprites = Walk_N_Sprites;
            Debug.Log("Walking N");
            }
        }

        else if (direction.y < 0) //south
        {
            if (direction.y < 0 && direction.x > 0) //south+east
            {
                selectedSprites = Walk_SE_Sprites;
                Debug.Log("Walking SE");
            }

            else if (direction.y < 0 && direction.x < 0) //sotuh+west
            {
                selectedSprites = Walk_SW_Sprites;
                Debug.Log("Walking SW");
            }

            else
            {
                selectedSprites = Walk_S_Sprites;
                Debug.Log("Walking S");
            }
        }

        else if (direction.y == 0 && direction.x > 0) //east
        {
            selectedSprites = Walk_E_Sprites;
            Debug.Log("Walking E");
        }

        else if (direction.y == 0 && direction.x < 0) //west
        {
            selectedSprites = Walk_W_Sprites;
            Debug.Log("Walking W");
        }

        return selectedSprites;
    }
}

/* OLD SCRIPT

    
        /*if (direction.y > 0 && direction.x > 0) //north+east
        {
            selectedSprites = Walk_NE_Sprites;
            Debug.Log("Walking NE");
        }

        if (direction.y > 0 && direction.x < 0) //north+west
        {
            selectedSprites = Walk_NW_Sprites;
            Debug.Log("Walking NW");
        }*/

/*if (direction.y > 0) //north
{
if (direction.x > 0) //east
{
    selectedSprites = Walk_NE_Sprites;
}
else
{
    selectedSprites = Walk_N_Sprites;
}
}*/
/*else if (direction.y > 0) //north 
{
    if (direction.x < 0) //west
    {
        selectedSprites = Walk_NW_Sprites;
    }
    else
    {
        selectedSprites = Walk_N_Sprites;
    }
}
else if (direction.y < 0) //south 
{
    if (direction.x > 0) //east
    {
        selectedSprites = Walk_SE_Sprites;
    }
    else
    {
        selectedSprites = Walk_S_Sprites;
    }
}
else if (direction.y < 0) //south 
{
    if (direction.x < 0) //west
    {
        selectedSprites = Walk_SW_Sprites;
    }
    else
    {
        selectedSprites = Walk_S_Sprites;
    }
}
else if (direction.x < 0) //west
{
    selectedSprites = Walk_W_Sprites;
}
else if (direction.x > 0) //east
{
    selectedSprites = Walk_E_Sprites;
}*/


