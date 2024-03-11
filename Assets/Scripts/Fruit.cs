using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == gameObject.tag)
        {
            FruitDropMechanic fruitDropMech = FindAnyObjectByType<FruitDropMechanic>();
            fruitDropMech.isReadyToReplace = true;
            fruitDropMech.spawnPos = transform.position;
            fruitDropMech.whichFruit = int.Parse(gameObject.tag);
            Destroy(gameObject);
        }
    }

}
