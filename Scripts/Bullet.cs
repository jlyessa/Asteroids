using UnityEngine;

public class Bullet : MonoBehaviour
{
	const float LifeSeconds = 1;
	Timer deathTimer;

	void Start()
	{
		deathTimer = gameObject.AddComponent<Timer>();
		deathTimer.Duration = LifeSeconds;
		deathTimer.Run();
	}
	
	void Update()
	{
		if (deathTimer.Finished)
			Destroy(gameObject);
	}

	public void ApplyForce(Vector2 forceDirection)
	{
		const float forceMagnitude = 10;
		GetComponent<Rigidbody2D>().AddForce(
			forceMagnitude * forceDirection,
			ForceMode2D.Impulse);
	}
}
