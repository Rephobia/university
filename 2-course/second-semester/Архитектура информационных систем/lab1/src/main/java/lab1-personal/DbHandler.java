package lab1_personal;

import org.sqlite.JDBC;
import java.sql.*;
import java.util.*;
import java.util.function.Consumer;

import lab2_personal.LessonView;

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


    public List<String> getAllTeacherNames() throws SQLException {
	List<String> list = new ArrayList<>();
	var rs = connection.createStatement().executeQuery("SELECT id, last_name, first_name FROM teachers");
	while (rs.next()) {
	    list.add(rs.getInt("id") + " " + rs.getString("last_name") + " " + rs.getString("first_name"));
	}
	return list;
    }

    public List<String> getAllGroupNames() throws SQLException {
	List<String> list = new ArrayList<>();
	var rs = connection.createStatement().executeQuery("SELECT id, specialty FROM groups");
	while (rs.next()) {
	    list.add(rs.getInt("id") + " " + rs.getString("specialty"));
	}
	return list;
    }

    public List<String> getAllSubjectNames() throws SQLException {
	List<String> list = new ArrayList<>();
	var rs = connection.createStatement().executeQuery("SELECT id, name FROM subjects");
	while (rs.next()) {
	    list.add(rs.getInt("id") + " " + rs.getString("name"));
	}
	return list;
    }

    public List<String> getAllLessonTypes() throws SQLException {
	List<String> list = new ArrayList<>();
	var rs = connection.createStatement().executeQuery("SELECT id, name FROM lesson_types");
	while (rs.next()) {
	    list.add(rs.getInt("id") + " " + rs.getString("name"));
	}
	return list;
    }

    public void insertLesson(int teacherId, int groupId, int subjectId, int lessonTypeId, int hours) throws SQLException {
	var ps = connection.prepareStatement(
				       "INSERT INTO lesson (teacher_id, group_id, subject_id, lesson_type_id, hours) VALUES (?, ?, ?, ?, ?)"
				       );
	ps.setInt(1, teacherId);
	ps.setInt(2, groupId);
	ps.setInt(3, subjectId);
	ps.setInt(4, lessonTypeId);
	ps.setInt(5, hours);
	ps.executeUpdate();
    }

    public List<LessonView> getLessonsByTeacher(int teacherId) throws SQLException {
	List<LessonView> lessons = new ArrayList<>();
	var sql = """
	    SELECT t.id as teacher_id, t.last_name AS teacher_name, t.last_name AS teacher_last_name,  s.name AS subject, g.specialty AS group_name, lt.name AS type, l.hours
	    FROM lesson l
	    JOIN teachers t ON l.teacher_id = t.id
	    JOIN subjects s ON l.subject_id = s.id
	    JOIN groups g ON l.group_id = g.id
	    JOIN lesson_types lt ON l.lesson_type_id = lt.id
	    WHERE t.id = ?
	    """;

	    var ps = connection.prepareStatement(sql);
	ps.setInt(1, teacherId);
	var rs = ps.executeQuery();
	while (rs.next()) {
	    lessons.add(new LessonView(
				       rs.getInt("teacher_id") + " " + rs.getString("teacher_name") + " " + rs.getString("teacher_last_name"),
				       rs.getString("subject"),
				       rs.getString("group_name"),
				       rs.getString("type"),
				       rs.getInt("hours")
				       ));
	}
	return lessons;
    }

    public List<LessonView> getLessonsByTeacher() throws SQLException {
	List<LessonView> lessons = new ArrayList<>();
	var sql = """
	    SELECT t.id as teacher_id, t.last_name AS teacher_name, t.last_name AS teacher_last_name,  s.name AS subject, g.specialty AS group_name, lt.name AS type, l.hours
	    FROM lesson l
	    JOIN teachers t ON l.teacher_id = t.id
	    JOIN subjects s ON l.subject_id = s.id
	    JOIN groups g ON l.group_id = g.id
	    JOIN lesson_types lt ON l.lesson_type_id = lt.id
	    """;

	var ps = connection.prepareStatement(sql);
	var rs = ps.executeQuery();
	while (rs.next()) {
	    lessons.add(new LessonView(
				       rs.getInt("teacher_id") + " " + rs.getString("teacher_name") + " " + rs.getString("teacher_last_name"),
				       rs.getString("subject"),
				       rs.getString("group_name"),
				       rs.getString("type"),
				       rs.getInt("hours")
				       ));
	}
	return lessons;
    }
}
