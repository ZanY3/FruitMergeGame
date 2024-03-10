using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject newFruitAftrTouch;
    private void Start()
    {
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(gameObject.tag))
        {
           
        }
    }

}
