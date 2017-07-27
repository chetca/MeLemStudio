using UnityEngine; 
using System.Collections; 

namespace stats { //Пространство имен stats 
	public class Stats //Объявляем новый класс Stats 
	{ 
		public float HP; //Здоровье
		public float Damage; //Урон
		public float Agility; //Ловкость
		public float Breaking; //Взлом
		public float Charm; //Очарование
		public float Stamina; //Выностивость
		public float Heat; //Тепло
		public float Repose; //Сон

		public Stats() //конструктор класса по умолчанию
		{ 
			this.newHP();
			this.newDamage();
			this.newAgility();
			this.newBreaking();
			this.newCharm();
			this.newStamina();
			this.newHeat();
			this.newRepose();
		} 

		//=====================================================
		//===============Заглушки с раскачкой==================
		//=====================================================

		public void newHP(){
			this.HP = 8;
		}

		public void newDamage(){
			this.Damage = 6;
		}

		public void newAgility(){
			this.Agility = 6;
		}

		public void newBreaking(){
			this.Breaking = 5;
		}

		public void newCharm(){
			this.Charm = 5;
		}

		public void newStamina(){
			this.Stamina = 100;
		}

		public void newHeat(){
			this.Heat = 100;
		}

		public void newRepose(){
			this.Repose = 0;
		}

	} 
}