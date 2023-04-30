using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public void Init(int n, int m)
    {
        _map = new GameObject[n, m];

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Vector3 pos = new Vector3((i  - n / 2) * 0.16f, (j - m/ 2) * 0.16f, 0);
                _map[i, j] = Instantiate(cell, pos, Quaternion.identity, transform) as GameObject;
                _map[i, j].transform.SetParent(transform, false);
                CellType type = (i % 2 != 0 ? CellType.Grass : CellType.Water);
                _map[i, j].GetComponent<Cell>().Init(pos, type);
            }
        }
    }
    public GameObject cell;
    private GameObject[,] _map;
}
