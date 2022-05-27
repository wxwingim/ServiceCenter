package home.controllers;

import home.Main;
import home.model.DBHandler;
import home.model.Purchases;
import javafx.beans.property.SimpleObjectProperty;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableView;
import javafx.scene.control.cell.PropertyValueFactory;

import java.net.URL;
import java.util.Date;
import java.util.ResourceBundle;

public class FXMLStoreController extends BaseController implements Initializable {
    private ObservableList<Purchases> purchases = FXCollections.observableArrayList();

    @FXML
    private TableView<Purchases> tablePurchases;

    @FXML
    TableColumn<Purchases, String> typePurchaseCol;

    @FXML
    TableColumn<Purchases, String> namePurchaseCol;

    @FXML
    TableColumn<Purchases, Double> purPriceCol;

    @FXML
    TableColumn<Purchases, Double> retPriceCol;

    @FXML
    TableColumn<Purchases, Integer> amountPurchaseCol;

    @FXML
    TableColumn<Purchases, Date> datePurchaseCol;


    @Override
    public void initialize(URL location, ResourceBundle resources) {
        initData();

        typePurchaseCol.setCellValueFactory(p -> new SimpleObjectProperty<String>(p.getValue().getPartType().getName_type()));
        namePurchaseCol.setCellValueFactory(new PropertyValueFactory<Purchases, String>("name"));
        purPriceCol.setCellValueFactory(new PropertyValueFactory<Purchases, Double>("purchase_price"));
        retPriceCol.setCellValueFactory(new PropertyValueFactory<Purchases, Double>("retail_price"));
        amountPurchaseCol.setCellValueFactory(new PropertyValueFactory<Purchases, Integer>("amount"));
        datePurchaseCol.setCellValueFactory(new PropertyValueFactory<Purchases, Date>("date_purchase"));

        tablePurchases.setItems(purchases);
    }

    private void initData(){
        purchases = DBHandler.getAllPurchases();
    }

    // navigation
    public void toOrders(ActionEvent actionEvent) {
        Main.getNavigation().load("/FXMLOrders.fxml").Show();
    }

    public void toCustomers(ActionEvent actionEvent) {
        Main.getNavigation().load("/FXMLCustomers.fxml").Show();
    }

    public void toLogin(ActionEvent actionEvent) {
        Main.getNavigation().load("/FXMLHome.fxml").Show();
    }

    public void toAddPurchase(ActionEvent actionEvent) {
        Main.getNavigation().load("/FXMLAddPurchase.fxml").Show();
    }
}
