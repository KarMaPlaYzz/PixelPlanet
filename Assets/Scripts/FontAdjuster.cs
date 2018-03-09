using UnityEngine;
using UnityEngine.UI;

public class FontAdjuster : MonoBehaviour {

	public Text AboutUsText;

	Text thisobject;
	int fontsize;

	void Update () {

		thisobject = gameObject.GetComponent<Text> ();
		fontsize = AboutUsText.cachedTextGenerator.fontSizeUsedForBestFit;
		thisobject.fontSize = fontsize;
	}
}
