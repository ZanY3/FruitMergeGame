using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject mergeParticle;
    public Color particleColor;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == gameObject.tag)
        {
            FruitDropMechanic fruitDropMech = FindAnyObjectByType<FruitDropMechanic>();
            fruitDropMech.isReadyToReplace = true;
            fruitDropMech.spawnPos = transform.position;
            fruitDropMech.whichFruit = int.Parse(gameObject.tag);
            Destroy(gameObject);

            //fruit splat color = particle color
            var particles = Instantiate(mergeParticle);
            particles.transform.position = transform.position;
            particles.GetComponent<ParticleSystem>().startColor = particleColor;
            particles.transform.GetChild(0).GetComponent<ParticleSystem>().startColor = particleColor;
        }
    }

}
