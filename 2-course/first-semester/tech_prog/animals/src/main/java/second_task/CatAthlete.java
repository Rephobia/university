package second_task;

public class CatAthlete implements Athlete {
	private int height;
	private int length;
	private SuperJump superJump;

	public CatAthlete(int height, int length, SuperJump jump)
	{
		this.height = height;
		this.length = length;
		this.superJump = jump;

	}
	
	public boolean jump(int height)
	{
		return this.height >= height ? true : false;
	}

	public boolean superJump()
	{
		return this.superJump.use();
	}
	public int getSuperJumpCount()
	{
		return this.superJump.getSuperJumpCount();
	}	
	public boolean run(int length)
	{
		return this.length >= length ? true : false;
	}
	public String getName()
	{
		return "Кот";
	}
}
