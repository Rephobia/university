package lab1;

import org.sqlite.JDBC;
import java.sql.*;
import java.util.*;

public class DbHandler {
	private static final String CON_STR = "jdbc:sqlite:test.db";
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
		this.ensureTableExists();
	}
	
	public List<Product> getAllProducts() {
		try (Statement statement = this.connection.createStatement()) {
			List<Product> products = new ArrayList<Product>();
			ResultSet resultSet = statement.executeQuery("SELECT id, good, price, category_name FROM products");
           
			while (resultSet.next()) {
				products.add(new Product(resultSet.getInt("id"),
							 resultSet.getString("good"),
							 resultSet.getDouble("price"),
							 resultSet.getString("category_name")));
			}
			
			return products;
 
		} catch (SQLException e) {
			e.printStackTrace();
			return Collections.emptyList();
		}
	}

	public void addProduct(Product product) {
		String stmtStr = "INSERT INTO Products (`good`, `price`, `category_name`) VALUES (?, ?, ?)";
		try (PreparedStatement statement = this.connection.prepareStatement(stmtStr)) {
			statement.setObject(1, product.good);
			statement.setObject(2, product.price);
			statement.setObject(3, product.category_name);

			statement.execute();
		} catch (SQLException e) {
			e.printStackTrace();
		}
	}

	public void deleteProduct(int id) {
		String stmtStr = "DELETE FROM Products WHERE id = ?";
		try (PreparedStatement statement = this.connection.prepareStatement(stmtStr)) {
			statement.setObject(1, id);
			statement.execute();
		} catch (SQLException e) {
			e.printStackTrace();
		}
	}

	private void ensureTableExists() {
		String stmtStr = "CREATE TABLE IF NOT EXISTS products (id INTEGER PRIMARY KEY AUTOINCREMENT, good TEXT NOT NULL, price REAL NOT NULL, category_name TEXT NOT NULL)";
		try (Statement statement = this.connection.createStatement()) {
			statement.execute(stmtStr);
		} catch (SQLException e) {
			e.printStackTrace();
		}
	}
}
