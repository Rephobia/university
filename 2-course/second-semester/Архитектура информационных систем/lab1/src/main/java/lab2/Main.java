package lab2;

import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Stage;

import java.io.IOException;

public class Main extends Application {
	
    @Override
    public void start(Stage stage) {
	    try {
		    Parent root = FXMLLoader.load(getClass().getResource("FXMLDocument.fxml"));
		    Scene scene = new Scene(root);

		    stage.setScene(scene);
		    stage.show();
	    } catch (IOException e) {
		    e.printStackTrace();
	    }
    }

    public static void main(String[] args) {
        launch(args);
    }
}
