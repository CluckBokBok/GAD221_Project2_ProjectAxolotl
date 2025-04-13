using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestpointerSpawner : MonoBehaviour
{
    private GameObject[] axolotls;
    private int axocount;
    private GameObject[] extracts;
    private int extcount;
    public GameObject axolotlpointer;
    public GameObject extractpointer;
   

    
    // Start is called before the first frame update
    void Start()
    {
         axolotls = GameObject.FindGameObjectsWithTag("Axolotl");
         extracts = GameObject.FindGameObjectsWithTag("Extract");
         while (axocount < axolotls.Length)
         {
             GameObject pointer = Instantiate(axolotlpointer, transform);
             QuestPointer qp = pointer.GetComponent<QuestPointer>();
             qp.questobject = axolotls[axocount];
             axocount += 1;
         }
         while (extcount < extracts.Length)
         {
             GameObject pointer = Instantiate(extractpointer, transform);
             QuestPointer qp = pointer.GetComponent<QuestPointer>();
             qp.questobject = extracts[extcount];
             extcount += 1;
         }
         
         
         
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
