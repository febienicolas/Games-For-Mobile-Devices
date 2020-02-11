using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchControl : MonoBehaviour
{
   
    private float[] timeTouchBegan;
    private bool[] touchDidMove;
    private float tapTimeThreshold = .5f;
    Controlable currently_selected_item;

    Camera my_camera = new Camera();
    // Start is called before the first frame update
    void Start()
    {
        my_camera = Camera.main;
         timeTouchBegan = new float[10];
        touchDidMove = new bool[10];
    }

    // Update is called once per frame
    void Update()
    {
       
        

        foreach (Touch touch in Input.touches)
        {
            int fingerIndex = touch.fingerId;

            if (touch.phase == TouchPhase.Began)
            {
                Debug.Log("Finger #" + fingerIndex.ToString() + " entered!");
                timeTouchBegan[fingerIndex] = Time.time;
                touchDidMove[fingerIndex] = false;
            }

            if (touch.phase == TouchPhase.Moved)
            {
                Debug.Log("Finger #" + fingerIndex.ToString() + " moved!");
                touchDidMove[fingerIndex] = true;
            }
            if (touch.phase == TouchPhase.Ended)
            {
                float tapTime = Time.time - timeTouchBegan[fingerIndex];
                Debug.Log("Finger #" + fingerIndex.ToString() + " left. Tap time: " + tapTime.ToString());
                if (tapTime <= tapTimeThreshold && touchDidMove[fingerIndex] == false)
                {
                    // Select the object
                    Ray my_ray = my_camera.ScreenPointToRay(touch.position);
                    Debug.DrawRay(my_ray.origin, 20 * my_ray.direction);

                    RaycastHit info_on_hit;
                    if (Physics.Raycast(my_ray, out info_on_hit))
                    {
                        Controlable my_obj = info_on_hit.transform.GetComponent<Controlable>();
                        if(my_obj)
                        {
                            if (currently_selected_item)
                            {
                                currently_selected_item.deselect();
                            }
                            my_obj.select();
                            currently_selected_item = my_obj;

                        }

                    }
                    else
                    {
                        if (currently_selected_item)
                        {
                            currently_selected_item.deselect();
                            currently_selected_item = null;
                        }
                    }
                }
            }
        }


    }

}