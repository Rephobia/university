package animals;

public abstract class Animal {
	private final String name;
	private final int age;
	private final int maxRun;
	private final int maxSwim;
	
	static int animalCounter = 0;
	
	public Animal(String name, int age, int maxSwim, int maxRun) {
		this.name = name;
		this.age = age;
		this.maxSwim = maxSwim;
		this.maxRun = maxRun;
		animalCounter++;
	}

	public String getName() {
		return name;
	}
	
	public int getAge() {
		return age;
	}

	public void run(int dist) {
		if (maxRun >= dist) {
			System.out.println(this.getName() + " пробежал: " + dist);
		} else {
			System.out.println(this.getName() + " не справился");
		}
	}

	public void swim(int dist) {
		if (maxSwim >= dist) {
			System.out.println(this.getName() + " проплыл: " + dist);
		} else {
			System.out.println(this.getName() + " не справился");
		}
	}
}
