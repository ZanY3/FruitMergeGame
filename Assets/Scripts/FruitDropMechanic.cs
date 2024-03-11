using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitDropMechanic : MonoBehaviour
{
    [Header("Fruits")]
    public List<GameObject> fruitPrefabs;
    public bool isReadyToReplace = false; //merge fruit
    public int whichFruit = 0;
    public Vector2 spawnPos;
    public Transform visualWhichFruitPos;
    [Header("Sounds")]
    public AudioSource source;
    public AudioClip spawnSound;
    public List<AudioClip> fruitMergeSounds;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            var randomFruit = fruitPrefabs[Random.Range(0, 3)];
            source.PlayOneShot(spawnSound);
            var worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPos.z = 0;worldPos.y = 4f;
            Instantiate(randomFruit, worldPos, Quaternion.identity) ;
        }
        replaceFruit();
    }
    void replaceFruit()
    {
        if(isReadyToReplace)
        {
            Score score = FindAnyObjectByType<Score>();
            isReadyToReplace = false;
            source.PlayOneShot(fruitMergeSounds[Random.Range(0, fruitMergeSounds.Count)]);
            Instantiate(fruitPrefabs[whichFruit + 1], spawnPos, fruitPrefabs[0].transform.rotation);
            score.ScorePlus();
        }
    }
}
