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

    public void Init(float x, float y)
    {
        _type = ObjectType.STONE;
        _position = new Vector3(x, y, 0);
    }
}
