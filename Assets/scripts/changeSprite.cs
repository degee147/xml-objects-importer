using UnityEngine;
using System.Collections;
using System.Xml;


public class changeSprite : MonoBehaviour
{

	public Color color;
	public float height;
	public float width;

	public Sprite sprite1;
	// Drag your first sprite here
	public Sprite sprite2;
	// Drag your second sprite here

	//private SpriteRenderer spriteRenderer;

	private UISprite spriteUI;




	void Start ()
	{

		spriteUI = GetComponent<UISprite>();
		spriteUI.spriteName = "image1";

//		spriteRenderer = GetComponent<SpriteRenderer> (); // we are accessing the SpriteRenderer that is attached to the Gameobject
//		if (spriteRenderer.sprite == null) { // if the sprite on spriteRenderer is null then
//			spriteRenderer.sprite = sprite1; // set the sprite to sprite1
//		}
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

		if (spriteUI.spriteName == "image1") { // if the spriteRenderer sprite = sprite1 then change to sprite2
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
				width = float.Parse (reader.GetAttribute ("value"));
			}

			if (reader.IsStartElement ("height")) {
				height = float.Parse (reader.GetAttribute ("value"));
			}


		}


				spriteUI.width = 160;
				spriteUI.height = 270;
	}

	public void changeSpriteOnBtnClick ()
	{

		ReadFile ();
		//spriteRenderer.sprite = sprite1;
		spriteUI.spriteName = "image2";
//		Debug.Log ("ht is this: " + position);
//		Debug.Log (color);
//		spriteRenderer.color = Color.green;
//		GetComponent<SpriteRenderer> ().color = Color.green;

	}


}
