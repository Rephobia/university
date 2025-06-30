using System.Data.SQLite;
using System.Data;

public class DbHelper
{
    private SQLiteConnection conn;

    public DbHelper(string connectionString)
    {
        conn = new SQLiteConnection(connectionString);
        conn.Open();
    }

    public DataTable GetLessons(string filter = "")
    {
        string sql = @"
            SELECT lesson.id, 
                   teachers.last_name || ' ' || teachers.first_name AS Teacher,
                   groups.specialty || ' ' || groups.department AS GroupName,
                   subjects.name AS Subject,
                   lesson_types.name AS LessonType,
                   lesson.hours
            FROM lesson
            JOIN teachers ON lesson.teacher_id = teachers.id
            JOIN groups ON lesson.group_id = groups.id
            JOIN subjects ON lesson.subject_id = subjects.id
            JOIN lesson_types ON lesson.lesson_type_id = lesson_types.id
        ";

        if (!string.IsNullOrEmpty(filter))
        {
            sql += @"
            WHERE (teachers.last_name || ' ' || teachers.first_name) LIKE @filter
               OR (groups.specialty || ' ' || groups.department) LIKE @filter
               OR subjects.name LIKE @filter
               OR lesson_types.name LIKE @filter
        ";
        }

        using var cmd = new SQLiteCommand(sql, conn);
        if (!string.IsNullOrEmpty(filter))
        {
            cmd.Parameters.AddWithValue("@filter", $"%{filter}%");
        }
        using var adapter = new SQLiteDataAdapter(cmd);
        var dt = new DataTable();
        adapter.Fill(dt);
        return dt;
    }

    public DataTable GetTable(string tableName)
    {
        using var cmd = new SQLiteCommand($"SELECT * FROM {tableName}", conn);
        using var adapter = new SQLiteDataAdapter(cmd);
        var dt = new DataTable();
        adapter.Fill(dt);
        return dt;
    }

    public void AddLesson(int teacherId, int groupId, int subjectId, int lessonTypeId, int hours)
    {
        string sql = @"INSERT INTO lesson (teacher_id, group_id, subject_id, lesson_type_id, hours) 
                       VALUES (@teacherId, @groupId, @subjectId, @lessonTypeId, @hours)";
        using var cmd = new SQLiteCommand(sql, conn);
        cmd.Parameters.AddWithValue("@teacherId", teacherId);
        cmd.Parameters.AddWithValue("@groupId", groupId);
        cmd.Parameters.AddWithValue("@subjectId", subjectId);
        cmd.Parameters.AddWithValue("@lessonTypeId", lessonTypeId);
        cmd.Parameters.AddWithValue("@hours", hours);
        cmd.ExecuteNonQuery();
    }

    public void UpdateLesson(int lessonId, int teacherId, int groupId, int subjectId, int lessonTypeId, int hours)
    {
        string sql = @"UPDATE lesson SET teacher_id = @teacherId, group_id = @groupId, subject_id = @subjectId,
                       lesson_type_id = @lessonTypeId, hours = @hours WHERE id = @lessonId";
        using var cmd = new SQLiteCommand(sql, conn);
        cmd.Parameters.AddWithValue("@teacherId", teacherId);
        cmd.Parameters.AddWithValue("@groupId", groupId);
        cmd.Parameters.AddWithValue("@subjectId", subjectId);
        cmd.Parameters.AddWithValue("@lessonTypeId", lessonTypeId);
        cmd.Parameters.AddWithValue("@hours", hours);
        cmd.Parameters.AddWithValue("@lessonId", lessonId);
        cmd.ExecuteNonQuery();
    }

    public void DeleteLesson(int lessonId)
    {
        string sql = "DELETE FROM lesson WHERE id = @lessonId";
        using var cmd = new SQLiteCommand(sql, conn);
        cmd.Parameters.AddWithValue("@lessonId", lessonId);
        cmd.ExecuteNonQuery();
    }

    public DataTable GetTeachers()
    {
        string sql = @"
        SELECT id, last_name || ' ' || first_name AS FullName
        FROM teachers
        ORDER BY last_name, first_name
    ";

        using var cmd = new SQLiteCommand(sql, conn);
        using var adapter = new SQLiteDataAdapter(cmd);
        var dt = new DataTable();
        adapter.Fill(dt);
        return dt;
    }
}
