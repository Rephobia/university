CREATE TABLE teachers (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    last_name TEXT NOT NULL,
    first_name TEXT NOT NULL,
    middle_name TEXT,
    phone TEXT,
    experience INTEGER
);

CREATE TABLE subjects (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL
);

CREATE TABLE teacher_subjects (
    teacher_id INTEGER NOT NULL,
    subject_id INTEGER NOT NULL,
    PRIMARY KEY (teacher_id, subject_id),
    FOREIGN KEY (teacher_id) REFERENCES teachers(id),
    FOREIGN KEY (subject_id) REFERENCES subjects(id)
);

CREATE TABLE groups (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    specialty TEXT NOT NULL,
    department TEXT NOT NULL,
    student_count INTEGER
);

CREATE TABLE lesson_types (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL
);

CREATE TABLE pay_rates (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    subject_id INTEGER NOT NULL,
    lesson_type_id INTEGER NOT NULL,
    rate REAL NOT NULL,
    FOREIGN KEY (subject_id) REFERENCES subjects(id),
    FOREIGN KEY (lesson_type_id) REFERENCES lesson_types(id)
);

CREATE TABLE lesson (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    teacher_id INTEGER NOT NULL,
    group_id INTEGER NOT NULL,
    subject_id INTEGER NOT NULL,
    lesson_type_id INTEGER NOT NULL,
    hours INTEGER NOT NULL,
    FOREIGN KEY (teacher_id, subject_id) REFERENCES teacher_subjects(teacher_id, subject_id)
    FOREIGN KEY (teacher_id) REFERENCES teachers(id),
    FOREIGN KEY (group_id) REFERENCES groups(id),
    FOREIGN KEY (subject_id) REFERENCES subjects(id),
    FOREIGN KEY (lesson_type_id) REFERENCES lesson_types(id)
);

INSERT INTO teachers (last_name, first_name, middle_name, phone, experience) VALUES
('Иванов', 'Алексей', 'Петрович', '+7-910-123-45-67', 10),
('Смирнова', 'Елена', 'Викторовна', '+7-912-987-65-43', 7),
('Кузнецов', 'Дмитрий', 'Андреевич', '+7-903-555-12-34', 5);

INSERT INTO subjects (name) VALUES ('Математика'), ('Физика'), ('Русский язык');

INSERT INTO teacher_subjects (teacher_id, subject_id) VALUES (1, 1);
INSERT INTO teacher_subjects (teacher_id, subject_id) VALUES (2, 2);
INSERT INTO teacher_subjects (teacher_id, subject_id) VALUES (3, 3);

INSERT INTO lesson_types (name) VALUES ('Лекция');
INSERT INTO lesson_types (name) VALUES ('Практика')
