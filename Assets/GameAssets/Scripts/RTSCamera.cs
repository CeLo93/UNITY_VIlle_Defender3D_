using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSCamera : MonoBehaviour
{
    public float borderSize = 25.0f;
    public float velocity = 10.0f;
    private float screenX;
    private float screenY;

    [SerializeField] private float minFov = 15f;
    [SerializeField] private float maxFov = 60f;
    [SerializeField] private float sensitivityM = 10f;

    private void Start()
    {
        screenX = Screen.width;
        screenY = Screen.height;

        //print(screenX);
        // print(screenY);
    }

    private void Update()
    {
        float fov = Camera.main.fieldOfView;
        fov -= Input.GetAxis("Mouse ScrollWheel") * sensitivityM;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        Camera.main.fieldOfView = fov;

        Vector3 pos = Vector3.zero;

        #region Move X

        //Move para a esquerda
        if (Input.mousePosition.x < borderSize)
        {
            pos.x = -1;
        }

        //Move para a direita
        if (Input.mousePosition.x > (screenX - borderSize))
        {
            pos.x = 1;
        }

        #endregion Move X

        #region Move Y

        //Move para cima
        if (Input.mousePosition.y < 25)
            pos.y = -1;

        //Move para baixo
        if (Input.mousePosition.y > (screenY - borderSize))
            pos.y = 1;

        #endregion Move Y

        if (pos == Vector3.zero)
            pos = GetKeyPosition();

        transform.Translate(pos * velocity * Time.deltaTime);
    }

    private Vector3 GetKeyPosition()
    {
        return new Vector3(
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical"),
            0
        );
    }
}