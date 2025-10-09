using UnityEngine;

public class Camera : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Vector2 motion;
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Turn mouse movement into camera rotation
        motion.x += Input.GetAxis("Mouse X");
        motion.y += Input.GetAxis("Mouse Y");
        transform.localRotation = Quaternion.Euler(-motion.y, motion.x, 0);
    }
    
}
