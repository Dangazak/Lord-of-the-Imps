using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{

    public void RestartLvl()
    {
        Scene escena = SceneManager.GetActiveScene();
        int sceneIndex = escena.buildIndex;
        //GameControl.control.StopMusic ();
        SceneManager.LoadScene(sceneIndex);
        /*GameControl.control.diabInvTot += GameControl.control.diabInvLvl;
		GameControl.control.diabMuerTot += GameControl.control.diabMuerLvl;
		GameControl.control.numOrdUseTot += GameControl.control.numOrdUseLvl;
		GameControl.control.numSwipeTot += GameControl.control.numSwipeLvl;
		GameControl.control.numFlipTot += GameControl.control.numFlipLvl;
		GameControl.control.numJumpTot += GameControl.control.numJumpLvl;
		GameControl.control.numStopTot += GameControl.control.numStopLvl;
		GameControl.control.timeTot += GameControl.control.timeLvl;
		GameControl.control.timeTot += GameControl.control.timeLvl;
		GameControl.control.diabT0InvTot += GameControl.control.diabT0InvLvl;
		GameControl.control.diabT1InvTot += GameControl.control.diabT1InvLvl;
		GameControl.control.diabT2InvTot += GameControl.control.diabT2InvLvl;
		GameControl.control.diabT3InvTot += GameControl.control.diabT3InvLvl;
		GameControl.control.diabMuerT0Tot += GameControl.control.diabMuerT0Lvl;
		GameControl.control.diabMuerT1Tot += GameControl.control.diabMuerT1Lvl;
		GameControl.control.diabMuerT2Tot += GameControl.control.diabMuerT2Lvl;
		GameControl.control.diabMuerT3Tot += GameControl.control.diabMuerT3Lvl;*/
    }
}
