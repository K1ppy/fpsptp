using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : Object
{
    public Sprite[] trees;


    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = trees[Random.Range(0, trees.Length)];
    }

    public void Init(float x, float y)
    {
        _type = ObjectType.TREE;
        _position = new Vector3(x, y, 0);
    }
    
}
