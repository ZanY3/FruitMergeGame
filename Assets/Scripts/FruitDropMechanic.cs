using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FruitDropMechanic : MonoBehaviour
{
    [Header("Fruits")]
    public List<GameObject> fruitPrefabs;
    public List<GameObject> visualFruits;
    public bool isReadyToReplace = false; //merge fruit
    public int whichFruit = 0;
    public Vector2 spawnPos;
    public Transform visualWhichFruitPos;
    public float throwCooldown;
    private GameObject randomFruit;
    [Header("Sounds")]
    public AudioSource source;
    public AudioClip spawnSound;
    public List<AudioClip> fruitMergeSounds;
    [Header("Score")]
    public int scoreCount = 1;


    void Start()
    {
        randomFruit = fruitPrefabs[Random.Range(0, 5)];
        if (randomFruit.tag == "0")
        {
            visualFruits[0].gameObject.SetActive(true);
            visualFruits[1].gameObject.SetActive(false);
            visualFruits[2].gameObject.SetActive(false);
            visualFruits[3].gameObject.SetActive(false);
            visualFruits[4].gameObject.SetActive(false);
        }
        if (randomFruit.tag == "1")
        {
            visualFruits[0].gameObject.SetActive(false);
            visualFruits[1].gameObject.SetActive(true);
            visualFruits[2].gameObject.SetActive(false);
            visualFruits[3].gameObject.SetActive(false);
            visualFruits[4].gameObject.SetActive(false);
        }
        if (randomFruit.tag == "2")
        {
            visualFruits[0].gameObject.SetActive(false);
            visualFruits[1].gameObject.SetActive(false);
            visualFruits[2].gameObject.SetActive(true);
            visualFruits[3].gameObject.SetActive(false);
            visualFruits[4].gameObject.SetActive(false);
        }
        if (randomFruit.tag == "3")
        {
            visualFruits[0].gameObject.SetActive(false);
            visualFruits[1].gameObject.SetActive(false);
            visualFruits[2].gameObject.SetActive(false);
            visualFruits[3].gameObject.SetActive(true);
            visualFruits[4].gameObject.SetActive(false);
        }
        if (randomFruit.tag == "4")
        {
            visualFruits[0].gameObject.SetActive(false);
            visualFruits[1].gameObject.SetActive(false);
            visualFruits[2].gameObject.SetActive(false);
            visualFruits[3].gameObject.SetActive(false);
            visualFruits[4].gameObject.SetActive(true);
        }
    }
    void Update()
    {
        if (randomFruit.tag == "0")
        {
            visualFruits[0].gameObject.SetActive(true);
            visualFruits[1].gameObject.SetActive(false);
            visualFruits[2].gameObject.SetActive(false);
            visualFruits[3].gameObject.SetActive(false);
            visualFruits[4].gameObject.SetActive(false);
        }
        if (randomFruit.tag == "1")
        {
            visualFruits[0].gameObject.SetActive(false);
            visualFruits[1].gameObject.SetActive(true);
            visualFruits[2].gameObject.SetActive(false);
            visualFruits[3].gameObject.SetActive(false);
            visualFruits[4].gameObject.SetActive(false);
        }
        if (randomFruit.tag == "2")
        {
            visualFruits[0].gameObject.SetActive(false);
            visualFruits[1].gameObject.SetActive(false);
            visualFruits[2].gameObject.SetActive(true);
            visualFruits[3].gameObject.SetActive(false);
            visualFruits[4].gameObject.SetActive(false);
        }
        if (randomFruit.tag == "3")
        {
            visualFruits[0].gameObject.SetActive(false);
            visualFruits[1].gameObject.SetActive(false);
            visualFruits[2].gameObject.SetActive(false);
            visualFruits[3].gameObject.SetActive(true);
            visualFruits[4].gameObject.SetActive(false);
        }
        if (randomFruit.tag == "4")
        {
            visualFruits[0].gameObject.SetActive(false);
            visualFruits[1].gameObject.SetActive(false);
            visualFruits[2].gameObject.SetActive(false);
            visualFruits[3].gameObject.SetActive(false);
            visualFruits[4].gameObject.SetActive(true);
        }

        throwCooldown -= Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {

            if(throwCooldown <= 0)
            {
                throwCooldown = 0.3f;
                source.PlayOneShot(spawnSound);
                var worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                worldPos.z = 0;worldPos.y = 4f;
                Instantiate(randomFruit, worldPos, Quaternion.identity) ;
                
                randomFruit = fruitPrefabs[Random.Range(0, 5)];
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
