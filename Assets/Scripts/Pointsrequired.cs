using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointsrequired : MonoBehaviour
{
    public GameObject GrenadePoint;
    public GameObject MachinePoint;
    public GameObject RocketPoint;
    public GameObject ShotgunPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag== "GrenadePoints")
        {
            GrenadePoint.SetActive(true);
        }
        if (other.tag == "ShotgunPoints")
        {
            ShotgunPoint.SetActive(true);
        }
        if (other.tag == "MachinePoints")
        {
            MachinePoint.SetActive(true);
        }
        if (other.tag == "RocketPoints")
        {
            RocketPoint.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "GrenadePoints")
        {
            GrenadePoint.SetActive(false);
        }
        if (other.tag == "ShotgunPoints")
        {
            ShotgunPoint.SetActive(false);
        }
        if (other.tag == "MachinePoints")
        {
            MachinePoint.SetActive(false);
        }
        if (other.tag == "RocketPoints")
        {
            RocketPoint.SetActive(false);
        }
    }
}
