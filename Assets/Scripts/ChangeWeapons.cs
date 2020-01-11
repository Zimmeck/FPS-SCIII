using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapons : MonoBehaviour
{
    public GameObject Pistol;
    public GameObject Shotgun;
    public GameObject RocketLauncher;
    public GameObject GrenadeLauncher;
    public GameObject MachineGun;

    public bool IsGun, isShotgun, IsMachineGun, IsRocketLauncher, IsGreandeLauncher ;

    // Start is called before the first frame update
    void Start()
    {
        isShotgun = false;
        IsGun = false;
        IsRocketLauncher = false;
        IsMachineGun = false;
        IsGreandeLauncher = false;

    }

    // Update is called once per frame
    void Update()
    {
        ChangeWeapon();
    }
    public void ChangeWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)&&IsGun)
        {
            Pistol.SetActive(true);
            Shotgun.SetActive(false);
            MachineGun.SetActive(false);
            RocketLauncher.SetActive(false);
            GrenadeLauncher.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)&&isShotgun)
        {
            Pistol.SetActive(false);
            Shotgun.SetActive(true);
            MachineGun.SetActive(false);
            RocketLauncher.SetActive(false);
            GrenadeLauncher.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)&&IsMachineGun )
        {
            Pistol.SetActive(false);
            Shotgun.SetActive(false);
            MachineGun.SetActive(true);
            RocketLauncher.SetActive(false);
            GrenadeLauncher.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4)&&IsRocketLauncher )
        {
            Pistol.SetActive(false);
            Shotgun.SetActive(false);
            MachineGun.SetActive(false);
            RocketLauncher.SetActive(true);
            GrenadeLauncher.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5)&&IsGreandeLauncher)
        {
            Pistol.SetActive(false);
            Shotgun.SetActive(false);
            MachineGun.SetActive(false);
            RocketLauncher.SetActive(false);
            GrenadeLauncher.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "PistolPickUp")
        {
            IsGun = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "ShotgunPickUp" && Score.score >= 50)
        {
            isShotgun = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "GrenadeLauncherPickUp" && Score.score >= 200)
        {
            IsGreandeLauncher = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "RocketLauncherPickUp" && Score.score >= 150)
        {
            IsRocketLauncher = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "MachineGunPickUp" && Score.score >= 100)
        {
            IsMachineGun = true;
            Destroy(collision.gameObject);
        }
    }
 
}
