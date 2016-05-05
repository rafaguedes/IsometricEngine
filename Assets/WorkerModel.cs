using UnityEngine;
using System.Collections;

public class WorkerModel : MonoBehaviour
{
    public bool selected = false;
    Camera cameraInside;

    void Start()
    {
        cameraInside = GameObject.Find("CameraOrto").GetComponent<Camera>();
    }

    void Update ()
    {
        if (GetComponent<SkinnedMeshRenderer>().isVisible && Input.GetMouseButtonUp(0))
        {
            Vector3 camPos = cameraInside.WorldToScreenPoint(transform.position);
            camPos.y = Main.InvertMouseY(camPos.y);
            selected = Main.selection.Contains(camPos);
        }

        if (selected)
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.white;
        }
    }
}
