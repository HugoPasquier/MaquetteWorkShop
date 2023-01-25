using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lampadaire : MonoBehaviour
{
    public float radius = 5f;
    private bool isOn = false;

    public SpriteMask mask = null;
    void Start()
    {
        mask = gameObject.GetComponentInChildren<SpriteMask>();
        mask.transform.localScale = new Vector3(1f, 1f, 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("Triggered");
        isOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOn && mask.transform.localScale.x < radius) {
            mask.transform.localScale = Vector3.Lerp(mask.transform.localScale, new Vector3(radius, radius, 1f), Time.deltaTime);
            //mask.transform.localScale = new Vector3(radius, radius, 1f);
        }
    }
}
