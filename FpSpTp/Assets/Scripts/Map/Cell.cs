using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CellType { Grass, Water}

public class Cell : MonoBehaviour
{

    public void Init(Vector3 pos, CellType type) {
        _pos = pos;
        _type = type;

        CreateCell();
    }

    private void CreateCell()
    {
        switch (_type)
        {
            case CellType.Grass:
                _cellObject = Instantiate(grass, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                _cellObject.transform.SetParent(transform, false);
                break;
            case CellType.Water:
                _cellObject = Instantiate(water, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                _cellObject.transform.SetParent(transform, false);
                break;
            default:
                break;

        }
    }

    public bool IsPassability()
    {
    
        if (_type == CellType.Water)
        {
            return false;
        }
        return true;
    }

    public GameObject grass;
    public GameObject water;

    private GameObject _cellObject;
    private CellType _type;
    private Vector3 _pos;

}
