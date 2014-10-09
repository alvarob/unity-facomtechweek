using UnityEngine;
using System.Collections;

public class ControladorMovimento : MonoBehaviour {

	public float Speed = 6f;

	Rigidbody body;
	Vector3 movement;

	float distanciaRaio = 100f;
	int mascaraChao;

	void Awake() {
		body = GetComponent<Rigidbody>();

		// Salva qual é o layer "chão" para dar o Raycast no Virar()
		mascaraChao = LayerMask.GetMask("Chao");
	}

	void FixedUpdate() {
		// A ou <-  = -1
		// D ou >-  =  1
		float h = Input.GetAxisRaw("Horizontal");
		
		// Pra cima = 1
		// Pra baixo = -1
		float v = Input.GetAxisRaw("Vertical");

		Mover(h, v);
		Virar();
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

	void Virar() {
		// Raio partindo da câmera do ponto onde o mouse está
		Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);

		// 'Hit' que guardará a informação de onde o raio acertou
		RaycastHit hitChao;

		// Dá cast no raio, salvando a informação do hit em hitChao
		// usamos a mascaraChao pra ele só acertar o que estiver no layer "Chão"
		if (Physics.Raycast(raio, out hitChao, distanciaRaio, mascaraChao)) {

			// Direção = ponto do hit - posição atual do objeto
			Vector3 direcaoVirada = hitChao.point - transform.position;
			direcaoVirada.y = 0f; // Muda pra 0 para ele não girar em y

			Quaternion novaRotacao = Quaternion.LookRotation(direcaoVirada);
			body.MoveRotation(novaRotacao);
		}
	}

}
