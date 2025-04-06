using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxolotlRescuezone : MonoBehaviour
{
    public int rescuecount = 0;
    private int axolotlcount;
    // Start is called before the first frame update
    public bool win = false;
    void Start()
    {
        axolotlcount = GameObject.FindGameObjectsWithTag("Axolotl").Length;
    }

    // Update is called once per frame
    void Update()
    {
        if(axolotlcount >= rescuecount) {  win = true; }
    }

     void OnTriggerEnter2D(UnityEngine.Collider2D other)
    {
        Debug.Log("Object");
        if(other.gameObject.tag == "Axolotl")
        {
            Debug.Log("Axolotl Saved");
            other.gameObject.GetComponent<Axolotlnpc>().rescued = true;
            rescuecount+= 1;
        }
    }

     void OnTriggerExit2D(UnityEngine.Collider2D other)
    {
        if (other.gameObject.GetComponent<Axolotlnpc>() != null)
        {
            other.gameObject.GetComponent<Axolotlnpc>().rescued = false;
            rescuecount-= 1;
        }
    }
}
