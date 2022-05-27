package home.controllers;

import home.Main;
import home.model.DBHandler;
import home.model.PartType;
import home.model.Purchases;
import javafx.beans.property.SimpleObjectProperty;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.ComboBox;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableView;
import javafx.scene.control.TextField;
import javafx.scene.control.cell.PropertyValueFactory;

import java.net.URL;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.ResourceBundle;

public class FXMLAddPurchaseController extends BaseController implements Initializable {

    private ObservableList<PartType> partTypes = FXCollections.observableArrayList();
    private ObservableList<Purchases> possiblePurchases = FXCollections.observableArrayList();

    @FXML
    ComboBox typesComboBox;

    @FXML
    TextField namePurchaseInput;

    @FXML
    TextField purPriceInput;

    @FXML
    TextField retPriceInput;

    @FXML
    TextField amountInput;

    @FXML
    TextField quaranteeInput;

    @FXML
    TableView tableNewPurchases;

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
    }

    public void addPurchases(ActionEvent actionEvent) {
        PartType selectedType = (PartType) typesComboBox.getValue();

        Purchases newPurchase = new Purchases(
                namePurchaseInput.getText(),
                getDoubleFromTextField(purPriceInput),
                getDoubleFromTextField(retPriceInput),
                Integer.parseInt(amountInput.getText()),
                Integer.parseInt(quaranteeInput.getText()),
                selectedType.getId()
        );

        newPurchase.setPartType(DBHandler.getPartTypeById(newPurchase.getId_part_type()));
        possiblePurchases.add(newPurchase);

        ObservableList<Purchases> purchases = possiblePurchases;
        tableNewPurchases.setItems(purchases);

    }

    public void saveAddPurchases(ActionEvent actionEvent) {
        if(possiblePurchases.size() != 0){
            for(Purchases purchase: possiblePurchases){
                DBHandler.addPurchase(purchase);
            }
        }
        Main.getNavigation().load("/FXMLStore.fxml").Show();
    }

    private void initData(){
        partTypes = DBHandler.getPartTypesList();
        typesComboBox.setItems(partTypes);
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

    public void toStore(ActionEvent actionEvent) {
        Main.getNavigation().load("/FXMLStore.fxml").Show();

    }

    private double getDoubleFromTextField(TextField textField) {
        String text = textField.getText();
        return Double.parseDouble(text);
    }


}
