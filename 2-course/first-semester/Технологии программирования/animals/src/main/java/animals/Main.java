package animals;

public class Main {
	public static void main(String[] args) {

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
		System.out.println("Животных создано: " + Animal.animalCounter);
	}
}
