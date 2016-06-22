using UnityEngine;
using System.Collections;
using System.Xml;


public class changeSprite : MonoBehaviour
{

	public Color color;
	public int height;
	public int width;

	public Sprite sprite1;	// Drag your first sprite here
	public Sprite sprite2;	// Drag your second sprite here

	//private SpriteRenderer spriteRenderer;
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
				width =  int.Parse (reader.GetAttribute ("value"));
			}

			if (reader.IsStartElement ("height")) {
				height = int.Parse (reader.GetAttribute ("value"));
			}


		}
		Debug.Log ("width is: " + width + ". And height is " + height);

		spriteUI.width = width;
		spriteUI.height = height;
	}

	public void changeSpriteOnBtnClick ()
	{

		ReadFile ();
		//spriteRenderer.sprite = sprite1;
		spriteUI.spriteName = "image2";

//		Debug.Log (color);
//		spriteRenderer.color = Color.green;
//		GetComponent<SpriteRenderer> ().color = Color.green;

	}

	public void writeToXml(){
		Debug.Log ("gotcha");
	}
}
