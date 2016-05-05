using UnityEngine;
using System.Collections;
using System;

public class CameraTarget : MonoBehaviour
{
    int speed;
    int startSpeed = 10;

    public int boundary = 3;

    void Start ()
    {

    }

	void Update ()
    {
        speed = startSpeed;

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            speed = ++speed;
            transform.Translate(-(speed * -1 * Time.deltaTime), 0, (speed * -1 * Time.deltaTime));
        }

        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            speed = ++speed;
            transform.Translate((speed * -1 * Time.deltaTime), 0, -(speed * -1 * Time.deltaTime));
        }

        if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            speed = ++speed;
            transform.Translate((2 * speed * -1 * Time.deltaTime), 0, 2 * speed * -1 * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            speed = ++speed;
            transform.Translate(-(2 * speed * -1 * Time.deltaTime), 0, - (2 * speed * -1 * Time.deltaTime));
        }

        /*Vector2 mouseEdge = MouseScreenEdge(20);

        if (!(Mathf.Approximately(mouseEdge.x, 0f)))
        {
            if (mouseEdge.x < 0)
            {
                speed = ++speed;
                transform.Translate((speed * -1 * Time.deltaTime), 0, -(speed * -1 * Time.deltaTime));
            }
            else
            {
                speed = ++speed;
                transform.Translate(-(speed * -1 * Time.deltaTime), 0, (speed * -1 * Time.deltaTime));
            }
        }

        if (!(Mathf.Approximately(mouseEdge.y, 0f)))
        {
            if (mouseEdge.y > 0)
            {
                speed = ++speed;
                transform.Translate(-(2 * speed * -1 * Time.deltaTime), 0, -(2 * speed * -1 * Time.deltaTime));
            }
            else
            {
                speed = ++speed;
                transform.Translate((2 * speed * -1 * Time.deltaTime), 0, 2 * speed * -1 * Time.deltaTime);
            }
        }*/
    }

    Vector2 MouseScreenEdge(int margin)
    {
        Vector2 half = new Vector2(Screen.width / 2, Screen.height / 2);

        float x = Input.mousePosition.x - half.x;
        float y = Input.mousePosition.y - half.y;

        if (Mathf.Abs(x) > half.x - margin)
        {
            if (x > 0)
            {
                x += (half.x - margin) * 1;
            }
            else
            {
                x += (half.x - margin) * -1;
            }
        }
        else
        {
            x = 0f;
        }

        if (Mathf.Abs(y) > half.y - margin)
        {
            if (y < 0)
            {
                y += (half.y - margin) *  1;
            }
            else
            {
                y += (half.y - margin) * -1;
            }
        }
        else
        {
            y = 0f;
        }

        return new Vector2(x, y);
    }
}
