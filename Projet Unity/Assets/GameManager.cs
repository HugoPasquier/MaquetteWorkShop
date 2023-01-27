using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TramMovement tram;
    [SerializeField] AgentMovement agent;

    public void StartTram() {
        tram.StartTram();
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
