using UnityEngine;
using System.Collections;

public class BehaviourScript : MonoBehaviour {

	public float deltaTime= 0f;
	Color a ;
	Color b = Color.red;
	Color temp;
	Color baseColor;

	bool isClicked = false;
	float smoothTime = 2.0F;
	Renderer render;
	RaycastHit hit;
	Collider colliderFatInfo = new Collider();
	Collider colliderBack = new Collider();
	Animator anim = new Animator ();
	Ray cursorRay ;
	bool hide=false;
	//private startPosition;
	private Vector3 velocity = Vector3.zero;

	//GameObjects
	GameObject fat ; 
	GameObject blood;


	//
	// Use this for initialization
	void Start () 
	{
		fat = GameObject.Find ("fat");
		blood = GameObject.Find ("blood_values");

		colliderFatInfo = fat.GetComponent<Collider> ();
		colliderBack = GameObject.Find ("back").GetComponent<Collider> ();
		render = GameObject.Find("base").GetComponent<Renderer> ();
		anim = GetComponent<Animator> ();
		baseColor = render.materials[1].color;
		a = baseColor;

	}
	
	// Update is called once per frame
	void Update () 
	{



		animateArmColor ();

		/*
		Collider colliderBodyInfo = new Collider();
		Collider colliderBloodInfo = new Collider();
		Collider colliderBack = new Collider();
		Collider colliderDetails = new Collider();

		colliderBodyInfo = GameObject.Find ("Body").GetComponent<Collider> ();
		colliderBloodInfo = GameObject.Find ("Blood").GetComponent<Collider> ();
		colliderDetails = GameObject.Find ("details").GetComponent<Collider> ();
		colliderBack = GameObject.Find ("back").GetComponent<Collider> ();
*/
		Transform target = Camera.main.GetComponent<Transform>();

			
		if(Input.GetMouseButtonDown(0) || Input.touchCount > 0)

		{
			isClicked = true;

			if(RuntimePlatform.Android == Application.platform )
				cursorRay = Camera.main.ScreenPointToRay( Input.GetTouch(0).position);
			
			else
				cursorRay = Camera.main.ScreenPointToRay( Input.mousePosition);


			if(colliderFatInfo.Raycast(cursorRay, out hit, 1000.0f ) && !hide )
			{
				anim.Play("armsUp_prova");
				hide = true;
				hideGameObjects(false);
				GameObject.Find("line").SendMessage("setDraw");

			}

			else if(colliderBack.Raycast(cursorRay, out hit, 1000.0f ) && hide  )
			{
				hideGameObjects(true);
				hide = false;
				GameObject.Find("line").SendMessage("setDraw");

			}

			/*
			if( colliderBodyInfo.Raycast( cursorRay, out hit, 1000.0f ) )
			{
				moveCamera();

				TextMesh testo = GameObject.Find("info").GetComponent<TextMesh>();

				testo.text = "Last body info: \n\n"  
					 +
					"Body Mass Index: 24.96 \n" +
					"Fat Distribution: 3.1\n" +
					"Stress level: low\n" +
					"Muscolar Tone: 27.1\n" +
					"Hearing: 25db\n" +
					"Night Vision: good\n";

				if(RuntimePlatform.Android == Application.platform )
				{

					AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
					AndroidJavaObject activity = jc.GetStatic<AndroidJavaObject>("currentActivity");
					activity.Call<int>("bridge", "details");
				}

			}


			else if ( colliderBloodInfo.Raycast( cursorRay, out hit, 1000.0f ) )
			{


				moveCamera();
				
				TextMesh testo = GameObject.Find("info").GetComponent<TextMesh>();
				
				testo.text = "Last blood info: \n\n" +
					"Glucose metabolism: good\n"+
					"Circulation: regular\n" +
					"Blood pressure: 115/75 mmHg\n";


				if(RuntimePlatform.Android == Application.platform )
				{
					
					AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
					AndroidJavaObject activity = jc.GetStatic<AndroidJavaObject>("currentActivity");
					activity.Call<int>("bridge", "blood");
				}

			}

			else if(colliderBack.Raycast( cursorRay, out hit, 1000.0f ))
			{
				moveCameraBack();

			}


			else if ( colliderDetails.Raycast( cursorRay, out hit, 1000.0f ) )
			{
				if(RuntimePlatform.Android == Application.platform )
				{
					
					AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
					AndroidJavaObject activity = jc.GetStatic<AndroidJavaObject>("currentActivity");
					activity.Call("bridge", "details");
				}

				Application.Quit();
			}
			
		*/


		}

		
		
	}//FIne funzione Update


	void moveCamera()
	{
		GameObject c = GameObject.Find("Main Camera");
		
		Camera cam =	c.GetComponent<Camera>();

		//Vector3 targetPosition = transform.TransformPoint (new Vector3 (3, 2, 5));
		
		//transform.position = Vector3.SmoothDamp (transform.position, targetPosition, ref velocity, smoothTime);
		//for (int i=0; i<10; i++) {

			//cam.transform.position = Vector3.Lerp (cam.transform.position, targetPosition,  Time.deltaTime);
		//}



		if(! isClicked)
		{
			cam.SendMessage("moveTo");
			isClicked = true;
		}

	}

	void moveCameraBack()
	{
		GameObject c = GameObject.Find("Main Camera");
		
		Camera cam =	c.GetComponent<Camera>();
		
		//if(! isClicked)
		{
			cam.SendMessage("moveBack");
			isClicked = false;
		}
	}


	void animateArmColor()
	{

		if (isClicked) 
		{
			render.materials [1].color = baseColor;
		} 

		else 
		{


			if (deltaTime >= 1f) 
			{
				deltaTime = 0.0f;
				temp = a;
				a = b;
				b = temp;		
			} 
			else 
			{
				render.materials [1].color = Color.Lerp (a, b, deltaTime);
				deltaTime += 0.01f;
			}
		}

	}


	void hideGameObjects(bool value)
	{
		//if (!hide) 
		{
			//GameObject.Find ("meter").//SetActive (value);
			fat.SetActive(value);
			//GameObject.Find ("fat").GetComponent<Renderer> ().enabled = value;
			blood.SetActive(value);//GetComponent<Renderer> ().enabled = value;
		}

	}

	void setColliders()
	{
		if (hide) 
		{
			colliderFatInfo.enabled = true;
		} 
		else 
		{
			colliderFatInfo.enabled = false;
		}
	}
	
	
}