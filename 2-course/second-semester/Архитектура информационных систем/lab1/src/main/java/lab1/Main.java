package lab1;

import java.sql.SQLException;
import java.util.List;

public class Main {
	public static void main(String[] args) {
		try {
			DbHandler dbHandler = DbHandler.getInstance();
			dbHandler.addProduct(new Product("Музей", 200, "Развлечения"));

			List<Product> products = dbHandler.getAllProducts();
			for (Product product : products) {
				System.out.println(product.toString());
			}
			dbHandler.deleteProduct(1);			
		} catch (SQLException e) {
			e.printStackTrace();
		}

	}
}
