using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Orbe : MonoBehaviour
{

    public GameObject ventana;
    bool usado = true;
    private AudioSource source;
    public AudioClip sonFin;

    // Use this for initialization
    void Start()
    {
        //GameControl.control.reset ();
        //GameControl.control.controlActive = true;
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        /*if (other.attachedRigidbody.tag == "Imp"  && usado) {
			ventana.SetActive (true);
			GameControl.control.controlActive = false;
			Imp impBody = other.gameObject.GetComponent<Imp> ();
			impBody.Stop ();
		}
		else if(other.attachedRigidbody.tag == "ImpP" && usado){
			ventana.SetActive (true);
			GameControl.control.controlActive = false;
			ImpP impBody = other.gameObject.GetComponent<ImpP> ();
			impBody.Stop ();
		}
		else if(other.attachedRigidbody.tag == "ImpG" && usado){
			ventana.SetActive (true);
			GameControl.control.controlActive = false;
			ImpG impBody = other.gameObject.GetComponent<ImpG> ();
			impBody.Stop ();
		}
		else if(other.attachedRigidbody.tag == "ImpV" && usado){
			ventana.SetActive (true);
			GameControl.control.controlActive = false;
			ImpV impBody = other.gameObject.GetComponent<ImpV> ();
			impBody.Stop ();
		}
		if (usado) {
			usado = false;
			if (GameControl.control.sonidoActivo) {
				source.PlayOneShot (sonFin, GameControl.control.volumen);
			}
			GameControl.control.diabInvTot += GameControl.control.diabInvLvl;
			GameControl.control.diabMuerTot += GameControl.control.diabMuerLvl;
			GameControl.control.numOrdUseTot += GameControl.control.numOrdUseLvl;
			GameControl.control.numSwipeTot += GameControl.control.numSwipeLvl;
			GameControl.control.numFlipTot += GameControl.control.numFlipLvl;
			GameControl.control.numJumpTot += GameControl.control.numJumpLvl;
			GameControl.control.numStopTot += GameControl.control.numStopLvl;
			GameControl.control.timeTot += GameControl.control.timeLvl;
			GameControl.control.diabT0InvTot += GameControl.control.diabT0InvLvl;
			GameControl.control.diabT1InvTot += GameControl.control.diabT1InvLvl;
			GameControl.control.diabT2InvTot += GameControl.control.diabT2InvLvl;
			GameControl.control.diabT3InvTot += GameControl.control.diabT3InvLvl;
			GameControl.control.diabMuerT0Tot += GameControl.control.diabMuerT0Lvl;
			GameControl.control.diabMuerT1Tot += GameControl.control.diabMuerT1Lvl;
			GameControl.control.diabMuerT2Tot += GameControl.control.diabMuerT2Lvl;
			GameControl.control.diabMuerT3Tot += GameControl.control.diabMuerT3Lvl;
			//save lvl prog
			Scene escena = SceneManager.GetActiveScene ();
			int sceneIndex = escena.buildIndex;
			GameControl.control.scores [sceneIndex - 1] = 1;
			if (GameControl.control.diabMuerLvl == 0) {
				GameControl.control.scores [sceneIndex - 1]++;
			}
			if (GameControl.control.timeLvl <= GameControl.control.timLvlMax [sceneIndex - 1]) {
				GameControl.control.scores [sceneIndex - 1]++;
			}
			Debug.Log ("order save sent");
			GameControl.control.Save ();
		}*/
    }
}
