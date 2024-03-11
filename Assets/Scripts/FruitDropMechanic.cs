using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitDropMechanic : MonoBehaviour
{
    public List<GameObject> fruitPrefabs;
    public AudioSource source;
    public AudioClip spawnSound;
    [SerializeField]public bool isReadyToReplace = false; //merge fruit
    [SerializeField] public int whichFruit = 0;
    [SerializeField] public Vector2 spawnPos;
    public Transform visualWhichFruitPos;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            var randomFruit = fruitPrefabs[Random.Range(0, fruitPrefabs.Count)];
            source.PlayOneShot(spawnSound);
            var worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPos.z = 0;worldPos.y = 4.5f;
            Instantiate(randomFruit, worldPos, Quaternion.identity) ;
        }
        replaceFruit();
    }
    void replaceFruit()
    {
        if(isReadyToReplace)
        {
            isReadyToReplace = false;
            Instantiate(fruitPrefabs[whichFruit + 1], spawnPos, fruitPrefabs[0].transform.rotation);
        }
    }
}
