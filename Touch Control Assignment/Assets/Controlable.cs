using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlable : MonoBehaviour
{
    Renderer my_renderer;
    private Vector3 desired_destination;

    // Start is called before the first frame update
    void Start()
    {
        desired_destination = transform.position;
        my_renderer = GetComponent<Renderer>();
        transform.sc
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.Lerp(transform.position, desired_destination, 0.1f);

    }

    internal void move_up()
    {
        transform.position += Vector3.up;

    }

    internal void go_red()
    {
        my_renderer.material.color = Color.red;
    }

    internal void go_blue()
    {
        my_renderer.material.color = Color.blue;
    }

    internal void go_yellow()
    {
        my_renderer.material.color = Color.yellow;
    }
    internal void go_white()
    {
        my_renderer.material.color = Color.white;
    }

    internal void select()
    {
        go_red();
    }

    internal void deselect()
    {
        go_white();
    }

    internal void update_drag_position(Vector3 drag_destination)
    {
        print(drag_destination);
        desired_destination = drag_destination;
    }
}