using UnityEngine;
using System.Collections;

public enum itemType { faca, fio, chave, armario, armario_limp, radio, luvas, ralo, chave_fenda };

public class FacaScript : MonoBehaviour {

    public itemType item;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GetFaca()
    {
        switch(item)
        {
        case itemType.faca:
            Debug.Log("Pega a faca");
            Game.Data.itens[0][0] = true;
            Destroy(this.gameObject);
            Game.Data.Messages("Voce pegou uma faca");
            break;
        case itemType.fio:
            Debug.Log("Pega o fio");
            if(!Game.Data.itens[0][0])
            {
                Game.Data.Messages("Você precisa de algo para cortar esses fios.");
            }
            else
            {
                Game.Data.Messages("Voce usou a faca paga cortar um pedaco de fio para voce");
                Game.Data.itens[0][1] = true;
                Destroy(this.gameObject);
            }
            break;
        case itemType.armario:
            Debug.Log("Pega o pe de cabra");
            if(!Game.Data.itens[0][1])
            {
                Game.Data.Messages("Você não tem a combinação desse cofre. Mas pode arromba-lo de outra maneira.");
            }
            else
            {
                Game.Data.Messages("Apos abrir o cofre com uma ligação direta, voce achou um pe de cabra");
                Game.Data.itens[0][2] = true;
                Destroy(this.gameObject);
            }

            break;
        case itemType.chave:
            Debug.Log("pegou a chave");
            Game.Data.itens[1][0] = true;
            Destroy(this.gameObject);
            Game.Data.Messages("Voce pegou uma chave.");
            break;
        case itemType.armario_limp:
            Debug.Log("Pega o papel");
            if(!Game.Data.itens[1][0])
            {
                Game.Data.Messages("Esse armário está trancado. Você precisa de sua chave para abrí-lo.");
            }
            else
            {
                Game.Data.Messages("Voce conseguiu um papel com uma senha.");
                Game.Data.itens[1][1] = true;
                Destroy(this.gameObject);
            }

            break;
        case itemType.radio:
            Debug.Log("Pega o radio");
            if(!Game.Data.itens[1][1])
            {
                Game.Data.Messages("É necessario usar uma senha de acesso para esse radio.");
            }
            else
            {
                Game.Data.itens[1][2] = true;
                Destroy(this.gameObject);
                Game.Data.Messages("O radio esta sem sinal, mas voce vai leva-lo com voce.");
            }
            break;
        case itemType.luvas:
            Debug.Log("Pega as luvas");
            Game.Data.itens[2][0] = true;
            Destroy(this.gameObject);
            Game.Data.Messages("Voce pegou um par de luvas, parecem bem resistentes");
            break;
        case itemType.chave_fenda:
            if(!Game.Data.itens[2][0])
            {
                Game.Data.Messages("Você não pode colocar a mãos nuas dentro do ácido.");
            }
            else
            {
                Debug.Log("Pega o chave de fenda");
                Game.Data.Messages("Voce usou o par de luvas para pegar uma ferramenta que estava no balde de acido.");
                Game.Data.itens[2][1] = true;
                Destroy(this.gameObject);
            }

            break;
        case itemType.ralo:
            Debug.Log("Pega o ralo");
            if(!Game.Data.itens[2][1])
            {
                Game.Data.Messages("O ralo está parafusado ao chão.");
            }
            else
            {
                Game.Data.Messages("Voce usou a chave de fenda para destravar o ralo. Ele pode ser util a voce");
                Game.Data.itens[2][2] = true;
                Destroy(this.gameObject);
            }
            break;
        }

        if(Game.Data.itens[0][0] && Game.Data.itens[0][1] && Game.Data.itens[0][2] &&
            Game.Data.itens[1][0] && Game.Data.itens[1][1] && Game.Data.itens[1][2] && 
            Game.Data.itens[2][0] && Game.Data.itens[2][1] && Game.Data.itens[2][2])
        {

            int intSec = (int)Game.Data.tempoJogando;
            int seconds = intSec % 60; 
            int minutes = (intSec / 60) % 60; 

            var text = string.Format("{0}:{1}", minutes, seconds);
            PlayerPrefs.SetInt("pontos_jogador", (int)Game.Data.tempoJogando);
            PlayerPrefs.SetString("victory", "Voce sobreviveu ao supermax. Conseguiu fugir em "+text+" minutos.");
            PlayerPrefs.Save();
            Application.LoadLevelAsync("cena_vitoria");
        }
    }
}
