using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class infoUI : MonoBehaviour
{

    public AxolotlUIcount axolotlUI;
    public GameObject panelUI;
    private Panelinfoholder panelInfo;

    private TextMeshProUGUI tt;
    private TextMeshProUGUI dt;
    private Image i;
    private TextMeshProUGUI id;

    [Header("MOVEMENT TUTORIAL THINGS")]
    [SerializeField] private string tutText;
    [SerializeField] private string tutDesc;
    [SerializeField] private Sprite tutSprite;
    [SerializeField] private string tutSpriteDesc;
    private bool tutorial = true;

// Start is called before the first frame update
    void Start()
    {
        axolotlUI = FindObjectOfType<AxolotlUIcount>();
        panelUI.SetActive(false);
        panelInfo = panelUI.GetComponent<Panelinfoholder>();
        tt = panelInfo.titletext;
        dt = panelInfo.descriptiontext;
        i = panelInfo.image;
        id = panelInfo.imageDesc;
        if (tutorial)
        {
            InitTutorial();
            tutorial = false;
        }
    }

    private void Awake()
    {
        
    }

    void InitTutorial()
    {
        PanelUpdate(tutText,tutDesc,tutSprite,tutSpriteDesc);
    }


    public void PanelUpdate(string title, string description, Sprite image, string imagedesc)
    {
        tt.text = title;
        dt.text = description;
        i.sprite = image;
        id.text = imagedesc;
        panelUI.SetActive(true);
        
    }
    
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            panelUI.SetActive(false);
        }
    }
}
