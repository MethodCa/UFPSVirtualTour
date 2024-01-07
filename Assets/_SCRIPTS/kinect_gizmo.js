var head : Transform;
var hombro_izquierdo : Transform;
var hombro_derecho: Transform;
var mano_izquierda : Transform;
var mano_derecha: Transform;
var _cabeza : GUITexture;
var _hombroDerecho : GUITexture;
var _hombroIzquierdo: GUITexture;
var _manoDerecha : GUITexture;
var _manoIzquierda: GUITexture;


private var motor : CharacterMotor;

// Use this for initialization
function Awake () {
	motor = GetComponent(CharacterMotor);
}

// Update is called once per frame
function Update () {
	
			
	_cabeza.pixelInset.x=head.position.x*100;
	_cabeza.pixelInset.y=head.position.y*100;
	
	
	_hombroDerecho.pixelInset.x=hombro_derecho.position.x*100+5;
	_hombroDerecho.pixelInset.y=hombro_derecho.position.y*100+5;
	
	_hombroIzquierdo.pixelInset.x=hombro_izquierdo.position.x*100+5;
	_hombroIzquierdo.pixelInset.y=hombro_izquierdo.position.y*100+5;
	
	_manoIzquierda.pixelInset.x=mano_izquierda.position.x*100+6;
	_manoIzquierda.pixelInset.y=mano_izquierda.position.y*100+6;
	
	_manoDerecha.pixelInset.x=mano_derecha.position.x*100+6;
	_manoDerecha.pixelInset.y=mano_derecha.position.y*100+6;
	
	
}

// Require a character controller to be attached to the same game object
@script RequireComponent (CharacterMotor)
@script AddComponentMenu ("Character/FPS Input Controller")

