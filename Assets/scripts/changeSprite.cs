using UnityEngine;
using System.Collections;

public class changeSprite : MonoBehaviour
{
	public Color color;
	public float height;
	public float width;

	public Sprite sprite1;
	// Drag your first sprite here
	public Sprite sprite2;
	// Drag your second sprite here

	private SpriteRenderer spriteRenderer;

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
//		spriteRenderer.color = Color.green;
//		GetComponent<SpriteRenderer> ().color = Color.green;

		if (spriteRenderer.sprite == sprite1) { // if the spriteRenderer sprite = sprite1 then change to sprite2
			spriteRenderer.sprite = sprite2;
		} else {
			spriteRenderer.sprite = sprite1; // otherwise change it back to sprite1
		}

	}


}