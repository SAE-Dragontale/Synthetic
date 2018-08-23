using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    private float _rotationSpd = 90.0f;

    public bool _playerControl = false;

    [SerializeField] private GameObject _camera;

    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
	
    // Update is called once per frame
    void Update()
    {
        
        if (_player != null)
        {
            transform.localScale = _player.transform.lossyScale;
            transform.position = _player.transform.position + new Vector3(0, 0.3f, 0);

        }

        if (_playerControl)
        {
            PlayerControl();
        }
    }

    void LateUpdate()
    {
        //_camera.transform.LookAt(_player.transform);
    }

    private void PlayerControl()
    {
        float pitch = CalculatePitch(Input.GetAxisRaw("Mouse Y"));
        float yaw = transform.rotation.eulerAngles.y - (Input.GetAxisRaw("Mouse X") * _rotationSpd * Time.deltaTime);

        transform.localRotation = Quaternion.Euler(pitch, yaw, 0.0f);
    }

    private float CalculatePitch(float controlPitch)
    {
        float pitch = transform.rotation.eulerAngles.x;

        pitch = (pitch > 180) ? pitch - 360 : pitch;


        if (controlPitch != 0.0f)
        {
            pitch += (controlPitch * 45.0f * Time.deltaTime);
            pitch = Mathf.Clamp(pitch, -20.0f, 20.0f);
        }
        //        else
        //        {
        //            pitch = Mathf.Lerp(pitch, 0.0f, 0.05f);
        //        }

        return pitch;
    }
}
