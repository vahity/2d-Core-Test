using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touch : MonoBehaviour
{
    public float scale1 = 1f;
    public float scale2 = 1f;
    public float scale3 = 0.6f;



    public static touch instance;
    private Rigidbody2D rb;

    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position
    private float dragDistance;  //minimum distance for a swipe to be registered

    public bool IsChange;

    public GameObject Player;

    public float yAxisLine;

    void Start()
    {
        instance = this;
        dragDistance = Screen.height * 15 / 100; //dragDistance is 15% height of the screen
    }

    void Update()
    {
        if (Input.touchCount == 1) // user is touching the screen with a single touch
        {
            Touch touch = Input.GetTouch(0); // get the touch
            if (touch.phase == TouchPhase.Began) //check for the first touch
            {
                fp = touch.position;
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
            {
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
            {
                lp = touch.position;  //last touch position. Ommitted if you use list

                //Check if drag distance is greater than 20% of the screen height
                if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
                {//It's a drag
                 //check if the drag is vertical or horizontal
                    if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
                    {   //If the horizontal movement is greater than the vertical movement...
                        if ((lp.x > fp.x))  //If the movement was to the right)
                        {   //Right swipe
                            Debug.Log("Right Swipe");
                        }
                        else
                        {   //Left swipe
                            Debug.Log("Left Swipe");
                        }
                    }
                    else
                    {   //the vertical movement is greater than the horizontal movement
                        if (lp.y > fp.y)  //If the movement was up
                        {   //Up swipe

                            if (linechanger.instance.ChangeLine == 0)
                            {
                                IsChange = true;
                            }


                            if (IsChange)
                            {
                                linechanger.instance.ChangeLine++;
                                Debug.Log("Up Swipe");


                                if (linechanger.instance.Empty1.activeSelf)
                                {
                                    linechanger.instance.Empty2.SetActive(true);
                                    linechanger.instance.Empty1.SetActive(false);
                                    linechanger.instance.Empty3.SetActive(false);
                                    // Player.transform.position = new Vector2(Player.transform.position.x, yAxisLine);
                                    // rb.velocity = new Vector2(rb.velocity.x, 1f);

                                    // Vector3 newScale = new Vector3(scale2,scale2,scale2);
                                    // transform.localScale = newScale;
                                }
                                else if (linechanger.instance.Empty2.activeSelf)
                                {
                                    linechanger.instance.Empty2.SetActive(false);
                                    linechanger.instance.Empty1.SetActive(false);
                                    linechanger.instance.Empty3.SetActive(true);
                                    //  Vector3 newScale = new Vector3(scale3, scale3, scale3);
                                }

                                else if (linechanger.instance.Empty3.activeSelf)
                                {
                                    linechanger.instance.Empty2.SetActive(true);
                                    linechanger.instance.Empty1.SetActive(false);
                                    linechanger.instance.Empty3.SetActive(false);

                                }



                            }
                        }
                        else
                        {   //Down swipe

                            if (linechanger.instance.ChangeLine == 2)
                            {
                                IsChange = true;
                            }


                            if (IsChange)
                            {
                                linechanger.instance.ChangeLine--;
                                Debug.Log("Down Swipe");

                                if (linechanger.instance.Empty1.activeSelf)
                                {
                                    //Vector3 newScale = new Vector3(scale1, scale1, scale1);

                                    linechanger.instance.Empty2.SetActive(true);
                                    linechanger.instance.Empty1.SetActive(false);
                                    linechanger.instance.Empty3.SetActive(false);

                                }
                                else if (linechanger.instance.Empty2.activeSelf)
                                {
                                    linechanger.instance.Empty2.SetActive(false);
                                    linechanger.instance.Empty1.SetActive(true);
                                    linechanger.instance.Empty3.SetActive(false);

                                }

                                else if (linechanger.instance.Empty3.activeSelf)
                                {
                                    linechanger.instance.Empty2.SetActive(true);
                                    linechanger.instance.Empty1.SetActive(false);
                                    linechanger.instance.Empty3.SetActive(false);
                                }


                            }
                        }
                    }
                }
                else
                {   //It's a tap as the drag distance is less than 20% of the screen height
                    Debug.Log("Tap");
                }
            }
        }
        if (linechanger.instance.Empty1.activeSelf)
        {
            transform.localScale = new Vector3(scale1, scale1, scale1);
           

        }
        if (linechanger.instance.Empty2.activeSelf)
        {
            transform.localScale = new Vector3(scale2, scale2, scale2);
            



        }
        if (linechanger.instance.Empty3.activeSelf)
        {
            transform.localScale = new Vector3(scale3, scale3, scale3);
           


        }
    }
}
