using UnityEngine;
using System.Collections;

public class MovimentoPlayer : MonoBehaviour
{
    public Transform goal;
    NavMeshAgent agent;
    Camera cameraInside;

    WorkerModel worker;
    RaycastHit hit;

    public Animator anim;

    public bool walking = false;

    void Start ()
    {
        cameraInside = GameObject.Find("CameraOrto").GetComponent<Camera>();
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }
	
    void FixedUpdate()
    {
        anim.SetBool("walking", walking);
    }

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cameraInside.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit, 200.0f);

            bool selected = GetComponentInChildren<WorkerModel>().selected;
            if (hit.transform.name == "Terrain" && selected)
            {
                agent.destination = hit.point;
                walking = true;
                agent.updatePosition = true;
            }
        }

        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 1f)
                {
                    walking = false;
                    agent.updatePosition = false;
                }


            }
        }
    }
}
