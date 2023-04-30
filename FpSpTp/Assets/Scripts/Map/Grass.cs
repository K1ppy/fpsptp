using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
    public Sprite[] grass;
  
    private void Start()
    {

        if (Random.Range(0, 10) < 7) {
            GetComponent<SpriteRenderer>().sprite = grass[Random.Range(3, 6)];
        } else
        {
            GetComponent<SpriteRenderer>().sprite = grass[Random.Range(0, 3)];
        }

    }
}
