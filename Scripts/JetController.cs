using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class JetController : MonoBehaviour
{
    public GameObject laserLeft, laserRight,parentLeftObject,parentRightObject;
    public Transform laserLeftTransform, laserRightTransform;
    public bool throttle => Input.GetKey(KeyCode.Space);
    public Joystick joystick;
    public Joystick Rolljoystick;
    public Joystick HorizontalJoystick;
    public float pitchPower, rollPower, yawPower, enginePower;
    private float Roll, Pitch, Yaw;
    private new Rigidbody rigidbody;
    private bool fire = false;
    private float pitchInput = 0f, yawInput = 0f, rollInput = 0f;
    
    [SerializeField] public float speed = 120f;
    AudioSource audioSource;
    [SerializeField] AudioClip shoot;



    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Firing();
        ShipSteering();
    }

    private void Firing()
    {
        if (fire) {
            GameObject myNewLaserLeft = Instantiate(laserLeft,laserLeftTransform.position, Quaternion.Euler(laserLeftTransform.eulerAngles)) as GameObject;
            GameObject myNewLaserRight = Instantiate(laserRight,laserRightTransform.position, Quaternion.Euler(laserRightTransform.eulerAngles)) as GameObject;
            audioSource.PlayOneShot(shoot,0.1f);
            fire = false;
            Destroy(myNewLaserLeft, 2f);
            Destroy(myNewLaserRight, 2f);

        }
    }

    public void FireInput()
    {
        fire = true;
    }

    private void ShipSteering()
    {

        if (HorizontalJoystick.Horizontal >= .4f)
        {
            yawInput = HorizontalJoystick.Horizontal;
        }else if (HorizontalJoystick.Horizontal <= -.4f)
        {
            yawInput = HorizontalJoystick.Horizontal;
        }
        else
        {
            yawInput = 0f;
        }

        //Vertical
        if (joystick.Vertical >= .0f)
        {
            pitchInput = joystick.Vertical;
        }
        else if (joystick.Vertical <= -.0f)
        {
            pitchInput = joystick.Vertical;
        }
        else
        {
            pitchInput = 0f;
        }

        //Roll
        if (Rolljoystick.Horizontal >= .1f)
        {
            rollInput = Rolljoystick.Horizontal;
        }
        else if (Rolljoystick.Horizontal <= -.1f)
        {
            rollInput = Rolljoystick.Horizontal;
        }
        else
        {
            rollInput = 0f;
        }


        if (enginePower < speed && !Advertisement.isShowing)
        {
            enginePower += (40f * Time.deltaTime);
        }
        transform.position += transform.forward * enginePower * Time.deltaTime;

        Pitch = pitchInput * pitchPower * Time.deltaTime;
        Roll = rollInput * rollPower * Time.deltaTime;
        Yaw = yawInput * yawPower * Time.deltaTime;

        transform.Rotate(-Pitch, Yaw, -Roll, Space.Self);

    }
}
