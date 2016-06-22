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
		LoadFromXml ();

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


	public void changeSpriteOnBtnClick ()
	{
		LoadFromXml ();
		spriteUI.spriteName = "image2";
	}

	public void LoadFromXml ()
	{
		string filepath = Application.dataPath + @"/Resources/file.xml";
		XmlDocument xmlDoc = new XmlDocument ();

		if (File.Exists (filepath)) {
			xmlDoc.Load (filepath);

			XmlNodeList transformList = xmlDoc.GetElementsByTagName ("values");

			foreach (XmlNode transformInfo in transformList) {
				XmlNodeList transformcontent = transformInfo.ChildNodes;

				foreach (XmlNode transformItens in transformcontent) {
					if (transformItens.Name == "width") {
						width = int.Parse (transformItens.InnerText); // convert the strings to int and apply to the width variable.
					}
					if (transformItens.Name == "height") {
						height = int.Parse (transformItens.InnerText); // convert the strings to int and apply to the height variable.
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
		string filepath = Application.dataPath + @"/Resources/file.xml";
		XmlDocument xmlDoc = new XmlDocument ();

		if (File.Exists (filepath)) {

			xmlDoc.Load (filepath);

			XmlElement elmRoot = xmlDoc.DocumentElement;
			elmRoot.RemoveAll (); // remove all inside the values node.

			XmlElement widthValue = xmlDoc.CreateElement ("width"); // create the width node.
			widthValue.InnerText = spriteUI.width.ToString (); // apply to the node text the values of the variable.

			XmlElement heightValue = xmlDoc.CreateElement ("height"); // create the width node.
			heightValue.InnerText = spriteUI.height.ToString (); // apply to the node text the values of the variable.

			elmRoot.AppendChild (widthValue); // make the values node the parent.
			elmRoot.AppendChild (heightValue); // make the values node the parent.

			xmlDoc.Save (filepath); // save file.

		}
	}
}
