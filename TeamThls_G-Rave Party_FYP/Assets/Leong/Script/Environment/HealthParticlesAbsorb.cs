using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthParticlesAbsorb : MonoBehaviour {

	[SerializeField] Transform healthCross_Obj;
	[SerializeField] HealthDeviceHealing healthScript;
	ParticleSystem p_HealthSoul;

	// Use this for initialization
	void Start () 
	{
		if(healthCross_Obj == null)
		{
			healthCross_Obj = GameObject.Find("P_HealDevice").GetComponent<Transform>();
		}
		if(healthScript == null)
		{
			healthScript = GameObject.Find("P_HealDeviceStand").GetComponent<HealthDeviceHealing>();
		}
		p_HealthSoul = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = Vector2.MoveTowards(transform.position, new Vector3(healthCross_Obj.position.x, healthCross_Obj.position.y + 0.2f, healthCross_Obj.position.x - 0.1f), Mathf.Lerp(0.01f, 1.0f, 0.1f));
	}

	void OnParticleCollision(GameObject obj)
	{
		p_HealthSoul.Stop();
		StartCoroutine(Vanish(1.0f));

	}

	IEnumerator Vanish(float duration)
	{
		yield return new WaitForSeconds(duration);

		if(healthScript.availableHealth < 5)
		{
			healthScript.availableHealth += 1;
		}

		Destroy(this.gameObject);
	}
}
