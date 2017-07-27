using UnityEngine; 
using System.Collections; 
using stats; //Используем пространство stats 

public class playerstat : MonoBehaviour { 
	public Stats stats = new Stats(); //Объявляем новый объект Stats 
	public static bool death; //Глобальная переменная отвечающа нам жив ли персонаж 
	int showstat = 0; //Отображать ли окно со статами 
	public float curHP; //кол-во жизней персонаж нынешние 
	public float curDamage;
	public float curStamina;

	void Start() 
	{ 
		death = false; //По умолчанию персонаж жив 
		Time.timeScale=1; //Игра работает 
		curHP = stats.HP; //В начале у персонажа кол-во жизней максимально 
		curDamage = stats.Damage;
		curStamina = stats.Stamina;
	}

	void Update () { 
		if(curHP > stats.HP) //если кол-во жизни будет выше максимального кол-ва жизней 
			curHP=stats.HP; //Уравниваем их 
		if(curHP<=0) //Если кол-во жизни меньше или равно 0 
		{ 
			curHP=0; //Ставим 0 дабы наш бар не рисовался не корректно 
			death = true; //Ставим что персонаж мертв 
			Time.timeScale = 0; //Останавливаем игру 
		} 

		if(showstat == 0) //Если окно со статами не отображается 
		{ 
			if(Input.GetKeyDown (KeyCode.P)) //Принажатии на клавишу P 
				showstat = 1; //окно со статами будет отображаться 
		} 
		else if(showstat == 1) //если окно со статами отображается 
		{ 
			if(Input.GetKeyDown (KeyCode.P)) //При нажатии на клавишу P 
				showstat = 0; //Окно исчезнет 
		} 
	} 

	void OnGUI() 
	{ 
		if(showstat == 1) //если статы отображаются 
		{ 
			//Рисуем наши статы 
			GUI.Box (new Rect(10, 70, 300, 300), "stats"); 
			GUI.Label (new Rect(10, 95,300,300), "HP: "+stats.HP); 
			GUI.Label (new Rect(10, 110,300,300), "Damage: "+stats.Damage); 
			GUI.Label (new Rect(10, 125,300,300), "Stamina: "+stats.Stamina);  

		} 
		else if(showstat == 0) 
			useGUILayout=false; //Скрываем окно статов 
		if(death==true) //Если умерли 
		{ 
			/*if(GUI.Button (new Rect(Screen.width/2,Screen.height/2,100,50),"Переиграть")) //Ресуем кнопку переиграть 
			{ 
				Application.LoadLevel (0); 
			} */
		} 
	} 
}