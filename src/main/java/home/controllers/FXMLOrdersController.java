package home.controllers;

import home.Main;
import javafx.event.ActionEvent;
import javafx.fxml.Initializable;

import java.net.URL;
import java.util.ResourceBundle;

public class FXMLOrdersController extends BaseController implements Initializable {
    @Override
    public void initialize(URL location, ResourceBundle resources) {

    }


    // navigations
    public void toLogin(ActionEvent actionEvent) {
        Main.getNavigation().load("/FXMLHome.fxml").Show();
    }

    public void toStore(ActionEvent actionEvent) {
        Main.getNavigation().load("/FXMLStore.fxml").Show();
    }

    public void toCustomers(ActionEvent actionEvent) {
        Main.getNavigation().load("/FXMLCustomers.fxml").Show();
    }
}
