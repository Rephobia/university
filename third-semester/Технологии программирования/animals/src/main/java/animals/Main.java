package animals;

//TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or
// click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.
public class Main {
    public static void main(String[] args) {

        Animal[] animals = {
                new Cat("Маркиз", 10),
                new Cat("Барсик", 10),
                new Dog("Питбуль", 10),
                new Dog("Лев", 10),
        };

        for (Animal animal : animals) {
            animal.swim(10);
        }
    }
}