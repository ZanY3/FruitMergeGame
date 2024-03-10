using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitDropMechanic : MonoBehaviour
{
    public List<GameObject> fruitPrefabs;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            var randomFruit = fruitPrefabs[Random.Range(0, fruitPrefabs.Count)];
            var worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPos.z = 0;worldPos.y = 4.5f;
            Instantiate(randomFruit, worldPos, Quaternion.identity) ;
        }
    }
}
