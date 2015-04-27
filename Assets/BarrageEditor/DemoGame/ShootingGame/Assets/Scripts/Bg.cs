using UnityEngine;
using System.Collections;

public class Bg : MonoBehaviour {

	// スクロールするスピード
	public float speed = 0.1f;
	
	void Update ()
	{
		float y = Mathf.Repeat (Time.time * speed, 1);
		Vector2 offset = new Vector2 (0, y);
		var renderer = gameObject.GetComponent (typeof(Renderer)) as Renderer;
		renderer.sharedMaterial.SetTextureOffset ("_MainTex", offset);
	}
}
