/*
This camera smoothes out rotation around the y-axis and height.
Horizontal Distance to the target is always fixed.

There are many different ways to smooth the rotation but doing it this way gives you a lot of control over how the camera behaves.

For every of those smoothed values we calculate the wanted value and the current value.
Then we smooth it using the Lerp function.
Then we apply the smoothed values to the transform's position.
*/

// The target we are following
var target : Transform;
var manoDerecha : Transform;
var manoIzquierda: Transform;
var caderaDerecha: Transform;
var caderaIzquierda: Transform;
var pos: GUIText;
var posText: GUIText;

// The distance in the x-z plane to the target
var distance = 0.1;
// the height we want the camera to be above the target
var height = 5.0;
// How much we 
var heightDamping = 2.0;
var rotationDamping = 3.0;
var caminar =false;

// Place the script in the Camera-Control group in the component menu
@script AddComponentMenu("Camera-Control/Smooth Follow")


function LateUpdate () {


   var moverAdelante= caderaIzquierda.position.z*-1 - manoIzquierda.position.z*-1;
   var moverAtras= manoIzquierda.position.z*-1 -  caderaIzquierda.position.z*-1;
	

	var moverCamara=manoDerecha.position.y - caderaDerecha.position.y;
	var moverX= manoDerecha.position.x - caderaDerecha.position.x;

	transform.Rotate(0, Input.GetAxis("Mouse X") * 15F, 0);
	if(moverAdelante>=0.18)
		{
	
			
			transform.position.z= transform.position.z + distance;
		
		}
		else
			if(moverAtras>=0.1)
				transform.position += Vector3.back * distance;


}