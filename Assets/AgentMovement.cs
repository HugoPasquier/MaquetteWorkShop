using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgentMovement : MonoBehaviour
{
    public float speed = 5f;
    [SerializeField] float finalRadius = 100f;
    [SerializeField] Transform[] points;
    [SerializeField] Transform waitingPoint;
    [SerializeField] float attente = 3f;
    private int pointsIndex = 0;

    private float epsilon = 0.1f;
    private bool stop = false;
    private bool start = false;
    private SpriteMask mask = null;
    private bool end = false;

    // Start is called before the first frame update
    void Start()
    {
        //transform.position = points[0].position;
    }

    public void End() {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        mask = gameObject.GetComponentInChildren<SpriteMask>();
        end = true;
    }
    
    void Inputs() {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        transform.position += (new Vector3(x, y, 0)).normalized * speed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();

        if (end) {
            mask.transform.localScale = Vector3.Lerp(mask.transform.localScale, new Vector3(finalRadius, finalRadius, 1f), Time.deltaTime * 0.05f);
        }

        //if (start) {

        //    if (pointsIndex <= points.Length - 1) {
        //        transform.position = Vector3.MoveTowards(transform.position, points[pointsIndex].position, speed * Time.deltaTime);
        //        transform.up = Vector3.RotateTowards(transform.up, points[pointsIndex].position - transform.position, speed * Time.deltaTime, 0.0f);

        //        if (Vector3.Distance(transform.position, points[pointsIndex].transform.position) < epsilon && !stop) {
        //            Debug.Log("next point");
        //            pointsIndex++;
        //        }
        //    }

        //    if (points[pointsIndex].position == waitingPoint.position) {
        //        stop = true;
        //    }
        //}

    }






    public void StartTram() {
        start = true;
    }

    void Go() {
        Debug.Log("EnterGo");
        stop = false;
    }


 


}
