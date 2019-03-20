using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{

	[SerializeField]
	private float speed = 5f;
	[SerializeField]
	private float lookSensitivity = 3f;

	private PlayerMotor motor;

    void Start()
    {
		motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
		//calcul du vecteur de déplacement du joueur
		float _xMov = Input.GetAxisRaw("Horizontal");
		float _zMov = Input.GetAxisRaw("Vertical");

		Vector3 _movHorizontal = transform.right * _xMov;
		Vector3 _movVertical = transform.forward * _zMov;

		Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;

		//application du vecteur de déplacement
		motor.Move(_velocity);

		//calcul de la rotation autour de y (pour tourner le joueur)
		float _yRot = Input.GetAxisRaw("Mouse X");

		Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensitivity;

		//application du vecteur de rotation sur y
		motor.Rotate(_rotation);

		//calcul de la rotation autour de x (pour orienter la camera verticalement)
		float _xRot = Input.GetAxisRaw("Mouse Y");

		Vector3 _cameraRotation = new Vector3(_xRot, 0f, 0f) * lookSensitivity;

		//application du vecteur de rotation sur x
		motor.RotateCamera(_cameraRotation);
    }
}
