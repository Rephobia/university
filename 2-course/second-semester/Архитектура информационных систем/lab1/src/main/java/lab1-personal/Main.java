package lab1_personal;

import java.sql.SQLException;
import java.util.List;

public class Main {
	public static void main(String[] args) {
		try {
			DbHandler db = DbHandler.getInstance();
			// db.addProduct(new Product("Музей", 200, "Развлечения"));

			System.out.println("\nЗадание 1. выбор всех записей из определенной таблицы БД (выбираем всех учителей)");
			printTeachers(db.getAllTeachers());

			System.out.println("\nЗадание 2. выбор записей, удовлетворяющих определенному условию, например, больше заданного значения (выбираем всех учителей с опытом 6ти или более лет)");

			printTeachers(db.getTeachersWitnExperience(6));
			
			System.out.println("\nЗадание 3.Выбор записей, удовлетворяющих условию принадлежности значений указанному диапазону(выбираем всех учителей с опытом более 6 лет, но менее 8)");
			
			printTeachers(db.getTeachersBetweenExperience(6, 8));

			System.out.println("\nЗадание 4.Добавление записи в таблицу учителей (Петров)");
		
			db.addTeacher(new Teacher("Петров","Игорь", "Николаевич","+7-911-000-11-22", 8));
			printTeachers(db.getAllTeachers());

			System.out.println("\nЗадание 5 Удаление учителя по телефону +7-911-000-11-22");
			db.deleteTeacherByPhone("+7-911-000-11-22");
			printTeachers(db.getAllTeachers());

			System.out.println("\nЗадание 6 Изменение данных в таблице, удовлетворяющих определенному условию, увеличить опыт учителей на 2 года, если их текущий опыт меньше 10 лет");
			db.increaseExperience(2, 10);
			printTeachers(db.getAllTeachers());
		} catch (SQLException e) {
			e.printStackTrace();
		}
	}

	private static void printTeachers(List<Teacher> teachers) {
		for (Teacher teacher : teachers) {
			System.out.println(teacher.toString());
		}		
	}
}
