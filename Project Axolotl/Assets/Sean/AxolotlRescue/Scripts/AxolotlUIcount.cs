using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AxolotlUIcount : MonoBehaviour
{
    private int axolotlsToFind;
    private int axolotlsaved;
    private TextMeshProUGUI text;
    private AxolotlRescuezone zone;
    // Start is called before the first frame update
    void Start()
    {
        zone = GameObject.Find("ExtractionZone").GetComponent<AxolotlRescuezone>();
        text = GetComponent<TextMeshProUGUI>();
       axolotlsToFind = GameObject.FindGameObjectsWithTag("Axolotl").Length;
    }

    // Update is called once per frame
    void Update()

    {
        axolotlsaved = zone.rescuecount;
        text.text = "Axolotles rescued: " + axolotlsaved + "/ " +axolotlsToFind.ToString();
    }
}
