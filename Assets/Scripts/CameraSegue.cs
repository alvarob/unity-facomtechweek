using UnityEngine;
using System.Collections;

public class CameraSegue : MonoBehaviour {

	public Transform alvo;
	public float smoothing = 5f;

	Vector3 distanciaDoAlvo;

	void Start() {
		// Salva a distância inicial, pra usar sempre a mesma
		distanciaDoAlvo = transform.position - alvo.position;
	}
	
	void FixedUpdate() {
		// Calcula a nova posição (poisição do alvo + distância inicial)
		Vector3 posicaoAlvo = alvo.position + distanciaDoAlvo;

		// Move para a nova posição usando Lerp
		transform.position = Vector3.Lerp(transform.position, posicaoAlvo, smoothing * Time.deltaTime);
	}
}
