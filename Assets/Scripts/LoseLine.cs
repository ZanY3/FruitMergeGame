using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseLine : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("lose");
    }
}
