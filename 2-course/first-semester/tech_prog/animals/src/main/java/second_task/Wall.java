package second_task;

public class Wall implements Obstacle {
	private int height;
	
	public Wall(int height)
	{
		this.height = height;
	}

	public boolean check(Athlete athlete)
	{
		if (athlete.jump(this.height) || athlete.superJump()) {
			System.out.println(athlete.getName() +" успешно перепрыгнул стену");
			return true;
		}
		
		System.out.println(athlete.getName() + " не смог перепрыгнуть стену");

		return false;
	}
}
