using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public Sprite[] stones;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = stones[Random.Range(0, stones.Length)];
    }

}
