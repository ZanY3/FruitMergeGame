using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FruitDropMechanic : MonoBehaviour
{
    [Header("Fruits")]
    public List<GameObject> fruitPrefabs;
    public bool isReadyToReplace = false; //merge fruit
    public int whichFruit = 0;
    public Vector2 spawnPos;
    public Transform visualWhichFruitPos;
    public float throwCooldown;
    [Header("Sounds")]
    public AudioSource source;
    public AudioClip spawnSound;
    public List<AudioClip> fruitMergeSounds;
    [Header("Score")]
    public int scoreCount = 1;

    void Update()
    {
        throwCooldown -= Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            var randomFruit = fruitPrefabs[Random.Range(0, 5)];

            if(throwCooldown <= 0)
            {
                throwCooldown = 0.3f;
                source.PlayOneShot(spawnSound);
                var worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                worldPos.z = 0;worldPos.y = 4f;
                Instantiate(randomFruit, worldPos, Quaternion.identity) ;

            }
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
            score.ScorePlus(scoreCount);
        }
    }
}
