package home.controllers;

import home.Main;
import home.model.DBHandler;
import home.model.Purchases;
import javafx.beans.property.SimpleBooleanProperty;
import javafx.beans.property.SimpleObjectProperty;
import javafx.beans.value.ObservableValue;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.TableCell;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableView;
import javafx.scene.control.cell.PropertyValueFactory;
import javafx.scene.layout.AnchorPane;
import javafx.scene.layout.HBox;
import javafx.stage.Stage;
import javafx.util.Callback;

import javafx.scene.input.MouseEvent;
import java.io.IOException;
import java.net.URL;
import java.util.Date;
import java.util.ResourceBundle;
import java.util.logging.Logger;

public class FXMLStoreController extends BaseController implements Initializable {
    private ObservableList<Purchases> purchases = FXCollections.observableArrayList();

    @FXML
    TableView<Purchases> tablePurchases;

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

    @FXML
    TableColumn<Purchases, String> editCol;


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

        // add cell of button edit
        Callback<TableColumn<Purchases, String>, TableCell<Purchases, String>> cellFactory = (TableColumn<Purchases, String> param) -> {
            // make cell containing button
            final TableCell<Purchases, String> cell = new TableCell<Purchases, String>() {
                @Override
                public  void updateItem(String item, boolean empty){
                    super.updateItem(item, empty);
                    // that cell created only on non-empty rows
                    if(empty){
                        setGraphic(null);
                        setText(null);
                    } else{
                        Button editBtn = new Button("Редактировать");

                        // TODO set style ...

                        editBtn.setOnMouseClicked((MouseEvent event) -> {
                            Purchases selectedPurchase = tablePurchases.getSelectionModel().getSelectedItem();
                            FXMLLoader loader = new FXMLLoader();
                            loader.setLocation(getClass().getResource("/FXMLDialogUpdatePurchase.fxml"));
                            try{
                                loader.load();
                            } catch (IOException ex){
                                ex.printStackTrace();
                            }

                            DialogPurchaseController dialogPurchaseController = loader.getController();

                            dialogPurchaseController.setPurchase(selectedPurchase);
                            dialogPurchaseController.initData();

                            Parent parent = loader.getRoot();
                            Stage stage = new Stage();
                            stage.setScene(new Scene(parent));
                            stage.show();
                        });

                        setGraphic(editBtn);

                        setText(null);
                    }
                }
            };
            return cell;
        };
        editCol.setCellFactory(cellFactory);
    }

    private void showDialogUpdatePurchase(){
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
