package first_task;

public abstract class Fish extends Animal {

	private final int maxLength;
	
	public Fish(String name, int age, int maxLength) {
		super(name, age, 0, 200);
		this.maxLength = maxLength;
	}

	public void printMaxLength() {
		System.out.println(this.getName() + " имеет максимальный размер: " + this.maxLength);
	}
}
