package lab2_personal;

import javafx.fxml.FXML;
import javafx.scene.control.*;
import lab1_personal.DbHandler;

import java.sql.SQLException;
import java.util.List;

public class LessonFormController {

    @FXML
    private ComboBox<String> teacherCombo;
    @FXML
    private ComboBox<String> groupCombo;
    @FXML
    private ComboBox<String> subjectCombo;
    @FXML
    private ComboBox<String> lessonTypeCombo;
    @FXML
    private TextField hoursField;

    @FXML
    public void initialize() {
        try {
            DbHandler db = DbHandler.getInstance();

            teacherCombo.getItems().addAll(db.getAllTeacherNames());   // e.g., ["1 Иванов Алексей"]
            groupCombo.getItems().addAll(db.getAllGroupNames());       // e.g., ["1 ИСТ-23"]
            subjectCombo.getItems().addAll(db.getAllSubjectNames());   // e.g., ["1 Математика"]
            lessonTypeCombo.getItems().addAll(db.getAllLessonTypes()); // e.g., ["1 Лекция"]

        } catch (SQLException e) {
            showAlert("Ошибка загрузки справочников", e.getMessage());
        }
    }

    @FXML
    private void onAddLesson() {
        try {
            int teacherId = parseIdFromCombo(teacherCombo.getValue());
            int groupId = parseIdFromCombo(groupCombo.getValue());
            int subjectId = parseIdFromCombo(subjectCombo.getValue());
            int lessonTypeId = parseIdFromCombo(lessonTypeCombo.getValue());
            int hours = Integer.parseInt(hoursField.getText());

            DbHandler db = DbHandler.getInstance();
            db.insertLesson(teacherId, groupId, subjectId, lessonTypeId, hours);
            showAlert("Успех", "Занятие успешно добавлено!");
        } catch (Exception e) {
            showAlert("Ошибка ввода", e.getMessage());
        }
    }

    private int parseIdFromCombo(String value) {
        if (value == null || !value.contains(" ")) throw new IllegalArgumentException("Неверное значение");
        return Integer.parseInt(value.split(" ")[0]);
    }

    private void showAlert(String title, String msg) {
        Alert alert = new Alert(Alert.AlertType.INFORMATION);
        alert.setTitle(title);
        alert.setContentText(msg);
        alert.showAndWait();
    }
}
