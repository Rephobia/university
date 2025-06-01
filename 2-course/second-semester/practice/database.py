import sqlite3

class Database:
    conn = sqlite3.connect('library.db')
    conn.row_factory = sqlite3.Row
    
    @staticmethod
    def create_table():
        Database.conn.execute('''
            CREATE TABLE IF NOT EXISTS entities (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                type TEXT NOT NULL,
                name TEXT NOT NULL,
                author TEXT NOT NULL,
                price REAL NOT NULL,
                narrator TEXT,
                duration TEXT
            )
        ''')
        Database.conn.commit()
        
    @staticmethod
    def store(entity):
        fields = entity.get_fields()
        fields.pop('id', None)
        fields['type'] = entity.type()
        
        column_names = ", ".join(fields.keys())
        placeholders = ", ".join("?" for _ in fields)
    
        Database.conn.execute(
            f'INSERT INTO entities ({column_names}) VALUES ({placeholders})',
            tuple(fields.values())
        )

        Database.conn.commit()

    @staticmethod
    def update(entity):
        fields = entity.get_fields()
        fields.pop('id', None)
        
        set_clause = ", ".join(f"{field}=?" for field in fields.keys())
        sql = f"UPDATE entities SET {set_clause} WHERE id=?"
        Database.conn.execute(sql, list(fields.values()) + [entity.id])
        Database.conn.commit()

    @staticmethod
    def delete(entity_id):
        Database.conn.execute('DELETE FROM entities WHERE id=?', (entity_id,))
        Database.conn.commit()

    @staticmethod
    def get_all():
        cursor = Database.conn.execute('SELECT * FROM entities')
        return cursor.fetchall()

    @staticmethod
    def clear_db():
        Database.conn.execute('DELETE FROM entities')
        Database.conn.commit()
