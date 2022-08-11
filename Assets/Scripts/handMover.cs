using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class handMover : MonoBehaviour
{
    [SerializeField] private bool cliced_ = false;
    public bool finished_ = false;
    public Camera cam;
    public GameObject bag;
    public lineRenderer line_Renderer;
    public LineRenderer line_RendererComp;
    public handCreator hand_Creator;
    bool isFirstClice_ = true;
    public Transform secondPoint;
    public Transform inviseHand;
    private Vector3 targetPos;
    public GameController gameController;
    public AudioSource handSound;
    public AudioSource takeBagSound;

    public bool lose;

    float speed = 10;


    private void Update()
    {
        if (Input.GetMouseButton(0) && cliced_ == true && finished_ == false && lose != true)
        {
            Vector3 targetPos = new Vector3(cam.ScreenToWorldPoint(Input.mousePosition).x, cam.ScreenToWorldPoint(Input.mousePosition).y, 0);
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * speed);

            var angle = Vector2.Angle(Vector2.right, cam.ScreenToWorldPoint(Input.mousePosition) - transform.position);//угол между вектором от объекта к мыше и осью х
            transform.eulerAngles = new Vector3(0f, 0f, transform.position.y < cam.ScreenToWorldPoint(Input.mousePosition).y ? angle : -angle);//немного магии на последок
        }
        else if (finished_ == true)
        {
            if (line_RendererComp.positionCount > 2)
            {
                targetPos = new Vector3(line_RendererComp.GetPosition(line_RendererComp.positionCount - 2).x, line_RendererComp.GetPosition(line_RendererComp.positionCount - 2).y, 0);
                speed = 100;
            }
            else
            {
                //if (gameController.isWin)
                    //gameController.WinSound();
                targetPos = inviseHand.position;
                speed = 10;
            }
            //transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * speed);
            transform.position = Vector3.MoveTowards(transform.position, targetPos, 90f * Time.deltaTime);
            if (transform.position == targetPos && line_RendererComp.positionCount > 2)
            {
                line_RendererComp.positionCount--;
                line_RendererComp.SetPosition(line_RendererComp.positionCount - 1, secondPoint.position);
            }
            transform.rotation = Quaternion.Lerp(transform.rotation, inviseHand.transform.rotation, Time.deltaTime * 5);
        }
    }
    private void OnMouseDown()
    {
        if (isFirstClice_ == true)
        {
            line_Renderer.cliced_ = true;
            isFirstClice_ = false;
        }
        cliced_ = true;
        hand_Creator.cliced_ = true;
        handSound.Play();
    }
    private void OnMouseUp()
    {
        cliced_ = false;
        hand_Creator.cliced_ = false;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Invisehand" && finished_ == true)
        {
            gameController.Win();
        }
        else if (collision.tag == "people")
        {
            gameController.Lose();
        }
    }
        public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "bag" && cliced_ == false && finished_ == false)
        {
            finished_ = true;
            takeBagSound.Play();
            collision.transform.SetParent(transform);
            GetComponent<Collider2D>().isTrigger = true;
            Gradient gradient = new Gradient();
            GradientColorKey[] colorKey = new GradientColorKey[2];
            colorKey[0].color = new Color(0, 0, 0, 1);
            colorKey[0].time = 0.0f;
            colorKey[1].color = new Color(0, 0, 0, 1);
            colorKey[1].time = 1.0f;
            GradientAlphaKey[] alphaKey = new GradientAlphaKey[2];
            alphaKey[0].alpha = 1.0f;
            alphaKey[0].time = 0.0f;
            alphaKey[1].alpha = 1.0f;
            alphaKey[1].time = 1.0f;
            gradient.SetKeys(colorKey, alphaKey);
            line_RendererComp.colorGradient = gradient;
        }
        else if (collision.tag == "bag" && cliced_ == true)
        {
            Gradient gradient = new Gradient();
            GradientColorKey[] colorKey = new GradientColorKey[2];
            colorKey[0].color = new Color(0.062745098f, 0.97254902f, 0.980392157f, 1);
            colorKey[0].time = 0.0f;
            colorKey[1].color = new Color(0.062745098f, 0.97254902f, 0.980392157f, 1);
            colorKey[1].time = 1.0f;
            GradientAlphaKey[] alphaKey = new GradientAlphaKey[2];
            alphaKey[0].alpha = 1.0f;
            alphaKey[0].time = 0.0f;
            alphaKey[1].alpha = 1.0f;
            alphaKey[1].time = 1.0f;
            gradient.SetKeys(colorKey, alphaKey);
            line_RendererComp.colorGradient = gradient;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "bag" && cliced_ == true)
        {
            Gradient gradient = new Gradient();
            GradientColorKey[] colorKey = new GradientColorKey[2];
            colorKey[0].color = new Color(0, 0, 0, 1);
            colorKey[0].time = 0.0f;
            colorKey[1].color = new Color(0, 0, 0, 1);
            colorKey[1].time = 1.0f;
            GradientAlphaKey[] alphaKey = new GradientAlphaKey[2];
            alphaKey[0].alpha = 1.0f;
            alphaKey[0].time = 0.0f;
            alphaKey[1].alpha = 1.0f;
            alphaKey[1].time = 1.0f;
            gradient.SetKeys(colorKey, alphaKey);
            line_RendererComp.colorGradient = gradient;
        }
    }
}
