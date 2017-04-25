using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlimpWobble : MonoBehaviour {

    public float intensity = 0.5f;
    public float timescale = 1.3f;
    public AnimationCurve ease = AnimationCurve.EaseInOut(0,0,1,1);

    Vector3 startPos;
    float wobbletime = 0;
    Vector3 wobblePos;
    Vector3 prevPos;
    Transform myTransform;

    void Awake()
    {
        myTransform = transform;
        startPos = myTransform.localPosition;
        prevPos = startPos;
        RandomisePosition();
    }

	void FixedUpdate () {
        wobbletime += Time.fixedDeltaTime / timescale;
        if (wobbletime > 1)
        {
            wobbletime -= 1f;
            prevPos = wobblePos;
            RandomisePosition();
        }

        myTransform.localPosition = Vector3.LerpUnclamped(prevPos, wobblePos, ease.Evaluate(wobbletime));
	}

    void RandomisePosition ()
    {
        wobblePos = new Vector3(Random.Range(-intensity, intensity), Random.Range(-intensity, intensity), 0);
        wobblePos += startPos;
    }
}
