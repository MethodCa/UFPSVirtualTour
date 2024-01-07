var target : Transform;
var manoDerecha : Transform;
var manoIzquierda: Transform;
var caderaDerecha: Transform;
var caderaIzquierda: Transform;
var pos: GUIText;
var posText: GUIText;
var velocidad=15f;


private var motor : CharacterMotor;

// Use this for initialization
function Awake () {
	motor = GetComponent(CharacterMotor);
}

// Update is called once per frame
function Update () {
	// Get the input vector from keyboard or analog stick
	//var directionVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
	
	//posText.text="Horizontal= "+Input.GetAxis("Horizontal")+ " , vertical= "+Input.GetAxis("Vertical");
	var vertical= (caderaIzquierda.position.z*-1 - manoIzquierda.position.z*-1)* 0.7;
	var horizontal= (caderaIzquierda.position.x*-1 - manoIzquierda.position.x*-1)* 0.7;

    
    var absV=(Mathf.Abs(vertical));
    var absH=(Mathf.Abs(horizontal));
   
    if(absV<=0.15)
    	vertical=0;
    if(absH<= 0.15)
    	horizontal=0;
    var directionVector = new Vector3(horizontal*velocidad, 0, vertical*velocidad);
	
	
	
	
	if (directionVector != Vector3.zero) {
		// Get the length of the directon vector and then normalize it
		// Dividing by the length is cheaper than normalizing when we already have the length anyway
		var directionLength = directionVector.magnitude;
		directionVector = directionVector / directionLength;
		
		// Make sure the length is no bigger than 1
		directionLength = Mathf.Min(1, directionLength);
		
		// Make the input vector more sensitive towards the extremes and less sensitive in the middle
		// This makes it easier to control slow speeds when using analog sticks
		directionLength = directionLength * directionLength;
		
		// Multiply the normalized direction vector by the modified length
		directionVector = directionVector * directionLength;
	}
	
	// Apply the direction to the CharacterMotor
	motor.inputMoveDirection = transform.rotation * directionVector;
	motor.inputJump = Input.GetButton("Jump");
}

// Require a character controller to be attached to the same game object
@script RequireComponent (CharacterMotor)
@script AddComponentMenu ("Character/FPS Input Controller")