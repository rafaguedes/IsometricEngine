using UnityEngine;
using System.Collections;

public class CameraOrto : MonoBehaviour
{

	void Start ()
    {
	
	}

	void Update ()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (GetComponent<Camera>().orthographicSize + 1 <= 7)
            {
                GetComponent<Camera>().orthographicSize += 1f;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if(GetComponent<Camera>().orthographicSize - 1 >= 2)
            {
                GetComponent<Camera>().orthographicSize -= 1f;
            }
        }
    }
}
