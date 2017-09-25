using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

	// Subscribe to events  
	void OnEnable(){  
		EasyTouch.On_TouchStart += On_TouchStart;  
		EasyJoystick.On_JoystickMove += OnJoystickMove;  
		EasyJoystick.On_JoystickMoveEnd += OnJoystickMoveEnd;  
	}  
	// Unsubscribe  
	void OnDisable(){  
		EasyTouch.On_TouchStart -= On_TouchStart;  
	}  
	// Unsubscribe  
	void OnDestroy(){  
		EasyTouch.On_TouchStart -= On_TouchStart;  
	}  
	// Touch start event  
	public void On_TouchStart(Gesture gesture){  
		//Debug.Log( "Touch in " + gesture.position);  
	}
	//control end 
	void OnJoystickMoveEnd(MovingJoystick move)  
	{   
		if (move.joystickName == "MoveJoystick")  
		{  
		}  
	}  
	//controling
	void OnJoystickMove(MovingJoystick move)  
	{  
		if (move.joystickName != "MoveJoystick")  
		{  
			return;  
		}  
		 
		/*float joyPositionX = move.joystickAxis.x;  
		float joyPositionY = move.joystickAxis.y;  
		if (joyPositionY != 0 || joyPositionX != 0)  
		{  
			Debug.Log (joyPositionY);
			//set player direction
			if (joyPositionY < 0) {
				//joyPositionY = 0; 
			}

			transform.LookAt (new Vector3 (transform.forward.x + joyPositionX, transform.forward.y, transform.forward.z + joyPositionY)); 
			transform.Translate (0, 0,Time.deltaTime*1);
			//transform.localPosition = new Vector3(0, 0,transform.localPosition.z+Time.deltaTime*1);
		} */ 
	} 
} 

