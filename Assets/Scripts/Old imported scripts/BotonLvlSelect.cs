using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonLvlSelect : MonoBehaviour
{
    public int lvlNum;
    public GameObject stars;
    SpriteRenderer sprite;
    public Sprite zeroStars;
    public Sprite oneStars;
    public Sprite twoStars;
    public Sprite threeStars;
    UnityEngine.UI.Button boton;


    // Use this for initialization
    void Start()
    {
        /*boton = GetComponent<UnityEngine.UI.Button> ();
		sprite = stars.GetComponent<SpriteRenderer> ();

		if (lvlNum > 1) {
			if (GameControl.control.scores [lvlNum - 2] == 0) {
				boton.enabled = false;
			}
		}
		if (GameControl.control.scores [lvlNum - 1] == 0) {
			sprite.sprite = zeroStars;
		} else if (GameControl.control.scores [lvlNum - 1] == 1) {
			sprite.sprite = oneStars;
		} else if (GameControl.control.scores [lvlNum - 1] == 2) {
			sprite.sprite = twoStars;
		} else if (GameControl.control.scores [lvlNum - 1] == 3) {
			sprite.sprite = threeStars;
		}*/
    }

}
