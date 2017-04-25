using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scenechooser : MonoBehaviour {

    private int selector;

    public GameObject FollowCam;
    public GameObject DriveCam;

    public GameObject CruiseSet;
    public GameObject DriveSet;

    public GameObject AnimCar;
    public GameObject DriveCar;

    void Start () {
        selector = PlayerPrefs.GetInt("MenuCHoice");

        if (selector == 1)
        {
            Drive();
        }

        if (selector == 2)
        {
            Cruise();
        }
	}
	
	void Drive()
    {
        FollowCam.SetActive(false);
        DriveCam.SetActive(true);

        DriveSet.SetActive(true);
        CruiseSet.SetActive(false);

        FollowCam.GetComponent<SmoothFOllow>().target = DriveCar.transform;

    }

    void Cruise()
    {
        FollowCam.SetActive(true);
        DriveCam.SetActive(false);

        CruiseSet.SetActive(true);
        DriveSet.SetActive(false);

        FollowCam.GetComponent<SmoothFOllow>().target = AnimCar.transform;
    }
}
