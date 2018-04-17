using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbwireDamage : MonoBehaviour {
    public HealthandDamage healthandDamage;
	// Use this for initialization
	void Start () {
        healthandDamage = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthandDamage>();
        
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay(Collider other) {
        if (healthandDamage.death == false)
        {
            if (other.gameObject.tag == "Player")
            {
                healthandDamage.curhealth = healthandDamage.curhealth - healthandDamage.damage * Time.deltaTime;
                healthandDamage.MinMaxValue();
                healthandDamage.ratio = healthandDamage.curhealth / healthandDamage.maxHealth;
                healthandDamage.curhealthRounded = Mathf.Round(healthandDamage.curhealth);
                healthandDamage.healthText.text = healthandDamage.curhealthRounded.ToString() + "%";
                healthandDamage.healthbarScale.localScale = new Vector3(healthandDamage.ratio, healthandDamage.healthbarScale.localScale.y, healthandDamage.healthbarScale.localScale.z);
            }
        }
    }
}
