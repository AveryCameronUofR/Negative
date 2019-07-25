using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MouseInput : MonoBehaviour
{

    Vector2 mouseLook;
    Vector2 smoothV;
    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;
    
    public Quaternion origin;

    public void Start()
    {
        origin = transform.rotation;
    }

    private void Update()
    {
        var mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        mouseInput = Vector2.Scale(mouseInput, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, mouseInput.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, mouseInput.y, 1f / smoothing);
        mouseLook += smoothV;

        var xQuaternion = Quaternion.AngleAxis(mouseLook.x, Vector3.up);
        var yQuaternion = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);

        transform.localRotation = origin * xQuaternion * yQuaternion;
        
        /*
        temp = Input.GetAxisRaw("Mouse X");
        var yRotate = transform.localRotation.y;
        
        if (Mathf.Abs(Input.GetAxisRaw("Mouse X")) > sensitivity)
        {
            var mouseRotation = new Quaternion(0.0f, yRotate + Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed, 0.0f, 1f);
            
            if (mouseRotation.y > 0 || true)
            {
                transform.localRotation = mouseRotation;
                
            }
            
        } /*else if (Input.GetAxisRaw("Mouse X") < -1*sensitivity )
        {
            var mouseRotation = new Quaternion(0.0f, yRotate + Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed, 0.0f, 1f);
            if (mouseRotation.y < 0)
            {
                transform.localRotation = mouseRotation;
            }
        }*/



    }
}
