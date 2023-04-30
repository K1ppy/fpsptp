using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Map : MonoBehaviour
{
    public void Init(int n, int m)
    {
        _n = n;
        _m = m;
        _map = new GameObject[n, m];
        _objects = new GameObject[n, m];
        Random rand = new Random();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Vector3 pos = new Vector3((i) * 0.16f, (j) * 0.16f, 0);
                _map[i, j] = Instantiate(cell, pos, Quaternion.identity, transform) as GameObject;
                _map[i, j].transform.SetParent(transform, false);
                _map[i, j].GetComponent<Cell>().Init(pos, CellType.Grass);


                pos = new Vector3((i) * 0.16f, (j) * 0.16f, 0);
                _objects[i, j] = Instantiate(empty, pos, Quaternion.identity, transform) as GameObject;
                _objects[i, j].transform.SetParent(transform, false);
            }
        }
        for (int i = 0; i < kol_lakes; i++)
        {
            int new_i = rand.Next(0, _n);
            int new_j = rand.Next(0, _m);
            int size_lake = rand.Next(20, 30);
            for (int j = 0; j < size_lake; j++)
            {
                int random_do = rand.Next(0, 20);
                if (random_do <= 5)
                {
                    if (new_i < _n - 1)
                    {
                        new_i += 1;
                    }
                }
                if (random_do <= 10 && random_do > 5)
                {
                    if (new_i > 0)
                    {
                        new_i -= 1;
                    }
                }
                if (random_do <= 15 && random_do > 10)
                {
                    if (new_j > 0)
                    {
                        new_j -= 1;
                    }
                }
                if (random_do <= 20 && random_do > 15)
                {
                    if (new_j < _m - 1)
                    {
                        new_j += 1;
                    }
                }
                Vector3 pos = new Vector3((new_i) * 0.16f, (new_j) * 0.16f, 0);
                Destroy(_map[new_i, new_j]);
                _map[new_i, new_j] = Instantiate(cell, pos, Quaternion.identity, transform) as GameObject;
                _map[new_i, new_j].transform.SetParent(transform, false);
                _map[new_i, new_j].GetComponent<Cell>().Init(pos, CellType.Water);
            }
        }
        for (int i = 0; i < kol_stones; i++)
        {
            int size_of_stone = rand.Next(1, 5);
            int new_i = rand.Next(10, n);
            int new_j = rand.Next(10, m);
            for (int j = 0; j < size_of_stone; j++)
            {
                
                int random_do = rand.Next(0, 20);
                if (random_do <= 5)
                {
                    if (new_i < _n - 1)
                    {
                        new_i += 1;

                    }
                }
                if (random_do <= 10 && random_do > 5)
                {
                    if (new_i > 0)
                    {
                        new_i -= 1;

                    }
                }
                if (random_do <= 15 && random_do > 10)
                {
                    if (new_j > 0)
                    {
                        new_j -= 1;
                    }
                }
                if (random_do <= 20 && random_do > 15)
                {
                    if (new_j < _m - 1)
                    new_j += 1;
                }
                if (_map[new_i, new_j].GetComponent<Cell>().IsPassability())
                {
                    Destroy(_objects[new_i, new_j]);
                    Vector3 pos = new Vector3((new_i) * 0.16f, (new_j) * 0.16f, 0);
                    _objects[new_i, new_j] = Instantiate(stone, pos, Quaternion.identity, transform) as GameObject;
                    _objects[new_i, new_j].transform.SetParent(transform, false);
                }
            }
        }

        for (int i = 0;i < kol_trees; i++)
        {
            int size_of_tree = rand.Next(1, 30);
            int new_i = rand.Next(0, n);
            int new_j = rand.Next(0, m);
            for (int j = 0;j < size_of_tree; j++)
            {
                
                int random_do = rand.Next(0, 20);
                if (random_do <= 5)
                {
                    if (new_i < _n - 1)
                    {
                        new_i += 1;

                    }
                }
                if (random_do <= 10 && random_do > 5)
                {
                    if (new_i > 0)
                    {
                        new_i -= 1;

                    }
                }
                if (random_do <= 15 && random_do > 10)
                {
                    if (new_j > 0)
                    {
                        new_j -= 1;

                    }
                }
                if (random_do <= 20 && random_do > 15)
                {
                    if (new_j < _m - 1)
                    {
                        new_j += 1;
                    }
                }
                if (_map[new_i, new_j].GetComponent<Cell>().IsPassability())
                {
                    Destroy(_objects[new_i, new_j]);
                    Vector3 pos = new Vector3((new_i) * 0.16f, (new_j) * 0.16f, 0);
                    _objects[new_i, new_j] = Instantiate(tree, pos, Quaternion.identity, transform) as GameObject;
                    _objects[new_i, new_j].transform.SetParent(transform, false);
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
    public GameObject stone;

    private GameObject[,] _map;
    private GameObject[,] _objects;

    public int kol_lakes = 16;
    public int kol_trees = 150;
    public int kol_stones = 75;

    private int _n;
    private int _m;
}
