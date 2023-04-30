using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public GameObject camera;

    public int n = 1;
    public int m = 1;
    public GameObject Map;
    public GameObject Character;
    // Start is called before the first frame update
    void Start()
    {
        _character = new GameObject[10];
        mainCharacter = 0;
        for (int i = 0; i < 3; i++)
        {
            _character[i] = Instantiate(Character, new Vector3((50 + i * 2) * 0.16f, (50 - i * 3) * 0.16f, 0), Quaternion.identity) as GameObject;
            _character[i].GetComponent<Person>().Init(50 + i * 2, 50 - i * 3, 0);
        }


        _map = Instantiate(Map, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        _map.GetComponent<Map>().Init(n, m);

        camera.GetComponent<CameraController>().SetCharacter(_character[mainCharacter]);
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.W))) {
            MoveCharacter(_character[mainCharacter], 0, 1);
        }
        if ((Input.GetKeyDown(KeyCode.S)))
        {
            MoveCharacter(_character[mainCharacter], 0, -1);
        }
        if ((Input.GetKeyDown(KeyCode.A)))
        {
            MoveCharacter(_character[mainCharacter], -1, 0);
        }
        if ((Input.GetKeyDown(KeyCode.D)))
        {
            MoveCharacter(_character[mainCharacter], 1, 0);
        }
        if ((Input.GetKeyDown(KeyCode.E)))
        {
            InteractionCharacter(_character[mainCharacter]);
        }

        if ((Input.GetKeyDown(KeyCode.Alpha1)))
        {
            mainCharacter = 0;
            camera.GetComponent<CameraController>().SetCharacter(_character[mainCharacter]);
        }
        if ((Input.GetKeyDown(KeyCode.Alpha2)))
        {
            mainCharacter = 1;
            camera.GetComponent<CameraController>().SetCharacter(_character[mainCharacter]);
        }
        if ((Input.GetKeyDown(KeyCode.Alpha3)))
        {
            mainCharacter = 2;
            camera.GetComponent<CameraController>().SetCharacter(_character[mainCharacter]);
        }
    }

    private void InteractionCharacter(GameObject character)
    {
        Vector3 direction = character.GetComponent<Person>().GetDirection();
        Vector3 newPos = character.GetComponent<Person>().GetPosition();
        newPos += direction;
        

        GameObject mapObject = _map.GetComponent<Map>().GetObject((int)newPos.x, (int)newPos.y);

        if(mapObject.GetComponent<Object>().GetObjectType() == ObjectType.TREE)
        {
            _map.GetComponent<Map>().Destroy((int)newPos.x, (int)newPos.y);
        }
    }

    private void MoveCharacter(GameObject character, int dx, int dy)
    {
        Vector3 newPos = character.GetComponent<Person>().GetPosition();
        newPos.x += dx;
        newPos.y += dy;

        bool fMove = _map.GetComponent<Map>().IsPassability((int)newPos.x, (int)newPos.y);
        character.GetComponent<Person>().Move(dx, dy, fMove);
        
    }


    int mainCharacter;
    private GameObject _map;
    private GameObject[] _character;
}
