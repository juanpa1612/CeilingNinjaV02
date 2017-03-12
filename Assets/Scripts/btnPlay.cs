using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class btnPlay : MonoBehaviour
{
	[SerializeField]
	private Button play;
	[SerializeField]
	private SoundDontDestroySingle script;

	public void JugarNivel ()
	{
		StartCoroutine(DontActuallyStart());
		play.interactable = false;
		script.PlaySound ();
    }

	IEnumerator DontActuallyStart ()
	{
		yield return new WaitForSeconds(3);
		SceneManager.LoadScene("LoadingScene",LoadSceneMode.Single);
	}

}
