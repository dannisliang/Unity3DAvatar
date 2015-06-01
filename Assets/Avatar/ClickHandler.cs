using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {
	
	
	
	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		//RaycastHit hit;
		Collider collider = new Collider();
		
		
		
		if(Input.GetMouseButtonDown(0) || Input.touchCount > 0)
		//if(Input.touchCount > 0)
		{
			/*
			Ray cursorRay ;
			
			
			if(RuntimePlatform.Android == Application.platform )
				cursorRay = Camera.main.ScreenPointToRay( Input.GetTouch(0).position);
			//Input.GetTouch(0).position );
			
			else
			 cursorRay = Camera.main.ScreenPointToRay( Input.mousePosition);
			
			
			collider = gameObject.GetComponent<Collider>();
			
			
			if( collider.Raycast( cursorRay, out hit, 1000.0f ) )
			{
				
				TextMesh testo = GameObject.Find("Scritta").GetComponent<TextMesh>();
				
				testo.text = "Click coord: \n" + hit.point;
				/*
				using (AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
				{ 
					using (AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity"))
					{
						// Call the getTaskId() method
						int result = jo.Call<int>("call", hit.point.ToString());
					}
				} 
*/
				Debug.Log( "Hai cliccato " + name + " nel punto " + Input.mousePosition); //hit.point );
				
				
				
			//}
			
		}
		
		
	}//FIne funzione Update
	
	
}