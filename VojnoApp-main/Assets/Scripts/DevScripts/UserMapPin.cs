using Mapbox.Map;
using Mapbox.Unity.Location;
using Mapbox.Unity.Map;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Utils;
using System;

public class UserMapPin : MonoBehaviour
{
    [SerializeField] private Transform _objectT; //object that will follow the camera
    [SerializeField] private Transform _camT; //camera that will be followed
    [SerializeField] private AbstractMap map;
    [SerializeField] private ReceiveGPSData receiveGPSData;

    private Vector3 _offset; //offset between object and camera - constant distance between them

    private void Start()
    {
        _offset = _objectT.parent.position;
        receiveGPSData.OnGPSDataReceived += OnGPSDataReceived;        
        //receiveGPSData.OnDirectionsReceived += OnDirectionsReceived;        
    }

    private void OnDestroy()
    {
        receiveGPSData.OnGPSDataReceived -= OnGPSDataReceived;
        //receiveGPSData.OnDirectionsReceived -= OnDirectionsReceived;
    }

    private void Update()
    {
        transform.rotation = Quaternion.Euler(0, _camT.eulerAngles.y, 0);
    }

    private void OnGPSDataReceived(float latitude, float longitude)
    {
        Vector3 newPos = map.GeoToWorldPosition(new Vector2d(latitude, longitude));
        //transform.localPosition = new Vector3(newPos.x, -1, newPos.z);
        transform.position = new Vector3(newPos.x, 99, newPos.z);
    }
    private void OnDirectionsReceived(float dir)
    {
        transform.rotation = Quaternion.Euler(0, dir, 0);
    }
}