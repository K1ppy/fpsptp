using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public int n = 1;
    public int m = 1;
    public GameObject Map;
    // Start is called before the first frame update
    void Start()
    {
        _map = Instantiate(Map, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        _map.GetComponent<Map>().Init(n, m);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private GameObject _map;
}
