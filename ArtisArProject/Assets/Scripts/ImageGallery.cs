using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageGallery : MonoBehaviour {

    public RawImage img;
    public GameObject buttonPrefab;
    public Transform buttonContainer;

    private void Start()
    {
        Texture[] textures = Resources.LoadAll<Texture>("Images");
        foreach (Texture t in textures)
        {
            GameObject go = Instantiate(buttonPrefab) as GameObject;
            go.transform.SetParent(buttonContainer);
            go.GetComponent<RawImage>().texture = t;

            string tName = t.name;
            go.GetComponent<Button>().onClick.AddListener(() => OnButtonClick(tName));
            go.GetComponentInChildren<Text>().text = tName;
        }
        
    }

    public void OnButtonClick(string imgName)
    {
        //Debug.Log(imgName);
        img.texture = Resources.Load<Texture>("Assets/Resources/Images/" + imgName);
    }



}
