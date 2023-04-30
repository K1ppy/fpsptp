using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float cameraMoveSpeed;
    private GameObject _character;

    public void SetCharacter(GameObject character)
    {
        _character = character;
    }

    void Update()
    {
        if (_character.transform)
        {
            Vector3 target = new Vector3()
            {
                x = _character.transform.position.x,
                y = _character.transform.position.y,
                z = _character.transform.position.z - 10,
            };

            Vector3 pos = Vector3.Lerp(transform.position, target, cameraMoveSpeed * Time.deltaTime);

            transform.position = pos;
        }
    }
}
