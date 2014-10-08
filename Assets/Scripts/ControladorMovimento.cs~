using UnityEngine;
using System.Collections;

public class ControladorMovimento : MonoBehaviour {

	public float Speed = 6f;

	Rigidbody body;
	Vector3 movement;

	void Awake() {
		body = GetComponent<Rigidbody>();
	}

	void FixedUpdate() {
		// A ou <-  = -1
		// D ou >-  =  1
		float h = Input.GetAxisRaw("Horizontal");
		
		// Pra cima = 1
		// Pra baixo = -1
		float v = Input.GetAxisRaw("Vertical");

		Mover(h, v);
	}

	void Mover(float h, float v) {
		movement.Set(h, 0f, v);  // Vetor (h, 0, v)

		// Time.deltaTime = retorna quantos segundos se passaram desde o último update.
		// .normalized é pra transformar o vetor em um vetor unitário na direção que desejamos mover
		// Multiplicando (escalar) o vetor pela velocidade e o deltaTime, temos o quanto queremos mover naquela direção
		movement = movement.normalized * Speed * Time.deltaTime;
		
		// transform.position é a posição do objeto.
		// Somamos isso ao vetor "movement" obtido acima
		// para mover o personagem.
		body.MovePosition(transform.position + movement);
	}

}
