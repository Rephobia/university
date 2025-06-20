package Lms;

import org.sqlite.JDBC;
import java.sql.*;
import java.util.*;
import java.util.function.Consumer;

public class DbHandler {
	private static final String CON_STR = "jdbc:sqlite:lms.db";
	private static DbHandler instance = null;
	public static synchronized DbHandler getInstance() throws SQLException {
		if (instance == null) {
			instance = new DbHandler();
		}

		return instance;
	}

	private Connection connection;

	private DbHandler() throws SQLException {
		DriverManager.registerDriver(new JDBC());
		this.connection = DriverManager.getConnection(CON_STR);
	}

	public List<Teacher> getAllTeachers(){
		return getTeachers("select * from teachers;", null);
	}

	public List<Teacher> getTeachersWitnExperience(int minExp) {
		return getTeachers("select * from teachers where experience >= ?",
				   stmt -> {
					   try {
						   stmt.setInt(1, minExp);
					   } catch (SQLException e) {
						   e.printStackTrace();
					   }
				   });
	}

	public List<Teacher> getTeachersBetweenExperience(int minExp, int maxExp) {
		return getTeachers("select * from teachers where experience between ? and ?",
				   stmt -> {
					   try {
						   stmt.setInt(1, minExp);
						   stmt.setInt(2, maxExp);
					   } catch (SQLException e) {
						   e.printStackTrace();
					   }
				   });
	}
	
	private List<Teacher> getTeachers(String sql, Consumer<PreparedStatement> binder) {
		List<Teacher> teachers = new ArrayList<>();
		try (PreparedStatement stmt = this.connection.prepareStatement(sql)) {
			if (binder != null) {
				binder.accept(stmt);
			}
			
			try (ResultSet rs = stmt.executeQuery()) {
				while (rs.next()) {
					teachers.add(new Teacher(
								 rs.getInt("id"),
								 rs.getString("last_name"),
								 rs.getString("first_name"),
								 rs.getString("middle_name"),
								 rs.getString("phone"),
								 rs.getInt("experience")
								 ));
				}
			}
		} catch (SQLException e) {
			e.printStackTrace();
		}

		return teachers;
	}

	public void addTeacher(Teacher teacher) {
		String sql = "insert into teachers (last_name, first_name, middle_name, phone, experience) values (?, ?, ?, ?, ?)";
		try (PreparedStatement stmt = this.connection.prepareStatement(sql)) {
			stmt.setObject(1, teacher.lastName);
			stmt.setObject(2, teacher.firstName);
			stmt.setObject(3, teacher.middleName);
			stmt.setObject(4, teacher.phone);
			stmt.setObject(5, teacher.experience);

			stmt.execute();
		} catch (SQLException e) {
			e.printStackTrace();
		}
	}

	public void deleteTeacherByPhone(String phone) {
		String sql = "delete from teachers where phone = ?";

		try (PreparedStatement stmt = this.connection.prepareStatement(sql)) {
			stmt.setString(1, phone);
			stmt.execute();
		} catch (SQLException e) {
			e.printStackTrace();
		}
	}

	public void increaseExperience(int increment, int maxCurrentExperience) {
		String sql = "update teachers set experience = experience + ? where experience < ?";

		try (PreparedStatement stmt = this.connection.prepareStatement(sql)) {
			stmt.setInt(1, increment);
			stmt.setInt(2, maxCurrentExperience);
			stmt.executeUpdate();
		} catch (SQLException e) {
			e.printStackTrace();
		}
	}

}
