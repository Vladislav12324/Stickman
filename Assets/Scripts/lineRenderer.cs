using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lineRenderer : MonoBehaviour
{
    public LineRenderer line_Renderer;
    public Transform firstPoint;
    public Transform secondPoint;
    public Transform thirdPoint;
    public Transform inviseHand;
    public bool cliced_;
    EdgeCollider2D edge;
    Vector2 offcet = new Vector2(-0.54f, 3.75f);
    Vector2 edgeMinus = new Vector2(-6.94f, 23.75f);
    public float angle;
    public handMover hand_Mover;
    public Transform player;
    public Transform hand;
    public GameController gameController;



    void Start()
    {
        inviseHand.position = hand.position;
        inviseHand.rotation = Quaternion.Euler(hand.rotation.x, hand.rotation.y, hand.rotation.z - 90);
        //offcet = firstPoint.position;
        edgeMinus = player.position;
        line_Renderer.positionCount = 3;
        line_Renderer.SetPosition(0, firstPoint.position);
        line_Renderer.SetPosition(1, thirdPoint.position);
        line_Renderer.SetPosition(2, secondPoint.position);

        MakeCollider();
        edge = gameObject.GetComponent<EdgeCollider2D>();
    }

    public void MakeCollider()
    {
        var line = GetComponent<LineRenderer>();

        //get pos
        var pos = new Vector3[line.positionCount];
        line.GetPositions(pos);

        //create collider
        if (!gameObject.GetComponent<EdgeCollider2D>())
        {
            edge = gameObject.AddComponent<EdgeCollider2D>();
            edge.isTrigger = true;
            //edge.offset = offcet;
        }
        edge.points = pos.Select(p => (Vector2)p - edgeMinus).ToArray();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hand_Mover.finished_ != true)
        {
            if (collision.tag == "people")
            {
                gameController.Lose();
            }
            else if (collision.tag == "obstruction")
            {
                refractionCreator(collision);
            }
        }
    }

    private void refractionCreator(Collider2D collision)
    {
            line_Renderer.positionCount++;
            line_Renderer.SetPosition(line_Renderer.positionCount - 2, collision.transform.position);
            line_Renderer.SetPosition(line_Renderer.positionCount - 1, secondPoint.position);
    }
    private void Update()
    {
        if (hand_Mover.finished_ != true)
        {
            if (line_Renderer.positionCount > 2)
            {
                Vector2 x = new Vector2(line_Renderer.GetPosition(line_Renderer.positionCount - 2).x, line_Renderer.GetPosition(line_Renderer.positionCount - 2).y) - new Vector2(line_Renderer.GetPosition(line_Renderer.positionCount - 1).x, line_Renderer.GetPosition(line_Renderer.positionCount - 1).y);
                Vector2 y = new Vector2(line_Renderer.GetPosition(line_Renderer.positionCount - 2).x, line_Renderer.GetPosition(line_Renderer.positionCount - 2).y) - new Vector2(line_Renderer.GetPosition(line_Renderer.positionCount - 3).x, line_Renderer.GetPosition(line_Renderer.positionCount - 3).y);
                angle = Vector2.Angle(x, y);
                if (angle < 90)
                {
                    line_Renderer.positionCount--;
                    line_Renderer.SetPosition(line_Renderer.positionCount - 1, secondPoint.position);
                }
            }
            if (cliced_ == true)
            {
                line_Renderer.positionCount = 2;
                line_Renderer.SetPosition(0, firstPoint.position);
                cliced_ = false;
            }
            if(hand_Mover.lose == false)
                MakeCollider();
        }
        line_Renderer.SetPosition(line_Renderer.positionCount - 1, secondPoint.position);
    }
}
