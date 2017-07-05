using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelİmage : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(ScaleOverTime(1));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator ScaleOverTime(float time)
    {
        Vector3 originalScale = transform.localScale;
        Vector3 destinationScale = new Vector3(1f, 1f, 1f);

        float currentTime = 0.0f;

        do
        {
            transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);

        
    }
}
