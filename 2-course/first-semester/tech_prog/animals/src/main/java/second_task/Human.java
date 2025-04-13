package second_task;

public class Human implements Athlete {
	private int height;
	private int length;
	private SuperJump superJump;
	
	public Human(int height, int length, SuperJump superJump)
	{
		this.height = height;
		this.length = length;
		this.superJump = superJump;
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
		return "Человек";
	}
}
