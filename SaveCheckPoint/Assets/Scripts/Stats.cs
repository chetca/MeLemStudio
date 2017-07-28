using UnityEngine; 
using System.Collections; 

namespace stats { //Пространство имен stats 
	public class Stats //Объявляем новый класс Stats 
	{ 
		public float HP = 8; //Максимум здоровья
		public float Damage = 6; //Максимум урона
		public float Agility = 6; //Максимум ловкости
		public float Breaking = 5; //Максимум взлома
		public float Charm = 5; //Максимум очарования
		public float Stamina = 100; //Максимум взлома
		public float Heat = 100; //Максимум тепла
		public float Repose = 0; //Сон

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
			this.HP = HP;
		}

		public void newDamage(){
			this.Damage = Damage;
		}

		public void newAgility(){
			this.Agility = Agility;
		}

		public void newBreaking(){
			this.Breaking = Breaking;
		}

		public void newCharm(){
			this.Charm = Charm;
		}

		public void newStamina(){
			this.Stamina = Stamina;
		}

		public void newHeat(){
			this.Heat = Heat;
		}

		public void newRepose(){
			this.Repose = Repose;
		}

	} 
}