using UnityEngine;

public class ObjFollowCam : MonoBehaviour
{
    [SerializeField] private Transform _objectT; //object that will follow the camera
    [SerializeField] private Transform _camT; //camera that will be followed

    private Vector3 _offset; //offset between object and camera - constant distance between them

    void Start()
    {
        _offset = _objectT.position;
    }

    void Update()
    {
        // Calculate the offset position based on the camera's rotation and the radius
        Vector3 offset = new Vector3(Mathf.Sin(_camT.eulerAngles.y * Mathf.Deg2Rad), _offset.y/_offset.z, Mathf.Cos(_camT.eulerAngles.y * Mathf.Deg2Rad)) * _offset.z;
        
        // Set the object's position relative to the camera's position plus the calculated offset and the old offset
        Vector3 newPosition = new Vector3(_camT.position.x + offset.x, _offset.y, _camT.position.z + offset.z);

        _objectT.position = newPosition;
    }
}
