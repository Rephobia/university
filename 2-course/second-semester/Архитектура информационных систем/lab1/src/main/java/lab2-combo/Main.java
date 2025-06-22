package lab2_combo;

import javafx.application.Application;
import javafx.collections.ObservableList;
import javafx.scene.control.ComboBox;
import javafx.scene.control.Label;
import javafx.scene.layout.FlowPane;
import javafx.stage.Stage;
import javafx.scene.Scene;

public class Main extends Application {
	public String N;
	public int index;
	@Override
	public void start(Stage stage) {
		try {
			ComboBox<pl> comboBox = new ComboBox<pl>();
			
			ObservableList<pl> list = plContr.getProdList();
			comboBox.setItems(list);
			comboBox.getSelectionModel().select(-1);
	 
			FlowPane root = new FlowPane();	          
			root.getChildren().add(new Label("Выберите продукт:"));
			root.getChildren().add(comboBox);
	        	        
			comboBox.valueProperty().addListener((obs, oldval, newval) -> {
					if(newval != null) {
						N = newval.getName();
						index=newval.getCode();
						System.out.println("Selected product: " + N
								   + ". ID: " + index);
					}});
			
			stage.setTitle("ComboxBox Example");

			Scene scene = new Scene(root, 350, 300);
			stage.setScene(scene);
			stage.show();
		} catch(Exception e) {
			e.printStackTrace();
		}
	}

	public static void main(String[] args) {
		launch(args);
	}
}
