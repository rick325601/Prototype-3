using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    // all the linked items with variables 
    private float speed = 20;
    private PlayerController playerControllerscript;
    private float leftBound = -15;
    
    // Start is called before the first frame update
    void Start()
    {
        // detects when te player hits a object
        playerControllerscript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // speed and movement of objects
        if (playerControllerscript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        // destroys a item when it reaches leftBound
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
