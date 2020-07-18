using UnityEngine;

public class Ship : MonoBehaviour
{
	Rigidbody2D rb2D;
	Vector2 thrustDirection = new Vector2(1, 0);
	const float ThrustForce = 10;
	const float RotateDegreesPerSecond = 180;

	[SerializeField]
	GameObject prefabBullet;

	[SerializeField]
	GameObject hud;

	void Start()
	{
		rb2D = GetComponent<Rigidbody2D>();
	}
	
	void Update()
	{
		float rotationInput = Input.GetAxis("Rotate");
		if (rotationInput != 0) 
		{
			float rotationAmount = RotateDegreesPerSecond * Time.deltaTime;
			if (rotationInput < 0)
				rotationAmount *= -1;
			transform.Rotate(Vector3.forward, rotationAmount);

			float zRotation = transform.eulerAngles.z * Mathf.Deg2Rad;
			thrustDirection.x = Mathf.Cos(zRotation);
			thrustDirection.y = Mathf.Sin(zRotation);
		}

		if (Input.GetKeyDown(KeyCode.LeftControl))
		{
			GameObject bullet = Instantiate(prefabBullet, transform.position, Quaternion.identity);
			Bullet script = bullet.GetComponent<Bullet>();
			script.ApplyForce(thrustDirection);
			AudioManager.Play(AudioClipName.PlayerShot);
		}
	}

	void FixedUpdate()
	{
		if (Input.GetAxis("Thrust") != 0)
			rb2D.AddForce(ThrustForce * thrustDirection,
				ForceMode2D.Force);
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.CompareTag("Asteroid"))
		{
			AudioManager.Play(AudioClipName.PlayerDeath);
			hud.GetComponent<HUD>().StopGameTimer();
			Destroy(gameObject);
		}
	}
}
