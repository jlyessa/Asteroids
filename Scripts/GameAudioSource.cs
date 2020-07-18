using UnityEngine;

public class GameAudioSource : MonoBehaviour
{
	void Awake()
	{
		AudioSource audioSource = gameObject.AddComponent<AudioSource>();
		AudioManager.Initialize(audioSource);
	}
}
