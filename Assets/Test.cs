using UnityEngine;
using System.Collections;
using System.IO;

public class Test : MonoBehaviour {


	public RenderTexture renderTextureRef;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			Debug.Log (1);
			savePng();

		}
	
	}

	void savePng(){

		Texture2D tex = new Texture2D (renderTextureRef.width,renderTextureRef.height,TextureFormat.RGB24,false);
		RenderTexture.active = renderTextureRef;
		tex.ReadPixels(new Rect(0, 0, renderTextureRef.width, renderTextureRef.height), 0, 0);
		tex.Apply();

		// Encode texture into PNG
		byte[] bytes = tex.EncodeToPNG();
		Object.Destroy(tex);

		//Write to a file in the project folder
		File.WriteAllBytes(Application.dataPath + "/../SavedScreen.png", bytes);
	}
}
