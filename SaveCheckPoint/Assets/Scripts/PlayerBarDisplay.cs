using UnityEngine; 
using System.Collections; 

public class PlayerBarDisplay : MonoBehaviour { 
	public GUISkin StatsGui; // Скин где хранятся текстуры баров, В инспекторе назначить наш новый созданный скин 
	public playerstat Char; // Объект на котором висят статы 
	public bool Visible = true; //Видимость бара 

	// Use this for initialization 
	void Start () { 

	} 

	void OnGUI () { 
		if(Visible) 
		{ 
			//назначаем текущий скин для GUI 
			GUI.skin = StatsGui; 
			//получаем переменную PlayerSt компонент PlayerStats 
			playerstat PlayerSt = (playerstat)Char.GetComponent("playerstat"); 
			//получаем значения 
			float MaxHealth = PlayerSt.stats.HP; 
			float CurHealth = PlayerSt.curHP; 

			float MaxDamage = PlayerSt.stats.Damage; 
			float CurDamage = PlayerSt.curDamage; 

			float MaxStamina = PlayerSt.stats.Stamina; 
			float CurStamina = PlayerSt.curStamina; 
			//расчитываем коэффицент длинны полосы здоровья 
			float HealthBarLen = CurHealth/MaxHealth; //если умножить на сто то будут проценты 
			//расчитываем коэффицент длинны полосы маны 
			float DamageBarLen = CurDamage/MaxDamage; //если умножить на сто то будут проценты 
			//расчитываем коэффицент длинны полосы опыта 
			float StaminaBarLen = CurStamina/MaxStamina; //если умножить на сто то будут проценты 



			//полоса здоровья игрока 
			GUI.Box(new Rect(10,15,254*HealthBarLen,15), " ", GUI.skin.GetStyle("HPBar"));   
			//полоса урона игрока 
			GUI.Box(new Rect(10,30,254*DamageBarLen,15), " ", GUI.skin.GetStyle("DamageBar")); 
			//полоса выносливости
			GUI.Box(new Rect(10,55,254*StaminaBarLen,15), " ", GUI.skin.GetStyle("StaminaBar")); 

			//рисуем сам бар 
			GUI.Box(new Rect(10,10,254,64), " ", GUI.skin.GetStyle("PlayerBar")); 

		} 
	} 

	// Update is called once per frame 
	void Update () { 

	} 
}