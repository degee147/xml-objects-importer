using UnityEngine;
using System.Collections;
using System.Xml;


public class changeSprite : MonoBehaviour
{
//	[System.Serializable]
	public Color color;
	public float height;
	public float width;

//	[XmlAttribute("height")]
//	public string ht;
//
	public Sprite sprite1;
	// Drag your first sprite here
	public Sprite sprite2;
	// Drag your second sprite here

	private SpriteRenderer spriteRenderer;



	// npc data
	public string npcName;
	public string npcType;


	// chat data
	public int maxData;
	public int showData;
	public string[] data;





//	public Vector3 position;
//
//	[XmlAttribute("Position")]
//	public string Position_Surrogate{
//		get{ return ""; }
//		set{ 
//			position = new Vector3().FromString(value);
//		}
//	}
//

	void Start ()
	{
		spriteRenderer = GetComponent<SpriteRenderer> (); // we are accessing the SpriteRenderer that is attached to the Gameobject
		if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
			spriteRenderer.sprite = sprite1; // set the sprite to sprite1
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space)) { // If the space bar is pushed down
			ChangeTheDamnSprite (); // call method to change sprite
		}
	}

	void ChangeTheDamnSprite ()
	{
		if (spriteRenderer.sprite == sprite1) { // if the spriteRenderer sprite = sprite1 then change to sprite2
			spriteRenderer.sprite = sprite2;

		} else {
			spriteRenderer.sprite = sprite1; // otherwise change it back to sprite1
		}
	}


	public void changeSpriteOnBtnClick ()
	{

//		Debug.Log ("Im here");

		spriteRenderer.transform.localScale = new Vector3 (width, height, 0);

		//can use get component to find the script and then find the value of the color attribute to get the colour 
		//for now let's parse the xml to get the color


		// initialise data
		maxData = 0;
		showData = 0;
		npcName = "unset";
		npcName = "unset";
		data = null;


		//readxml from chat.xml in project folder (Same folder where Assets and Library are in the Editor)
		XmlReader reader = XmlReader.Create("Assets/Resources/chat.xml");
		//while there is data read it
		while(reader.Read())
		{
			//when you find a npc tag do this
			if(reader.IsStartElement("npc"))
			{
				// get attributes from npc tag
				npcName=reader.GetAttribute("name");
				npcType = reader.GetAttribute("npcType");
//				maxData = (int)reader.GetAttribute("entries");

				Debug.Log ("npcName is " + npcName);
				Debug.Log ("npcType is " + npcType);
//				Debug.Log (maxData);

//				//allocate string pointer array
//				data = new String[maxData];
//
//				//read speach elements (showdata is used instead of having a new int I reset it later)
//				for(showData = 0;showData<maxData;showData++)
//				{
//					reader.Read();
//					if(reader.IsStartElement("speach"))
//					{
//						//fill strings
//						data[showData] = reader.ReadString();
//					}
//				}
//				//reset showData index
//				showData=0;
//

			}
		}


//		Debug.Log ("ht is this: " + position);
//		Debug.Log (color);
//		spriteRenderer.color = Color.green;
//		GetComponent<SpriteRenderer> ().color = Color.green;

		if (spriteRenderer.sprite == sprite1) { // if the spriteRenderer sprite = sprite1 then change to sprite2
			spriteRenderer.sprite = sprite2;
		} else {
			spriteRenderer.sprite = sprite1; // otherwise change it back to sprite1
		}

	}


}


//public static class Vector3Helper
//{
//
//	public static Vector3 FromString(this Vector3 vector, string value){
//		string[] temp = value.Replace(" ", "").Split(',');
//		vector.x = float.Parse(temp[0]);
//		vector.y = float.Parse(temp[1]);
//		vector.z = float.Parse(temp[2]);
//
//		return vector;
//	}
//}