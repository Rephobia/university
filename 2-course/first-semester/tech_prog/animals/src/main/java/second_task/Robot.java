package second_task;

public class Robot implements Athlete {
	private int height;
	private int length;
	private SuperJump superJump;
	
	public Robot(int height, int length, SuperJump superJump)
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

	public boolean run(int length)
	{
		return this.length >= length ? true : false;
	}
	public String getName()
	{
		return "Робот";
	}
}