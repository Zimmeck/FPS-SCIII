using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VerySimplePistol : MonoBehaviour
{
	public  Transform m_raycastSpot;					
	public  float     m_damage        = 80.0f;				
	public  float     m_forceToApply  = 20.0f;				
	public  float     m_weaponRange   = 9999.0f;						
	public  Texture2D m_crosshairTexture;					
    public  AudioSource m_fireSound;
    public AudioSource m_reloadSound;
    private bool      m_canShot;
    float m_currentAccuracy;
    float m_accuracy;
    float m_accuracyRecoverPerSecond;
    float m_accuaracyDropPerShot;
    public int currentAmmo;
    public int MaxAmmo;
    public GameObject m_weapon;
    float m_recoilRecovery;
    float m_recoilBack;
    public Text Ammo;
    public Text maxAmmo;
    public int balas;
    float m_shortTimer;
    public bool m_isAMachineGun;
    float timeBetweenShoots;
    public bool m_isRocketLauncher;
    public bool m_isGrenadeLauncher;
    public GameObject m_projectile;
    public Transform m_rocketSpot;
  


    private void Start()
    {
        currentAmmo = MaxAmmo;
        maxAmmo.text = MaxAmmo.ToString();
       

        m_canShot = true;
    }

    private void OnEnable()
    {
        Ammo.text = currentAmmo.ToString();
        maxAmmo.text = MaxAmmo.ToString();

        m_canShot = true;
    }

    private void Update()
	{
        Ammo.text = currentAmmo.ToString();
        m_weapon.transform.position = Vector3.Lerp(m_weapon.transform.position, transform.position, m_recoilRecovery * Time.deltaTime);
        m_currentAccuracy = Mathf.Lerp(m_currentAccuracy, m_accuracy, m_accuracyRecoverPerSecond * Time.deltaTime);

        if (currentAmmo <= 0)
        {
            m_canShot = false;
        }
        else
        {
            m_canShot = (m_isAMachineGun) ? true : m_canShot;
        }


        if (m_canShot)
        {
            if (Input.GetButton("Fire1"))
            {
                
                if (m_isRocketLauncher)
                {
                    ShotRocket();
                }
                if (m_isGrenadeLauncher)
                {
                    GrenadeShot();
                }
                else
                    Shot();
            }
        }

        else if (Input.GetButtonUp("Fire1"))
        {
            m_canShot = true;
        }
        if (Input.GetKey(KeyCode.R))
        {
            currentAmmo = MaxAmmo;
            m_reloadSound.Play();
        }
	}

	private void OnGUI()
	{
		Vector2 center = new Vector2(Screen.width / 2, Screen.height / 2);
		Rect auxRect = new Rect(center.x - 20, center.y - 20, 20, 20);
		GUI.DrawTexture(auxRect, m_crosshairTexture, ScaleMode.StretchToFill);
	}


	private void Shot()
	{
        m_canShot = false;

        if (currentAmmo <= 0) // La municion es menor o igual que 0.
        {
            return; // Deja de leer el metodo porque has restado la municion y la municion es igual a 0.
        }

        currentAmmo--; // 1 - 1 = 0

        m_weapon.transform.Translate(new Vector3(0, 0, -m_recoilBack), Space.Self);
        
        
        
        for (int i = 0; i < balas; i++)
        {
            float accuracyModifier = (100 - m_currentAccuracy) / 1000;
            Vector3 directionForward = m_raycastSpot.forward;
            directionForward.x += UnityEngine.Random.Range(-accuracyModifier, accuracyModifier);
            directionForward.y += UnityEngine.Random.Range(-accuracyModifier, accuracyModifier);
            directionForward.z += UnityEngine.Random.Range(-accuracyModifier, accuracyModifier);
            m_currentAccuracy -= m_accuaracyDropPerShot;
            m_currentAccuracy = Mathf.Clamp(m_currentAccuracy, 0, 100);

           Ray ray = new Ray(m_raycastSpot.position, directionForward);
            Debug.DrawRay(m_raycastSpot.position, directionForward, Color.green, 4);
            RaycastHit hit;

		    if (Physics.Raycast(ray, out hit, m_weaponRange))
		    {
                Debug.Log("Hit " + hit.transform.name);
                if (hit.rigidbody)
			    {
				    hit.rigidbody.AddForce(ray.direction * m_forceToApply);
                    Debug.Log("Hit");
                    hit.transform.GetComponent<Enemigo>().m_life -= 10;
                    Debug.Log("ahhhhhh " + hit.transform.name);
                }
		    }
        }
        
        m_fireSound.Play();
	}
    public void ShotRocket()
    {

        //En caso de volver a disparar, tendras municion 0, por tanto, cuando llegue al comprobante, cortará la funcion y no disparará.
        m_shortTimer = 5f;
        if (currentAmmo <= 0) // La municion es menor o igual que 0.
        {
            return; // Deja de leer el metodo porque has restado la municion y la municion es igual a 0.
        }

        currentAmmo--; // 1 - 1 = 0

        m_canShot = false;
        
            GameObject proj = Instantiate(m_projectile, m_rocketSpot.position, m_rocketSpot.rotation) as GameObject;
        
        m_weapon.transform.Translate(new Vector3(0, 0, -m_recoilBack), Space.Self);
        m_fireSound.Play();

    }
    public void GrenadeShot()
    {
        m_shortTimer = 2f;
        if (currentAmmo <= 0)
        {
            return;
        }

        currentAmmo--;
        m_canShot = false;
        for (int i = 0; i < balas; i++)
        {
            GameObject proj = Instantiate(m_projectile, m_rocketSpot.position, m_rocketSpot.rotation) as GameObject;
            proj.GetComponent<Rigidbody>().AddForce(-m_rocketSpot.forward * 4, ForceMode.Impulse);
        }

        m_weapon.transform.Translate(new Vector3(0, 0, -m_recoilBack), Space.Self);
        m_fireSound.Play();
    }
 

}
