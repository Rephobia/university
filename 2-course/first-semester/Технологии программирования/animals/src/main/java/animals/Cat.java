package animals;

public class Cat  extends Animal {

	String color;
	public Cat(String name, int age) {
		super(name, age, 0, 200);
	}

	public String getColor() {
		return color;
	}

	public void setColor(String color) {
		this.color = color;
	}
}
