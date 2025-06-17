package Lms;

public class Teacher {
	public int id;
	public String lastName;
	public String firstName;
	public String middleName;
	public String phone;
	public int experience;

	public Teacher(String lastName, String firstName, String middleName, String phone, int experience) {
		this.lastName = lastName;
		this.firstName = firstName;
		this.middleName = middleName;
		this.phone = phone;
		this.experience = experience;
	}

	public Teacher(int id, String lastName, String firstName, String middleName, String phone, int experience) {
		this.id = id;
		this.lastName = lastName;
		this.firstName = firstName;
		this.middleName = middleName;
		this.phone = phone;
		this.experience = experience;
	}

	@Override
	public String toString() {
		return "Учитель(" +
			"id=" + id +
			", Имя='" + lastName + '\'' +
			", Фамилия='" + firstName + '\'' +
			", Отчество='" + middleName + '\'' +
			", Телефон='" + phone + '\'' +
			", Опыт=" + experience +
			')';
	}
}
