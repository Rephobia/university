package animals;

import first_task.*;
import second_task.*;

public class Main {
	public static void main(String[] args)
	{
		firstTask();
		firstTaskPersonal();
		secondTask();
	}
	
	/**
	 * Работа 1
	 */
	public static void firstTask()
	{
		System.out.println("Задача 1:\n");
		Animal[] animals = {
			new Cat("Маркиз", 11),
				new Tiger("Барсик", 10),
				new Dog("Питбуль", 12),
				new Dog("Лев", 5),
		};

		System.out.println("Животные начинают заплыв:");
	
		for (Animal animal : animals) {
			animal.swim(10);
		}
		
		System.out.println("Животные начинают забег:");

	        for (Animal animal : animals) {
			animal.run(250);
		}
		
		System.out.println();
		Animal.printAllAnimalsCount();		
	}

	/**
	 * Работа 1 персональное задание
	 */
	public static void firstTaskPersonal()
	{
		Fish[] fishs = {
			new Pike("Щука", 2),
			new Perch("Окунь", 1),
			new Salmon("Лосось", 3),
		};

		for (Fish fish: fishs) {
			fish.printMaxLength();
		}		
	}

	/**
	 * Работа 2
	 */
	public static void secondTask()
	{
		System.out.println("\nЗадача 2:\n");

		SuperJump superJump = new SuperJump();
		Athlete[] athletes = {
			new Human(0, 100, superJump),
			new Robot(0, 1000, superJump),
			new CatAthlete(0, 50, superJump),
		};
		
		Obstacle[] obstacles = {
			new Wall(1),
			new TreadMill(90),
		};


		for (Athlete athlete: athletes) {
			for (Obstacle obstacle : obstacles) {
				if (!obstacle.check(athlete)) {
					break;
				}
			}
		}
	}
}
