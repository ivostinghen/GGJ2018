using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ativa_portao : MonoBehaviour {

	public Animator puxador_anim;
	public Animator engrenagem_anim;
	public Animator portao;
	public float tempoAtivo;
	private float tempo;
	private bool dentro;
	private bool alavancaAtiva;
	private bool ativado;

	void Start(){
		ativado = false;
		alavancaAtiva = false;
	}

	void Update(){
		if (dentro && !alavancaAtiva){
			//pode trocar o input aqui
			if (Input.GetButtonDown("Fire2"))
			{
				alavancaAtiva = true;
				StartCoroutine (EsperarTempo ());
			}
		}

		puxador_anim.SetBool ("alavanca_ativa", alavancaAtiva);
		engrenagem_anim.SetBool ("alavanca_ativa", alavancaAtiva);
		portao.SetBool ("alavanca_ativa", alavancaAtiva);

	}

	void LateUpdate(){
		dentro = false;
	}

	IEnumerator EsperarTempo(){
		yield return new WaitForSeconds (tempoAtivo);
		print ("acabou");
		alavancaAtiva = false;
	}

	void OnTriggerStay(Collider col){
		if (col.gameObject.layer == 10) {
			dentro = true;
            print(dentro);
        }
	}
}
