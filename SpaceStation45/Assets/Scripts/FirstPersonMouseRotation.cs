using UnityEngine;
using System.Collections;

public class FirstPersonMouseRotation : MonoBehaviour
{
    [SerializeField]
    private float lookSensitivity;
    [SerializeField]
    private float cameraSmoothing;

    private Vector2 smoothV;
    private Vector2 mouseLook;
    private GameObject player;

    void Start()
    {
        //the player gameobject (waarschijnlijk je capsule)
        player = this.transform.parent.gameObject;
    }

    void Update()
    {
        //call mouserotation every frame
        MouseRotation();
    }

    /// <summary>
    /// first person camera rotation via the mouse
    /// </summary>
    void MouseRotation()
    {
        Vector2 md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(lookSensitivity * cameraSmoothing, lookSensitivity * cameraSmoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / cameraSmoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / cameraSmoothing);
        mouseLook += smoothV;
        //mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, player.transform.up);

    }
}
