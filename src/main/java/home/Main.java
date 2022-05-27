package home;

import com.aquafx_project.AquaFx;
import home.controllers.FXMLHomeController;
import home.controllers.Navigation;
import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Stage;

public class Main extends Application {

    private static Navigation navigation;
    public static Navigation getNavigation()
    {
        return navigation;
    }

    @Override
    public void start(Stage stage) throws Exception {
        navigation = new Navigation(stage);
        stage.setTitle("VA navigation");
        stage.setMinHeight(700);
        stage.setMinWidth(1000);
        stage.show();

        //navigate to first view
        Main.getNavigation().load("/FXMLHome.fxml").Show();
    }

    public static void main(String[] args) {
        launch(args);
    }
}
