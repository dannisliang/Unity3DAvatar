using UnityEngine;
using System.Collections;

public class drawLine : MonoBehaviour {

	LineRenderer line;

	Vector3 start = new Vector3 (57f, 13f, 119.1f);
	Vector3 end = new Vector3 (60f, 13f, 116.1f);
	float delta = 0f;
	bool draw = false;

	// Use this for initialization
	void Start () 
	{
		line = gameObject.GetComponent<LineRenderer> ();
		line.SetVertexCount (2);

		line.material = new Material(Shader.Find("Unlit/Texture"));
		line.SetColors (Color.white, Color.white);
	
	}
	
	// Update is called once per frame
	void Update () 
	{


		if (draw) 
		{
	
			if (delta <= 1f) 
			{
				line.SetPosition (1, Vector3.Lerp (start, end, delta));
				delta += 0.06f;
			}
		}

		else
			line.SetPosition (1, start);


	}


	void setDraw()
	{
		if (draw)
			draw = false;
		else 
			draw = true;
	}

}
