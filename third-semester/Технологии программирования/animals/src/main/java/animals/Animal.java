package animals;

public abstract class Animal {
    private final String name;
    private final int age;
    private final int maxSwim;

    public Animal(String name, int age, int maxSwim) {
        this.name = name;
        this.age = age;
        this.maxSwim = maxSwim;
    }

    public String getName() {
        return name;
    }
    public int getAge() {
        return age;
    }

    public void run(int dist) {
        System.out.println(this.getName() + " пробежал: " + dist);
    }

    public void swim(int dist) {
        if (maxSwim >= dist) {
            System.out.println(this.getName() + " проплыл: " + dist);
        } else {
            System.out.println(this.getName() + " не справился");
        }

    }
}
