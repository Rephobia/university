package lab2_combo;

public class pl {
	public int code;
	private String name;
	public pl(int code, String name) {
		this.code = code;
		this.name = name;
	}
	
	public pl()
	{
    	

}
	public int getCode() {
		return code;
	}
 
	public void setCode(int code) {
		this.code = code;
	}
 
	public String getName() {
		return name;
	}
 
	public void setName(String name) {
		this.name = name;
	}
    
	@Override
	public String toString()  {
		return this.name;
	}
}
