using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D rb2d;
    //Movement
    float moveSpeed = 5;
    

    //Checker
    


    void Start()
    {
        rb2d= GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
      
    }
    private void FixedUpdate()
    {
        rb2d.velocity= new Vector2(moveSpeed, rb2d.velocity.y);
    }
}
