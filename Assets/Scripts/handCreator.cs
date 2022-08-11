using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class handCreator : MonoBehaviour
{
    public GameObject segment;
    public Transform shoulder;
    public Transform beginnHand;
    private double spawnDistance = 1.65f;
    [SerializeField] private List<GameObject> segmentList = new List<GameObject>();
    public bool cliced_;
    [SerializeField] private double diag;


    void Start()
    {
        segmentList.Add(segment);
    }

    void Update()
    {
        //рассчёт расстояния от плеча до начала руки
        double lineX = beginnHand.position.x - shoulder.position.x;
        double lineY = beginnHand.position.y - shoulder.position.y;
        diag = System.Math.Sqrt(System.Math.Pow(lineX, 2) + System.Math.Pow(lineY, 2));

        double angle;
        //расчёт угла вращения
        if (beginnHand.transform.position.y > transform.position.y)
            angle = System.Math.Acos(lineY/diag);
        else
            angle = System.Math.Acos(lineX / diag);
        segment.transform.rotation = Quaternion.Euler(0, 0, (float)angle);

        if (cliced_ == true)
        {
            //спавн сегментов
            if (diag >= spawnDistance)
            {
                GameObject newSegment = Instantiate(segment, segmentList.Last().transform.position + new Vector3(0, -1.65f, 0), Quaternion.identity, segmentList.Last().transform);
                newSegment.GetComponent<FixedJoint2D>().connectedBody = segmentList.Last().GetComponent<Rigidbody2D>();
                segmentList.Add(newSegment);
                spawnDistance = spawnDistance + 1.65f;
            }
            //удаление сегментов
            else
            {
                Destroy(segmentList.Last());
                segmentList.Remove(segmentList.Last());
                spawnDistance = spawnDistance - 1.65f;
            }
        }
    }
}
