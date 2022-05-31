package home.controllers;

import home.Main;
import home.model.DBHandler;
import home.model.PartType;
import home.model.Purchases;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Button;
import javafx.scene.control.ComboBox;
import javafx.scene.control.TextField;
import javafx.stage.Stage;

import java.net.URL;
import java.util.ResourceBundle;

public class DialogPurchaseController implements Initializable {

    private ObservableList<PartType> partTypes = FXCollections.observableArrayList();
    Purchases purchase = new Purchases();

    @FXML
    ComboBox<PartType> typesComboBox;

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
    Button backButton;


    @Override
    public void initialize(URL location, ResourceBundle resources) {
        initData();
    }

    public void initData(){
        namePurchaseInput.setText(purchase.getName());
        purPriceInput.setText(purchase.getPurchase_price().toString());
        retPriceInput.setText(purchase.getRetail_price().toString());
        amountInput.setText(purchase.getAmount().toString());
        quaranteeInput.setText(purchase.getGuarantee().toString());

        partTypes = DBHandler.getPartTypesList();
        typesComboBox.setItems(partTypes);

        typesComboBox.getSelectionModel().select(DBHandler.getPartTypeById(purchase.getId_part_type()));

    }

    public void addPurchases(ActionEvent actionEvent) {
        PartType selectedType = (PartType) typesComboBox.getValue();
        purchase.setName(namePurchaseInput.getText());
        purchase.setPurchase_price(getDoubleFromTextField(purPriceInput));
        purchase.setRetail_price(getDoubleFromTextField(retPriceInput));
        purchase.setAmount(Integer.parseInt(amountInput.getText()));
        purchase.setGuarantee(Integer.parseInt(quaranteeInput.getText()));
        purchase.setId_part_type(selectedType.getId());
        DBHandler.UpdatePurchase(purchase);

        Main.getNavigation().load("/FXMLStore.fxml").Show();
        closeThis();

    }

    public void backToStore(ActionEvent actionEvent) {
        closeThis();
    }

    private void closeThis(){
        Stage stage = (Stage) backButton.getScene().getWindow();
        stage.close();
    }

    public void setPurchase(Purchases purchase) {
        this.purchase = purchase;
    }

    private double getDoubleFromTextField(TextField textField) {
        String text = textField.getText();
        return Double.parseDouble(text);
    }

}
