using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMouvement : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float mouseSensitivity = 500f;

    float xRotation = 0f;
    float yRotation = 0f;

    [SerializeField] private float topClamp = -90f;
    [SerializeField] private float bottomClamp = 90f;
    void Awake()
    {
        
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation-=mouseY;
        xRotation = Mathf.Clamp(xRotation, topClamp, bottomClamp); 

        yRotation+=mouseX;

        transform.localRotation = Quaternion.Euler(xRotation, yRotation,0f);

    }
}
