using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{

    public GameObject[] grass;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < grass.Length; i++) {
            grass[i].SetActive(false);
        }
        var element = grass[Random.Range(0, grass.Length)];
        element.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
