using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public void Init(int n, int m)
    {
        _n = n;
        _m = m;
        _map = new GameObject[n, m];
        _objects = new GameObject[n, m];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Vector3 pos = new Vector3((i) * 0.16f, (j) * 0.16f, 0);
                _map[i, j] = Instantiate(cell, pos, Quaternion.identity, transform) as GameObject;
                _map[i, j].transform.SetParent(transform, false);
                _map[i, j].GetComponent<Cell>().Init(pos, CellType.Grass);

                

                
                 if ((i + j) % 10 == 0 && i % 2 == 0 && i % 4 != 0) {
                    _objects[i, j] = Instantiate(tree, pos, Quaternion.identity, transform) as GameObject;
                    _objects[i, j].transform.SetParent(transform, false);
                } else
                {
                    _objects[i, j] = Instantiate(empty, pos, Quaternion.identity, transform) as GameObject;
                    _objects[i, j].transform.SetParent(transform, false);
                }
                
            }
        }
    }

    public bool IsPassability(int x, int y)
    {
        Debug.Log(x + " " + y);
        if (_objects[x, y].GetComponent<Object>().GetObjectType() != ObjectType.EMPTY) return false;
        return _map[x, y].GetComponent<Cell>().IsPassability();
    }


    public GameObject GetObject(int x, int y) {
        return _objects[x, y];
    }

    public void Destroy(int x, int y)
    {
        Destroy(_objects[x, y]);
        _objects[x, y] = Instantiate(empty, new Vector3(x, y, 0), Quaternion.identity, transform) as GameObject;
        _objects[x, y].transform.SetParent(transform, false);
    }

    public GameObject cell;

    public GameObject tree;
    public GameObject empty;

    private GameObject[,] _map;
    private GameObject[,] _objects;
    private int _n;
    private int _m;
}
