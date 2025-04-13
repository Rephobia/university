package second_task;

public class SuperJump {

	private int count = 2;

	public boolean use()
	{
		if (this.count > 0) {
			this.count--;
			return true;
		}

		return false;
	}

	public int getSuperJumpCount()
	{
		return count;
	}
}

