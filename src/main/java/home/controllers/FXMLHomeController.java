package home.controllers;

import home.Main;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.scene.Node;
import javafx.scene.layout.Pane;
import javafx.scene.layout.VBox;

import java.awt.*;
import java.io.IOException;
import java.net.URL;
import java.util.Collection;
import java.util.ResourceBundle;

public class FXMLHomeController extends BaseController implements Initializable {

    @FXML
    private Pane homeWorkspace;

    @Override
    public void initialize(URL location, ResourceBundle resources) {
    }

    public void toApp(ActionEvent actionEvent) {
        Main.getNavigation().load("/FXMLOrders.fxml").Show();
    }

//    public void toOrders(ActionEvent actionEvent) throws IOException {
//        Main.getNavigation().load("/FXMLOrders.fxml").Show();
//    }
}
