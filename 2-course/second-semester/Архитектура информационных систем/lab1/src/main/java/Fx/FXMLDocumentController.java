package Fx;

import java.net.URL;
import java.util.ResourceBundle;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;

import javafx.scene.control.Label;
import javafx.scene.control.TableView;
import javafx.scene.control.cell.PropertyValueFactory;

import javafx.collections.FXCollections;
import javafx.collections.ObservableList;

import org.sqlite.JDBC;
import java.sql.*;

import javafx.scene.control.TableColumn;


public class FXMLDocumentController implements Initializable {
	@FXML
	
	private Label label;
	private ObservableList<Product> userData = FXCollections.observableArrayList();

	@FXML
	private TableView<Product> tableUsers;

	@FXML
	private TableColumn<Product, Integer> idCol;

	@FXML
	private TableColumn<Product, String> nameCol;

	@FXML
	private TableColumn<Product, Double> cenaCol;

	@FXML
	private TableColumn<Product, String> categoryCol;

	@FXML
	private void handleButtonAction(ActionEvent event) {
		System.out.println("You clicked me");
		label.setText("Hello");
	}

	@Override
	public void initialize(URL url, ResourceBundle rb) {
		initData();

		idCol.setCellValueFactory(new PropertyValueFactory<Product, Integer>("id"));
		nameCol.setCellValueFactory(new PropertyValueFactory<Product, String>("good"));
		cenaCol.setCellValueFactory(new PropertyValueFactory<Product, Double>("cena"));
		categoryCol.setCellValueFactory(new PropertyValueFactory<Product, String>("category"));

		tableUsers.setItems(userData);
	}


	private void initData() {
		try {
			DriverManager.registerDriver(new JDBC());
			Connection con = DriverManager.getConnection("jdbc:sqlite:test.db");
			Statement st = con.createStatement();
			ResultSet rs = st.executeQuery("select * from products");
			while (rs.next()) {
				Product pr = new Product();
				pr.setId(rs.getInt("id"));
				pr.setGood(rs.getString("good"));
				pr.setCena(rs.getDouble("price"));
				pr.setCategory(rs.getString("category_name"));

				userData.add(pr);
			}
		} catch (SQLException e) {
			e.printStackTrace();
		}
	}


		
}
