package lab2_personal;

import javafx.application.Application;
import javafx.geometry.Insets;
import javafx.scene.Group;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.scene.layout.GridPane;
import javafx.stage.Stage;
import javafx.collections.ObservableList;
import javafx.collections.FXCollections;
import lab1_personal.DbHandler;

import java.sql.SQLException;
import java.util.List;

public class LessonAddForm extends Application {
    
    ComboBox<String> teacherCombo = new ComboBox<>();
    ComboBox<String> groupCombo = new ComboBox<>();
    ComboBox<String> subjectCombo = new ComboBox<>();
    ComboBox<String> lessonTypeCombo = new ComboBox<>();
    TextField hoursField = new TextField();
    Button addButton = new Button("Добавить");

    Label messageLabel = new Label();

    ComboBox<String> searchTeacherCombo = new ComboBox<>();
    Button searchButton = new Button("Поиск");
    Button refreshButton = new Button("Сбросить");
    TableView<LessonView> tableView = new TableView<>();
    
    public static void main(String[] args) {
        launch(args);
    }

    @Override
    public void start(Stage stage) {
        stage.setTitle("Добавление занятия");
        Scene scene = new Scene(new Group(), 600, 250);

        try {
            DbHandler db = DbHandler.getInstance();

            teacherCombo.getItems().addAll(db.getAllTeacherNames());
            groupCombo.getItems().addAll(db.getAllGroupNames());
            subjectCombo.getItems().addAll(db.getAllSubjectNames());
            lessonTypeCombo.getItems().addAll(db.getAllLessonTypes());
	    searchTeacherCombo.getItems().addAll(db.getAllTeacherNames());
        } catch (SQLException e) {
            messageLabel.setText("Ошибка загрузки справочников: " + e.getMessage());
        }

        addButton.setOnAction(e -> {
            try {
                int teacherId = parseId(teacherCombo.getValue());
                int groupId = parseId(groupCombo.getValue());
                int subjectId = parseId(subjectCombo.getValue());
                int lessonTypeId = parseId(lessonTypeCombo.getValue());
                int hours = Integer.parseInt(hoursField.getText());

                DbHandler db = DbHandler.getInstance();
                db.insertLesson(teacherId, groupId, subjectId, lessonTypeId, hours);
                messageLabel.setText("Успешно добавлено!");
		this.refreshTable();
            } catch (Exception ex) {
                messageLabel.setText("Ошибка: " + ex.getMessage());
            }
        });

	refreshButton.setOnAction(e -> {
		this.refreshTable();
	    });

	
        searchButton.setOnAction(e -> {
		try {
		    int teacherId = parseId(searchTeacherCombo.getValue());
		    List<LessonView> lessons = DbHandler.getInstance().getLessonsByTeacher(teacherId);
		    ObservableList<LessonView> observableLessons = FXCollections.observableArrayList(lessons);
		    tableView.setItems(observableLessons);
		} catch (Exception ex) {
		    messageLabel.setText("Ошибка поиска: " + ex.getMessage());
		}
	    });


        GridPane grid = new GridPane();
        grid.setVgap(8);
        grid.setHgap(10);
        grid.setPadding(new Insets(10, 10, 10, 10));

	this.makeAddForm(grid);
	this.makeSearch(grid);
	this.makeLessonTable(grid);
	this.refreshTable();
        Group root = (Group) scene.getRoot();
        root.getChildren().add(grid);
        stage.setScene(scene);
        stage.show();
    }

    private int parseId(String value) {
        if (value == null || !value.matches("^\\d+\\s+.*$")) {
            throw new IllegalArgumentException("Неверный выбор в списке");
        }
        return Integer.parseInt(value.split(" ")[0]);
    }

    private void makeAddForm(GridPane grid) {
	grid.add(new Label("Преподаватель:"), 0, 0);
        grid.add(teacherCombo, 1, 0);

        grid.add(new Label("Группа:"), 0, 1);
        grid.add(groupCombo, 1, 1);

        grid.add(new Label("Предмет:"), 0, 2);
        grid.add(subjectCombo, 1, 2);

        grid.add(new Label("Тип занятия:"), 0, 3);
        grid.add(lessonTypeCombo, 1, 3);

        grid.add(new Label("Часы:"), 0, 4);
        grid.add(hoursField, 1, 4);

        grid.add(addButton, 0, 5);
        grid.add(messageLabel, 1, 5);
    }
    
    private void makeSearch(GridPane grid) {
	grid.add(new Separator(), 0, 6, 2, 1);
        grid.add(new Label("Поиск занятий по преподавателю:"), 0, 7);
        grid.add(searchTeacherCombo, 1, 7);
        grid.add(searchButton, 2, 7);
        grid.add(refreshButton, 3, 7);
    }

    private void makeLessonTable(GridPane grid) {
	TableColumn<LessonView, String> teacherCol = new TableColumn<>("Преподаватель");
        teacherCol.setCellValueFactory(cell -> cell.getValue().teacherProperty());
	
        TableColumn<LessonView, String> subjectCol = new TableColumn<>("Предмет");
        subjectCol.setCellValueFactory(cell -> cell.getValue().subjectProperty());

        TableColumn<LessonView, String> groupCol = new TableColumn<>("Группа");
        groupCol.setCellValueFactory(cell -> cell.getValue().groupProperty());

        TableColumn<LessonView, String> typeCol = new TableColumn<>("Тип занятия");
        typeCol.setCellValueFactory(cell -> cell.getValue().typeProperty());

        TableColumn<LessonView, Integer> hoursCol = new TableColumn<>("Часы");
        hoursCol.setCellValueFactory(cell -> cell.getValue().hoursProperty().asObject());

        tableView.getColumns().addAll(teacherCol, subjectCol, groupCol, typeCol, hoursCol);
        tableView.setPrefHeight(300);

        grid.add(tableView, 0, 8, 4, 1);
    }
    
    private void refreshTable() {
	try {
	    List<LessonView> lessons = DbHandler.getInstance().getLessonsByTeacher();
	    ObservableList<LessonView> observableLessons = FXCollections.observableArrayList(lessons);
	    tableView.setItems(observableLessons);
	    searchTeacherCombo.getSelectionModel().clearSelection();
	} catch (Exception ex) {
	    messageLabel.setText("Ошибка поиска: " + ex.getMessage());
	}	
    }
}
