using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDamage : MonoBehaviour {

    private HealthandDamage healthandDamage;
	// Use this for initialization
	void Start () {
        healthandDamage = gameObject.GetComponent<HealthandDamage>();
	}
	
	// Update is called once per frame
	void Update () {
        if (healthandDamage.death == false)
        healthandDamage.curhealth = healthandDamage.curhealth - healthandDamage.damage * Time.deltaTime;
        healthandDamage.MinMaxValue();
        healthandDamage.ratio = healthandDamage.curhealth / healthandDamage.maxHealth;
        healthandDamage.curhealthRounded = Mathf.Round(healthandDamage.curhealth);
        healthandDamage.healthText.text = healthandDamage.curhealthRounded.ToString() + "%";
        healthandDamage.healthbarScale.localScale = new Vector3(healthandDamage.ratio, healthandDamage.healthbarScale.localScale.y, healthandDamage.healthbarScale.localScale.z);

        }
	
}
