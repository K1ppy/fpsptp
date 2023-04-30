using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public Sprite[] trees;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = trees[Random.Range(0, trees.Length)];
    }

}
