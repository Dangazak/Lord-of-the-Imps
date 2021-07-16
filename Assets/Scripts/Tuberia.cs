using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuberia : MonoBehaviour {

	public GameObject otraTuberia;
	Tuberia otraTuberiaScr;
	bool ocupada;
	GameObject imp;
	Rigidbody2D impBody;

	// Use this for initialization
	void Start () {
		otraTuberiaScr = otraTuberia.GetComponent<Tuberia> ();
	}

	// Update is called once per frame
	void Update () {
		if (imp != null) {
			impBody = imp.GetComponent<Rigidbody2D> ();
			if (impBody.velocity.x < 0 && impBody.position.x < transform.position.x && !otraTuberiaScr.ocupada && transform.localScale.x == -1) {
				impBody.position = new Vector2 (otraTuberia.transform.position.x, otraTuberia.transform.position.y);
				ocupada = false;
				imp = null;
			}
			else if (impBody.velocity.x > 0 && impBody.position.x > transform.position.x && !otraTuberiaScr.ocupada && transform.localScale.x == 1) {
				impBody.position = new Vector2 (otraTuberia.transform.position.x, otraTuberia.transform.position.y);
				ocupada = false;
				imp = null;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.attachedRigidbody.tag == "ImpP" && other.attachedRigidbody.gameObject.activeInHierarchy && imp == null) {
			ocupada = true;
			imp = other.attachedRigidbody.gameObject;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.attachedRigidbody.tag == "ImpP" && other.attachedRigidbody.gameObject.activeInHierarchy && imp != null) {
			ocupada = false;
			imp = null;
		}
	}
}