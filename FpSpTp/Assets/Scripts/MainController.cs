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
        _character = Instantiate(Character, new Vector3(50 * 0.16f, 50 * 0.16f, 0), Quaternion.identity) as GameObject;
        _character.GetComponent<Person>().Init(n / 2, m / 2, 0);

        _map = Instantiate(Map, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        _map.GetComponent<Map>().Init(n, m);
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.W))) {
            MoveCharacter(_character, 0, 1);
        }
        if ((Input.GetKeyDown(KeyCode.S)))
        {
            MoveCharacter(_character, 0, -1);
        }
        if ((Input.GetKeyDown(KeyCode.A)))
        {
            MoveCharacter(_character, -1, 0);
        }
        if ((Input.GetKeyDown(KeyCode.D)))
        {
            MoveCharacter(_character, 1, 0);
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

    private GameObject _map;
    private GameObject _character;
}
