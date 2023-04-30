using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Person : Object
{
    private int _affection; // if affection = 0, person is disappear
    private int _start_affection = 50;
    private int _lose_affection_per_time = 1;

    public void Init()
    {
        _type = ObjectType.PERSON;
        GetComponent<SpriteRenderer>().sprite = downArt;
        _position = new Vector3(0, 0, 0);
        _affection = _start_affection;
    }

    public void Move(float dx, float dy)
    {
        _position.x += dx;
        _position.y += dy;
        transform.position = _position;
        UpdateArt(dx, dy);
    }

    private void UpdateArt(float dx, float dy)
    {
        if (dx > 0) {
            GetComponent<SpriteRenderer>().sprite = rightArt;
        }
        if (dx < 0)
        {
            GetComponent<SpriteRenderer>().sprite = leftArt;
        }
        if (dy > 0) {
            GetComponent<SpriteRenderer>().sprite = upArt;
        }
        if (dy < 0)
        {
            GetComponent<SpriteRenderer>().sprite = downArt;
        }
     
    }

    public void Init(float x, float y, float z)
    {
        _position = new Vector3(x, y, z);
        _affection = _start_affection;
    }

    public int GetAffection()
    {
        return _affection;
    }

    public void SetAffection(int newaffection) => _affection = newaffection;
    
    public void LosePerson()
    {
        // person disappear
    }

    public void LoseAffection()
    {
        _affection -= _lose_affection_per_time;
        if (_affection <= 0) LosePerson();
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

 
    public Sprite leftArt;
    public Sprite rightArt;
    public Sprite upArt;
    public Sprite downArt;

}
