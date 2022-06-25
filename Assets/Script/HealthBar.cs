using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	public Slider slider;
	public Gradient gradient;
	public Image fill;
    
    public void Start()
    {
		SetMaxHealth(GameManager.Instance.player.maxhitPoint);
		Debug.Log("currentHP");
	}

    public void Update()
    {
		SetHealth(GameManager.Instance.player.hitPoint);
    }

	public void SetMaxHealth(int health)
	{
		
		slider.maxValue = health;
		slider.value = health;

		//fill.color = gradient.Evaluate(1f);
	}

    public void SetHealth(int health)
	{
		slider.value = health;

		//fill.color = gradient.Evaluate(slider.normalizedValue);
	}

}
