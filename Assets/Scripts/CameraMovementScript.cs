using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementScript : MonoBehaviour
{
    [SerializeField] private GameObject _object;
    [SerializeField] private Vector3 _distanse;

    private void LateUpdate()
    {
        Vector3 positionToGo = _object.transform.position + _distanse;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, positionToGo, 0.125F);

        transform.position = smoothPosition;
        transform.LookAt(_object.transform.position);
    }
}
