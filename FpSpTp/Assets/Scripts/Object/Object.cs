using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType { EMPTY, PERSON, TREE, STONE}

public class Object : MonoBehaviour
{
    public ObjectType _type;  // type of our object
    protected Vector3 _position; // position of our object {x, y, z}


    public void Init()
    {
        //_type = ObjectType.EMPTY;
        _position = new Vector3(0, 0, 0);
    }

    public ObjectType GetObjectType()
    {
        return _type;
    }

    public Vector3 GetPosition()
    {
        return _position;
    }

    //public void SetType(ObjectType newtype) => _type = newtype;
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
