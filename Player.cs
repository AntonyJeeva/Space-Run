using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool FirstLaneBlueShip, FirstLaneGreenShip;

    public bool BlueShip;


    public Vector2 Xpos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("left"))
        {
            LeftButtonPressed();

        }
        if (Input.GetKeyDown("right"))
        {
            RightButtonPressed();

        }

        if (BlueShip)
        {
            if (FirstLaneBlueShip)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(-Xpos.y, transform.position.y, 0), .1f);

            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(-Xpos.x, transform.position.y, 0), .1f);
            }
        }
        else
        {
            if (FirstLaneGreenShip)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(Xpos.y, transform.position.y, 0), .1f);
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(Xpos.x, transform.position.y, 0), .1f);
            }
        }

    }

    public void LeftButtonPressed()
    {
        if (FirstLaneBlueShip)
        {
            FirstLaneBlueShip = false;
        }
        else
        {
            FirstLaneBlueShip = true;
        }

    }
    public void RightButtonPressed()
    {
        if (FirstLaneGreenShip)
        {
            FirstLaneGreenShip = false;
        }
        else
        {
            FirstLaneGreenShip = true;
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            //gameover
            FindObjectOfType<GameController>().GameOver();
            Debug.Log("PlayerGO");

        }
    }
}
