using UnityEngine;
using System.Collections;

/// MouseLook rotates the transform based on the mouse delta.
/// Minimum and Maximum values can be used to constrain the possible rotation

/// To make an FPS style character:
/// - Create a capsule.
/// - Add the MouseLook script to the capsule.
///   -> Set the mouse look to use LookX. (You want to only turn character but not tilt it)
/// - Add FPSInputController script to the capsule
///   -> A CharacterMotor and a CharacterController component will be automatically added.

/// - Create a camera. Make the camera a child of the capsule. Reset it's transform.
/// - Add a MouseLook script to the camera.
///   -> Set the mouse look to use LookY. (You want the camera to tilt up and down like a head. The character already turns.)
[AddComponentMenu("Camera-Control/Mouse Look")]
public class kinectLook : MonoBehaviour {

	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX = 15F;
	public float sensitivityY = 15F;

	public float minimumX = -360F;
	public float maximumX = 360F;

	public float minimumY = -60F;
	public float maximumY = 60F;

	public Transform target;
	public Transform manoDerecha;
	public Transform manoIzquierda;
	public Transform caderaDerecha;
	public Transform caderaIzquierda;
	public Transform pos;
	public Transform posText;



	float rotationY = 0F;

	void Update ()
	{
		if (axes == RotationAxes.MouseXAndY)
		{
			float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
			
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			
			transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
		}
		else if (axes == RotationAxes.MouseX)
		{
		

			float horizontal= (caderaDerecha.position.x*-1 - manoDerecha.position.x*-1);
			float y=(caderaDerecha.position.y*-1 - manoDerecha.position.y*-1);

			float absH=(Mathf.Abs(horizontal));
			if(horizontal<0)
				horizontal*=2;
			//if(y>= 0.15)
				transform.Rotate(0, horizontal * sensitivityX, 0);
		

		
		}
		else
		{
			float vertical=  ((caderaDerecha.position.y*-1 - manoDerecha.position.y*-1));
			float y=(caderaDerecha.position.y*-1 - manoDerecha.position.y*-1);
			posText.guiText.text="rotar y: "+vertical.ToString()+ "  pos y: "+y;
			float absV=(Mathf.Abs(vertical));

			//if(y>= 0.16)
			{

				rotationY += vertical * sensitivityY;
				rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
				transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
			}
			pos.guiText.text=("Mano izq: "+manoIzquierda.position.x+" , "+manoIzquierda.position.y+ ", "+manoIzquierda.position.z+"\n"+"Mano der: "+ manoDerecha.position.x+" , "+manoDerecha.position.y+ ", "+manoDerecha.position.z+"\n"+"Cadera izq: "+ caderaIzquierda.position.x+" , "+caderaIzquierda.position.y+ ", "+caderaIzquierda.position.z+"\n"+"Cadera der: "+ caderaDerecha.position.x+" , "+caderaDerecha.position.y+ ", "+caderaDerecha.position.z);

		}
	}
	
	void Start ()
	{
		// Make the rigid body not change rotation
		if (rigidbody)
			rigidbody.freezeRotation = true;
	}
}