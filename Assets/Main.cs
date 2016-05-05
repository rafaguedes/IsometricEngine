using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour
{
    public Camera cameraInside = null;

    private Light myLight;
    public float speed = 1;

    bool walking;
    RaycastHit hit;
    Ray ray;

    public GameObject worker;

    Vector3 spawPointWorker;

    private Vector2 _box_start_pos;
    private Vector2 _box_end_pos;

    //Selecionar workers
    public Texture2D selectionHighlight = null;
    public static Rect selection = new Rect(0, 0, 0, 0);
    private Vector3 startClick = -Vector3.one;

    int numberSpaws = 0;

    void Start ()
    {
        cameraInside = GameObject.Find("CameraOrto").GetComponent<Camera>();

        spawPointWorker = new Vector3(13.86f, -1.632f, -5.53f);
    }
	
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = cameraInside.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit, 200.0f);
        }

        CheckCamera();

    }

    private void CheckCamera()
    {
        if(Input.GetMouseButtonDown(0))
        {
            startClick = Input.mousePosition;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            if(selection.width < 0)
            {
                selection.x += selection.width;
                selection.width = -selection.width;
            }
            
            if(selection.height < 0)
            {
                selection.y += selection.height;
                selection.height = -selection.height;
            }

            startClick = -Vector3.one;
        }

        if(Input.GetMouseButton(0))
        {
            selection = new Rect(startClick.x, InvertMouseY(startClick.y), Input.mousePosition.x - startClick.x, InvertMouseY(Input.mousePosition.y) - InvertMouseY(startClick.y));
        }
    }

    public static float InvertMouseY(float y)
    {
        return Screen.height - y;
    }

    void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 150, 90), "Opções de Jogo");

        if (GUI.Button(new Rect(20, 40, 130, 20), "Novo Operário"))
        {
            float radius = 1f;

            Collider[] hitColliders = Physics.OverlapSphere(spawPointWorker, radius);

            bool isSpawnFree = true;
            for (int i = 0; i < hitColliders.Length; i++)
            {
                if (hitColliders[i].name != "Terrain")
                {
                    isSpawnFree = false;
                    Debug.Log(hitColliders[i].name);
                }
            }

            Debug.Log(isSpawnFree);
            GameObject worker = (GameObject) Instantiate(Resources.Load("Worker"));

            if (isSpawnFree)
            {
                numberSpaws = 0;
                spawPointWorker = new Vector3(13.86f, -1.632f, -5.53f);
                worker.transform.position = spawPointWorker;
            }
            else
            {
                numberSpaws++;
                spawPointWorker = new Vector3(13.86f + numberSpaws, -1.632f, -5.53f);
                worker.transform.position = spawPointWorker; 
            }
            
        }

        if(startClick != -Vector3.one)
        {
            GUI.color = new Color(1, 1, 1, 0.5f);
            GUI.DrawTexture(selection, selectionHighlight);
        }
    }
}


//Backup
/*GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
Renderer rend = cube.GetComponent<Renderer>();
rend.material.mainTexture = Resources.Load("9452") as Texture;

cube.transform.position = hit.point;
cube.transform.Translate(0, 0.45f, 0);

if (hit.transform.name == "Terrain")
{
                
}

 */
