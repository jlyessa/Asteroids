using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{
	float colliderRadius;

	void Start()
	{
		colliderRadius = gameObject.GetComponent<CircleCollider2D>().radius;
	}

	void OnBecameInvisible()
	{
		Vector2 location = transform.position;

		if (location.x + colliderRadius < ScreenUtils.ScreenLeft ||
			location.x - colliderRadius > ScreenUtils.ScreenRight)
			location.x *= -1;
		if (location.y - colliderRadius > ScreenUtils.ScreenTop ||
			location.y + colliderRadius < ScreenUtils.ScreenBottom)
			location.y *= -1;

		transform.position = location;
	}
}
