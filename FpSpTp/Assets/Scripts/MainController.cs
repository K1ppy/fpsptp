using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public int n = 1;
    public int m = 1;
    public GameObject Map;
    public GameObject Character;
    // Start is called before the first frame update
    void Start()
    {
        _character = Instantiate(Character, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        _character.GetComponent<Person>().Init(0, 0, 0);

        _map = Instantiate(Map, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        _map.GetComponent<Map>().Init(n, m);
    }

    
    private bool isRunning = false;

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.W))) {
            _character.GetComponent<Person>().Move(0.0f, 0.16f);
        }
        if ((Input.GetKeyDown(KeyCode.S)))
        {
            _character.GetComponent<Person>().Move(0.0f, -0.16f);
        }
        if ((Input.GetKeyDown(KeyCode.A)))
        {
            _character.GetComponent<Person>().Move(-0.16f, 0.0f);
        }
        if ((Input.GetKeyDown(KeyCode.D)))
        {
            _character.GetComponent<Person>().Move(0.16f, 0.0f);
        }
    }

    private GameObject _map;
    private GameObject _character;
}
