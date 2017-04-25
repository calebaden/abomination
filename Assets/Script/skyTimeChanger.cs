using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skyTimeChanger : MonoBehaviour {

    public float[] tilingPositions;
    public float[] tilingPositionsEnd;
    public Renderer rend;
    public int currentStage;
    public int prevStage;
    public bool isMidStage;

    public Color[] colours;
    public Color[] coloursEnd;
    public GameObject Sunlight;
    public Vector3[] sunRotations;
    public Vector3[] sunRotationsEnd;
    public GameObject stars;
    public Vector3[] StarScale;
    public Vector3[] StarScaleEnd;
    public GameObject sunObject;
    public Vector3[] sunObjRots;
    public Vector3[] sunObjRotsEnd;
    public GameObject moonObject;
    public Vector3[] moonObjRots;
    public Vector3[] moonObjRotsEnd;
    public Renderer Car;
    public Color[] CarLights;
    public Color[] CarLightsEnd;
    public Color[] CarLightsEmition;
    public Color[] CarLightsEmitionEnd;
    public Light LeftHeadLight;
    public Light RightHeadLight;
    public float[] lightIntensities;
    public float[] lightIntensitiesEnd;

    public float StageTransitionTimer;
    public float lerpSpeedChangeStage;
    public float lerpSpeedMidStage;
    public float lerpMidStageTimer;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		//if(Input.GetKeyDown(KeyCode.T) && isMidStage)
  //      {
  //          progressStage(currentStage+1);
  //          //LeftHeadLight.intensity = 0;
  //      }
        if(isMidStage)
        {
            lerpMidStageTimer += Time.deltaTime;
            rend.material.mainTextureScale = new Vector2(Mathf.Lerp(tilingPositions[currentStage], tilingPositionsEnd[currentStage], lerpMidStageTimer / lerpSpeedMidStage), 1);
            Sunlight.GetComponent<Light>().color = Color.Lerp(colours[currentStage], coloursEnd[currentStage], lerpMidStageTimer / lerpSpeedMidStage);
            Sunlight.transform.rotation = Quaternion.Lerp(Quaternion.Euler(sunRotations[currentStage]), Quaternion.Euler(sunRotationsEnd[currentStage]), lerpMidStageTimer / lerpSpeedMidStage);
            stars.transform.localScale = Vector3.Lerp(StarScale[currentStage], StarScaleEnd[currentStage], lerpMidStageTimer / lerpSpeedMidStage);
            sunObject.transform.rotation = Quaternion.Lerp(Quaternion.Euler(sunObjRots[currentStage]), Quaternion.Euler(sunObjRotsEnd[currentStage]), lerpMidStageTimer / lerpSpeedMidStage);
            moonObject.transform.rotation = Quaternion.Lerp(Quaternion.Euler(moonObjRots[currentStage]), Quaternion.Euler(moonObjRotsEnd[currentStage]), lerpMidStageTimer / lerpSpeedMidStage);
            Car.materials[2].color = Color.Lerp(CarLights[currentStage], CarLightsEnd[currentStage], lerpMidStageTimer / lerpSpeedMidStage);
            Car.materials[2].SetColor("_EmissionColor", Color.Lerp(CarLightsEmition[currentStage], CarLightsEmitionEnd[currentStage], lerpMidStageTimer / lerpSpeedMidStage));
            LeftHeadLight.intensity = Mathf.Lerp(lightIntensities[currentStage], lightIntensitiesEnd[currentStage], lerpMidStageTimer / lerpSpeedMidStage);
            RightHeadLight.intensity = Mathf.Lerp(lightIntensities[currentStage], lightIntensitiesEnd[currentStage], lerpMidStageTimer / lerpSpeedMidStage);
            print("midstage code");
            
        }
        else
        {
            rend.material.mainTextureScale = new Vector2(Mathf.Lerp(rend.material.mainTextureScale.x, tilingPositions[currentStage], lerpSpeedChangeStage * Time.deltaTime), 1);
            Sunlight.GetComponent<Light>().color = Color.Lerp(Sunlight.GetComponent<Light>().color, colours[currentStage], lerpSpeedChangeStage * Time.deltaTime);
            Sunlight.transform.rotation = Quaternion.Lerp(Sunlight.transform.rotation, Quaternion.Euler(sunRotations[currentStage]), lerpSpeedChangeStage * Time.deltaTime);
            stars.transform.localScale = Vector3.Lerp(stars.transform.localScale, StarScale[currentStage], lerpSpeedChangeStage * Time.deltaTime);
            sunObject.transform.rotation = Quaternion.Lerp(sunObject.transform.rotation, Quaternion.Euler(sunObjRots[currentStage]), lerpSpeedChangeStage * Time.deltaTime);
            moonObject.transform.rotation = Quaternion.Lerp(moonObject.transform.rotation, Quaternion.Euler(moonObjRots[currentStage]), lerpSpeedChangeStage * Time.deltaTime);
            Car.materials[2].color= Color.Lerp(Car.materials[2].color, CarLights[currentStage], lerpSpeedChangeStage * Time.deltaTime);
            Car.materials[2].SetColor("_EmissionColor", Color.Lerp(Car.materials[2].GetColor("_EmissionColor"), CarLightsEmition[currentStage], lerpSpeedChangeStage * Time.deltaTime));
            LeftHeadLight.intensity = Mathf.Lerp(LeftHeadLight.intensity, lightIntensities[currentStage], lerpSpeedChangeStage * Time.deltaTime);
            RightHeadLight.intensity = Mathf.Lerp(RightHeadLight.intensity, lightIntensities[currentStage], lerpSpeedChangeStage * Time.deltaTime);
            StageTransitionTimer += Time.deltaTime;
            if (StageTransitionTimer >= lerpSpeedChangeStage)
            {
                isMidStage = true;
                lerpMidStageTimer = 0;
                StageTransitionTimer = 0;
            }
            
        }
       
    }
    public void progressStage(int ToStage)
    {
        prevStage = currentStage;
        currentStage = ToStage;
        
        if (currentStage > 2)
        {
            currentStage = 0;
        }
        if (prevStage > 2)
        {
            prevStage = 0;
        }
        isMidStage = false;
    }
}
