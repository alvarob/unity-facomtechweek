using UnityEngine;
using System.Collections;

public class ScriptCor : MonoBehaviour {

	// Variável pública para escolher a cor,
	// por ser pública, o seletor de cor aparece
	// no 'Inspector' do Unity
	public Color cor; 

	// 'MeshRenderer' é a classe responsável por desenhar
	// objetos na tela
	MeshRenderer rend; 

	// Awake é o que roda quando o objeto é inicializado
	void Awake() {

		// GetComponent<ClasseDoComponente> retorna o componete
		// Desse tipo que está no objeto (no objeto onde o script
		// foi colocado)
		// Aqui pegamos o MeshRenderer, para salvar a referência para o mesmo
		rend = GetComponent<MeshRenderer>();

		// mudando a cor do material do meshrenderer, a cor do objeto será mudada
		// (cor aqui é a variável pública, que escolhemos o valor no inspector)
		rend.material.color = cor;
	}
}
