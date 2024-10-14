using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    public Image DPad;
    private Vector2 touchStart, touchEnd;
    public float DPadRadius = 40;
    private Touch theTouch;


    [SerializeField] float moveSpeed;
    public Vector2 inputDirection,lookDirection;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        //makes the character look down by default
        lookDirection = new Vector2(0, -1);
    }

    // Update is called once per frame
    void Update()
    {
        //getting input from keyboard controls
 //       calculateMobileInput();

        calculateTouchInput();

        //sets up the animator
        animationSetup();

        //moves the player

        transform.Translate(inputDirection * moveSpeed * Time.deltaTime);
    }


    void calculateDesktopInputs()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        inputDirection = new Vector2(x, y).normalized;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            attack();
        }

    }


    void animationSetup()
    {
        //checking if the player wants to move the character or not
        if (inputDirection.magnitude > 0.1f)
        {
            //changes look direction only when the player is moving, so that we remember the last direction the player was moving in
            lookDirection = inputDirection;

            //sets "isWalking" true. this triggers the walking blend tree
            anim.SetBool("isWalking", true);
        }
        else
        {
            // sets "isWalking" false. this triggers the idle blend tree
            anim.SetBool("isWalking", false);

        }

        //sets the values for input and lookdirection. this determines what animation to play in a blend tree
        anim.SetFloat("inputX", lookDirection.x);
        anim.SetFloat("inputY", lookDirection.y);
        anim.SetFloat("lookX", lookDirection.x);
        anim.SetFloat("lookY", lookDirection.y);
    }

    public void attack()
    {
        anim.SetTrigger("Attack");
    }

    void calculateMobileInput()
    {
        if (Input.GetMouseButton(0))
        {
            DPad.gameObject.SetActive(true);

            if (Input.GetMouseButtonDown(0))
            {
                touchStart = Input.mousePosition;
            }

            touchEnd = Input.mousePosition;

            float x = touchEnd.x - touchStart.x;
            float y = touchEnd.y - touchStart.y;

            inputDirection = new Vector2(x, y).normalized;

            if ((touchEnd - touchStart).magnitude > DPadRadius)
            {
                DPad.transform.position = touchStart + (touchEnd - touchStart).normalized * DPadRadius;
            }

            else
            {
                DPad.transform.position = touchEnd;
            }

        }

        else
        {
            inputDirection = Vector2.zero;
            DPad.gameObject.SetActive(false);
        }
    }

    void calculateTouchInput()
    {
        if (Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);

            if (theTouch.phase == TouchPhase.Began)
            {
                touchStart = theTouch.position;
            }
            else  if(theTouch.phase == TouchPhase.Moved || theTouch.phase == TouchPhase.Ended)
                {
                
                touchEnd = theTouch.position;

                float x = touchEnd.x - touchStart.x;
                float y = touchEnd.y - touchStart.y;

                inputDirection = new Vector2(x, y).normalized;

                if ((touchEnd - touchStart).magnitude > DPadRadius)
                {
                    DPad.transform.position = touchStart + (touchEnd - touchStart).normalized * DPadRadius;
                }

                else
                {
                    DPad.transform.position = touchEnd;
                }

            }
        }

        else
        {
            inputDirection = Vector2.zero;
            DPad.gameObject.SetActive(false);
        }
    }
}
