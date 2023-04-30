using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    private int _type;  // type of our object
    protected Vector3 _position; // position of our object {x, y, z}


    public void Init()
    {
        _type = 0;
        _position = new Vector3(0, 0, 0);
    }

    public int GetType()
    {
        return _type;
    }

    public Vector3 GetPosition()
    {
        return _position;
    }

    public void SetType(int newtype) => _type = newtype;
    public void SetPostion(Vector3 newposition) => _position = newposition;


    // Start is called before the first frame update
    void Start()
    {
        Init();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
