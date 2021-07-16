using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonStart : MonoBehaviour
{

    //public GameObject titulo;
    public GameObject ventana;
    public GameObject fade;

    public void iniciarJuegoDelayed()
    {
        Invoke("iniciarJuego", 0.5f);
    }

    public void iniciarJuego()
    {
        /*GameControl.control.StopMusic ();
		if (GameControl.control.scores [0] == 0) {
			SceneManager.LoadScene (1);
		} else {
			//if (GameControl.control.scores [19] != 0) {
			//	SceneManager.LoadScene (1);
			//} else {
			//	for (int i = 0; i < 20; i++) {
			//		if (GameControl.control.scores [i] == 0) {
			//			SceneManager.LoadScene (i + 1);
			//			break;
			//		}
			//	}
			//}

			//titulo.SetActive (false);
			ventana.SetActive (true);

			Animator anim = fade.GetComponent<Animator> ();
			anim.SetTrigger ("In");
		}*/
    }
}
