package second_task;

public class TreadMill implements Obstacle {
	private int length;
	
	public TreadMill(int length)
	{
		this.length = length;
	}

	public boolean check(Athlete athlete)
	{
		if (athlete.run(this.length)) {
			System.out.println(athlete.getName() +" успешно пробежал дорожку");
			return true;
		}
		
		System.out.println(athlete.getName() + " не смог пробежать дорожку");

		return false;
	}
}
