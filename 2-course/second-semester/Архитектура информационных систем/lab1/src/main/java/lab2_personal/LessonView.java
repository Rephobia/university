package lab2_personal;

import javafx.beans.property.*;

public class LessonView {
    private final StringProperty teacher;
    private final StringProperty subject;
    private final StringProperty group;
    private final StringProperty type;
    private final IntegerProperty hours;

    public LessonView(String teacher, String subject, String group, String type, int hours) {
	this.teacher = new SimpleStringProperty(teacher);
        this.subject = new SimpleStringProperty(subject);
        this.group = new SimpleStringProperty(group);
        this.type = new SimpleStringProperty(type);
        this.hours = new SimpleIntegerProperty(hours);
    }
    
    public StringProperty teacherProperty() {
	return teacher;
    }
    public StringProperty subjectProperty() {
	return subject;
    }
    public StringProperty groupProperty() {
	return group;
    }
    public StringProperty typeProperty() {
	return type;
    }
    public IntegerProperty hoursProperty() {
	return hours;
    }
}
