using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;


public class changeSprite : MonoBehaviour
{


	public int height;
	public int width;

	public Sprite sprite1;
	// Drag your first sprite here
	public Sprite sprite2;
	// Drag your second sprite here

	private UISprite spriteUI;

	void Start ()
	{

		spriteUI = GetComponent<UISprite> ();
		spriteUI.spriteName = "image1";

	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space)) { // If the space bar is pushed down
			ChangeSprite (); // call method to change sprite
		}
	}

	void ChangeSprite ()
	{
		ReadFile ();

		if (spriteUI.spriteName == "image1") { // if the spriteRenderer sprite = sprite1 then change to sprite2 etc..
			spriteUI.spriteName = "image2";
		} else if (spriteUI.spriteName == "image2") {
			spriteUI.spriteName = "image3";
		} else if (spriteUI.spriteName == "image3") {
			spriteUI.spriteName = "image4";
		} else if (spriteUI.spriteName == "image4") {
			spriteUI.spriteName = "image1";
		}
	}


	public void ReadFile ()
	{
		//can use get component to find the script and then find the value of the color attribute to get the colour 
		//for now let's parse the xml to get the color


		//readxml from xmlfile.xml in project folder (Same folder where Assets and Library are in the Editor)
		XmlReader reader = XmlReader.Create ("Assets/Resources/xmlfile.xml");
		//while there is data read it
		while (reader.Read ()) {


			if (reader.IsStartElement ("width")) {
				width = int.Parse (reader.GetAttribute ("value"));
			}

			if (reader.IsStartElement ("height")) {
				height = int.Parse (reader.GetAttribute ("value"));
			}


		}

	}

	public void changeSpriteOnBtnClick ()
	{

		LoadFromXml ();

		spriteUI.spriteName = "image2";


	}

	public void LoadFromXml ()
	{
		string filepath = Application.dataPath + @"/Resources/gamexml.xml";
		XmlDocument xmlDoc = new XmlDocument ();

		if (File.Exists (filepath)) {
			xmlDoc.Load (filepath);

			XmlNodeList transformList = xmlDoc.GetElementsByTagName ("npc");

			foreach (XmlNode transformInfo in transformList) {
				XmlNodeList transformcontent = transformInfo.ChildNodes;

				foreach (XmlNode transformItens in transformcontent) {
					if (transformItens.Name == "width") {
						width = int.Parse (transformItens.InnerText); // convert the strings to float and apply to the X variable.
					}
					if (transformItens.Name == "height") {
						height = int.Parse (transformItens.InnerText); // convert the strings to float and apply to the Y variable.
					}
				}
			}

			Debug.Log ("width is: " + width + ". And height is " + height);

			spriteUI.width = width;
			spriteUI.height = height;
		}

	}

	public void writeToXml ()
	{

		string filepath = Application.dataPath + @"/Resources/gamexml.xml";
		XmlDocument xmlDoc = new XmlDocument ();

		if (File.Exists (filepath)) {

			xmlDoc.Load (filepath);

			XmlElement elmRoot = xmlDoc.DocumentElement;

			elmRoot.RemoveAll (); // remove all inside the transforms node.

			XmlElement elmNew = xmlDoc.CreateElement ("rotation"); // create the rotation node.

			XmlElement rotation_X = xmlDoc.CreateElement ("x"); // create the x node.
			rotation_X.InnerText = spriteUI.width.ToString (); // apply to the node text the values of the variable.

			XmlElement rotation_Y = xmlDoc.CreateElement ("y"); // create the y node.
			rotation_Y.InnerText = spriteUI.width.ToString (); // apply to the node text the values of the variable.

			XmlElement rotation_Z = xmlDoc.CreateElement ("z"); // create the z node.
			rotation_Z.InnerText = spriteUI.width.ToString (); // apply to the node text the values of the variable.

			elmNew.AppendChild (rotation_X); // make the rotation node the parent.
			elmNew.AppendChild (rotation_Y); // make the rotation node the parent.
			elmNew.AppendChild (rotation_Z); // make the rotation node the parent.
			elmRoot.AppendChild (elmNew); // make the transform node the parent.

			xmlDoc.Save (filepath); // save file.

		}
	}
}
