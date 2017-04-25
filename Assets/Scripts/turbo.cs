using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turbo : MonoBehaviour {

    private bool TURBOBOOL;

    private float DriveorCruise;
    private bool Driving;
    private bool Cruising;

    public GameObject animcam;
    public GameObject drivecam;

    private float Colourshiftvalue;
    private float GLitchIntensity;


    public GameObject AnimCar;
    public GameObject DriveCar;

    

    void Start ()
    {
        DriveorCruise = PlayerPrefs.GetInt("MenuCHoice");

        if (DriveorCruise == 1)
        {
            Driving = true;
            Cruising = false;
        }


        if (DriveorCruise == 2)
        {
            Driving = false;
            Cruising = true;
        }
        
    }
	
	void Update ()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.LoadLevel("menu");
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
            {
            TURBOBOOL = true;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
            TURBOBOOL = false;
            }

        //THE DRIVING SEGMENT

        if (Driving)
        {
            if (TURBOBOOL)
            {

                //CAMERA EFFECTS
                if (drivecam.GetComponent<UnityStandardAssets.ImageEffects.BloomOptimized>().intensity <= 1.2f)
                {
                    drivecam.GetComponent<UnityStandardAssets.ImageEffects.BloomOptimized>().intensity += 0.05f;
                }


                if (drivecam.GetComponent<RetroAesthetics.RetroCameraEffect>().chromaticAberration <= 19)
                {
                    drivecam.GetComponent<RetroAesthetics.RetroCameraEffect>().chromaticAberration += 1;
                }

                //Speed Effects

                if (DriveCar.GetComponent<UnityStandardAssets.Vehicles.Car.CarController>().m_FullTorqueOverAllWheels <= 15000)
                {
                    DriveCar.GetComponent<UnityStandardAssets.Vehicles.Car.CarController>().m_FullTorqueOverAllWheels += 500;
                }
                if (DriveCar.GetComponent<UnityStandardAssets.Vehicles.Car.CarController>().m_Topspeed <= 180)
                {
                    DriveCar.GetComponent<UnityStandardAssets.Vehicles.Car.CarController>().m_Topspeed += 5;
                }
                


            }

            else
            {

                //CAMERA EFFECTS
                if (drivecam.GetComponent<UnityStandardAssets.ImageEffects.BloomOptimized>().intensity >= 0.5f)
                {
                    drivecam.GetComponent<UnityStandardAssets.ImageEffects.BloomOptimized>().intensity -= 0.08f;
                }


                if (drivecam.GetComponent<RetroAesthetics.RetroCameraEffect>().chromaticAberration >= 5)
                {
                    drivecam.GetComponent<RetroAesthetics.RetroCameraEffect>().chromaticAberration -= 2;
                }

                //Speed Effects

                if (DriveCar.GetComponent<UnityStandardAssets.Vehicles.Car.CarController>().m_FullTorqueOverAllWheels >= 10000)
                {
                    DriveCar.GetComponent<UnityStandardAssets.Vehicles.Car.CarController>().m_FullTorqueOverAllWheels -= 500;
                }

                if (DriveCar.GetComponent<UnityStandardAssets.Vehicles.Car.CarController>().m_Topspeed >= 150)
                {
                    DriveCar.GetComponent<UnityStandardAssets.Vehicles.Car.CarController>().m_Topspeed -= 5;
                }

            }
        }

       //THE CRUISING SEGMENT

       if (Cruising)
        {
            if (TURBOBOOL)
            {

                //CAMERA EFFECTS
                if (animcam.GetComponent<UnityStandardAssets.ImageEffects.BloomOptimized>().intensity <= 1.2f)
                {
                    animcam.GetComponent<UnityStandardAssets.ImageEffects.BloomOptimized>().intensity += 0.05f;
                }


                if (animcam.GetComponent<RetroAesthetics.RetroCameraEffect>().chromaticAberration <= 19)
                {
                    animcam.GetComponent<RetroAesthetics.RetroCameraEffect>().chromaticAberration += 1;
                }

                //Speed Effects

                if (AnimCar.GetComponent<UnitySteer.Behaviors.AutonomousVehicle>().MaxForce <= 45)
                {
                    AnimCar.GetComponent<UnitySteer.Behaviors.AutonomousVehicle>().MaxForce += 1;
                }

                if (AnimCar.GetComponent<UnitySteer.Behaviors.AutonomousVehicle>().MaxSpeed <= 45)
                {
                    AnimCar.GetComponent<UnitySteer.Behaviors.AutonomousVehicle>().MaxSpeed += 1;
                }

              




            }

            else
            {

                //CAMERA EFFECTS
                if (animcam.GetComponent<UnityStandardAssets.ImageEffects.BloomOptimized>().intensity >= 0.5f)
                {
                    animcam.GetComponent<UnityStandardAssets.ImageEffects.BloomOptimized>().intensity -= 0.08f;
                }


                if (animcam.GetComponent<RetroAesthetics.RetroCameraEffect>().chromaticAberration >= 5)
                {
                    animcam.GetComponent<RetroAesthetics.RetroCameraEffect>().chromaticAberration -= 2;
                }

                //Speed Effects

                if (AnimCar.GetComponent<UnitySteer.Behaviors.AutonomousVehicle>().MaxForce >= 35)
                {
                    AnimCar.GetComponent<UnitySteer.Behaviors.AutonomousVehicle>().MaxForce -= 1;
                }

                if (AnimCar.GetComponent<UnitySteer.Behaviors.AutonomousVehicle>().MaxSpeed >= 35)
                {
                    AnimCar.GetComponent<UnitySteer.Behaviors.AutonomousVehicle>().MaxSpeed -= 1;
                }
            }
        }
    }


   
}
