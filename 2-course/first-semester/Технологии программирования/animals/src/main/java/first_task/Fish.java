package first_task;

public abstract class Fish extends Animal {

	private final int length;
	
	public Fish(String name, int age, int length) {
		super(name, age, 0, 200);
		this.length = length;
	}

	public void length() {
		System.out.println(this.getName() + " имеет максимальный размер: " + this.length);
	}
}
