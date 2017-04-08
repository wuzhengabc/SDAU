using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class ApplicationLoader : MonoBehaviour 
{
    private string xmlPath = "Data/xml/PopupTagConfig.xml";
	void Start () 
    {
		
	}

    void Initiate()
    {
        string path = Application.dataPath + "/" + xmlPath;
        XmlDocument doc = new XmlDocument();
        doc.Load(path);
    }

	void Update () 
    {
		
	}
}
