using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlable : MonoBehaviour
{
    Renderer my_renderer;

    // Start is called before the first frame update
    void Start()
    {
        my_renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

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
}