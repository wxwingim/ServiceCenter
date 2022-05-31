package home.controllers;

import home.Main;
import home.model.*;
import javafx.beans.property.SimpleObjectProperty;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.ComboBox;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableView;
import javafx.scene.control.cell.PropertyValueFactory;

import java.net.URL;
import java.sql.Date;
import java.util.ResourceBundle;

public class FXMLOrdersController extends BaseController implements Initializable {

    private ObservableList<OrderRequest> orders = FXCollections.observableArrayList();
    private ObservableList<OrderRequest> filterOrders = FXCollections.observableArrayList();
    private ObservableList<DeviceType> deviceTypes = FXCollections.observableArrayList();
    private ObservableList<StatusRepair> statusesRepair = FXCollections.observableArrayList();

    @FXML
    TableView<OrderRequest> tableOrders;

    @FXML
    TableColumn<OrderRequest, Long> numberOrderCol;

    @FXML
    TableColumn<OrderRequest, String> typeDeviceCol;

    @FXML
    TableColumn<OrderRequest, String> nameModelCol;

    @FXML
    TableColumn<OrderRequest, String> statusCol;

    @FXML
    TableColumn<OrderRequest, String> fioCol;

    @FXML
    TableColumn<OrderRequest, Date> datePurCol;

    @FXML
    ComboBox<DeviceType> typeDeviceSearch;

    @FXML
    ComboBox<StatusRepair> statusOrderSearch;

    @Override
    public void initialize(URL location, ResourceBundle resources) {
        initData();

        numberOrderCol.setCellValueFactory(new PropertyValueFactory<OrderRequest, Long>("id"));
        typeDeviceCol.setCellValueFactory(p -> new SimpleObjectProperty<String>(p.getValue().getDeviceType().getName_type()));
        nameModelCol.setCellValueFactory(new PropertyValueFactory<OrderRequest, String>("model"));
        statusCol.setCellValueFactory(p -> new SimpleObjectProperty<String>(p.getValue().getStatusType().getName_status()));
        fioCol.setCellValueFactory(p -> new SimpleObjectProperty<String>(p.getValue().getUser().fullName()));
        datePurCol.setCellValueFactory(new PropertyValueFactory<OrderRequest, Date>("date_request"));

        tableOrders.setItems(filterOrders);
    }

    private void initData(){
        orders = DBHandler.getAllOrderRequests();
        filterOrders = orders;

        deviceTypes = DBHandler.getDeviceTypesList();
        statusesRepair = DBHandler.getStatusesList();

        typeDeviceSearch.setItems(deviceTypes);
        statusOrderSearch.setItems(statusesRepair);
    }

    public void removeSearch(ActionEvent actionEvent) {
        filterOrders = orders;
        tableOrders.setItems(filterOrders);
        typeDeviceSearch.setValue(null);
        statusOrderSearch.setValue(null);

    }

    public void searchOrder(ActionEvent actionEvent) {
        boolean device = !typeDeviceSearch.getSelectionModel().isEmpty();
        boolean status = !statusOrderSearch.getSelectionModel().isEmpty();
        if(device || status ){
            if(!device && status){
                filterOrders = DBHandler.getRequestedOrders(statusOrderSearch.getValue());
            }
            if(!status && device){
                filterOrders = DBHandler.getRequestedOrders(typeDeviceSearch.getValue());
            }
            if (status && device){
                filterOrders = DBHandler.getRequestedOrders(typeDeviceSearch.getValue(), statusOrderSearch.getValue());
            }
            tableOrders.setItems(filterOrders);
        }
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

    public void addNewOrder(ActionEvent actionEvent) {
    }


}
