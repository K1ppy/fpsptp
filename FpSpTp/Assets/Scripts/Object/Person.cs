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
        _position = new Vector3(0, 0, 0);
        _affection = _start_affection;
    }



    public void Init(int x, int y, int z)
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

    // Update is called once per frame
    void Update()
    {
        LoseAffection();    
    }
}
