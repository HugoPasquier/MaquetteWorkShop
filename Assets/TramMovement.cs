using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TramMovement : MonoBehaviour
{
    [SerializeField] Transform[] points;
    [SerializeField] Transform waitingPoint;
    [SerializeField] float speed = 1f;
    [SerializeField] float attente = 3f;
    private int pointsIndex = 0;

    private float epsilon = 0.1f;
    private bool stop = false;
    [SerializeField] private bool start = false;

    public void StartTram() {
        start = true;
    }

    void Go(){
        Debug.Log("EnterGo");
        stop = false;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("EnterCollision");
        Invoke("Go", attente);
        collision.gameObject.GetComponent<AgentMovement>().End();
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (start) {

            if (pointsIndex <= points.Length - 1) {
                transform.position = Vector3.MoveTowards(transform.position, points[pointsIndex].position, speed * Time.deltaTime);
                transform.up = Vector3.RotateTowards(transform.up, points[pointsIndex].position - transform.position, speed * Time.deltaTime, 0.0f);

                if (Vector3.Distance(transform.position, points[pointsIndex].transform.position) < epsilon && !stop) {
                    Debug.Log("next point");
                    pointsIndex++;
                }
            }

            if (points[pointsIndex].position == waitingPoint.position) {
                stop = true;
            }
        }
    }
}
