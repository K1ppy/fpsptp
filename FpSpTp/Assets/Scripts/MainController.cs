using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public int n = 1;
    public int m = 1;
    public GameObject grass;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Vector3 pos;
                pos.x = i - n / 2;
                pos.y = j - m / 2;
                pos.z = 0;
             
                
                Instantiate(grass, pos, Quaternion.identity, transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
