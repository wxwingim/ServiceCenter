package home.model;

import javafx.collections.FXCollections;
import javafx.collections.ObservableList;

import java.sql.*;
import java.util.ArrayList;
import java.util.List;

public class DBHandler {
    private static String connectionString = "jdbc:postgresql://127.0.0.1:5432/work100022?user=postgres&password=123";
//    private static String connectionString = "jdbc:postgresql://45.10.244.15:55532/work100022?user=work100022&password=Zf#t*#o~~dSchp9nRj4R";

    private static DBHandler instance = null;
    public static  synchronized DBHandler getInstance() throws SQLException{
        if (instance == null)
            instance = new DBHandler();
        return instance;
    }

    public static ObservableList<DeviceType> getDeviceTypesList(){
        ObservableList<DeviceType> deviceTypes = FXCollections.observableArrayList();

        try {
            Connection con = DriverManager.getConnection(connectionString);
            Statement st = con.createStatement();
            ResultSet rs = st.executeQuery("SELECT id, name_type FROM device_types");

            while(rs.next()){
                DeviceType deviceType = new DeviceType(rs.getInt("id"), rs.getString("name_type"));
                deviceTypes.add(deviceType);
            }
            rs.close();
            st.close();
            con.close();
        } catch (SQLException e){
            e.printStackTrace();
        }
        return deviceTypes;
    }

    public static ObservableList<StatusRepair> getStatusesList(){
        ObservableList<StatusRepair> statusesRepair = FXCollections.observableArrayList();

        try {
            Connection con = DriverManager.getConnection(connectionString);
            Statement st = con.createStatement();
            ResultSet rs = st.executeQuery("SELECT id, name_status FROM statuses_repair");

            while(rs.next()){
                StatusRepair statusRepair = new StatusRepair(rs.getInt("id"), rs.getString("name_status"));
                statusesRepair.add(statusRepair);
            }
            rs.close();
            st.close();
            con.close();
        } catch (SQLException e){
            e.printStackTrace();
        }
        return statusesRepair;
    }

    public static ObservableList<PartType> getPartTypesList(){

        ObservableList<PartType> partTypesList = FXCollections.observableArrayList();

        try {
            Connection con = DriverManager.getConnection(connectionString);
            Statement st = con.createStatement();
            ResultSet rs = st.executeQuery("SELECT id, name_type FROM part_types");

            while(rs.next()){
                PartType partType = new PartType();
                partType.setId(rs.getInt("id"));
                partType.setName_type(rs.getString("name_type"));
                partTypesList.add(partType);
            }
            rs.close();
            st.close();
            con.close();
        } catch (SQLException e){
            e.printStackTrace();
        }
        return partTypesList;
    }

    public static ObservableList<Purchases> getAllPurchases(){
        ObservableList<Purchases> purchasesList = FXCollections.observableArrayList();

        try {
            Connection con = DriverManager.getConnection(connectionString);
            Statement st = con.createStatement();
            ResultSet rs = st.executeQuery("SELECT id, name, purchase_price, retail_price, amount, id_part_type, date_purchase, quarantee FROM purchases");

            while(rs.next()){
                Purchases purchase = new Purchases();
                purchase.setId(rs.getLong("id"));
                purchase.setName(rs.getString("name"));
                purchase.setPurchase_price(rs.getDouble("purchase_price"));
                purchase.setRetail_price(rs.getDouble("retail_price"));
                purchase.setAmount(rs.getInt("amount"));
                purchase.setId_part_type(rs.getInt("id_part_type"));
                purchase.setPartType(getPartTypeById(rs.getInt("id_part_type")));
                purchase.setDate_purchase(rs.getDate("date_purchase"));
                purchase.setGuarantee(rs.getInt("quarantee"));

                purchasesList.add(purchase);
            }
            rs.close();
            st.close();
            con.close();
        } catch (SQLException e){
            e.printStackTrace();
        }
        return purchasesList;
    }

    public static void UpdatePurchase(Purchases purchase){
        try{
            Connection con = DriverManager.getConnection(connectionString);
            PreparedStatement st = con.prepareStatement(
                    "UPDATE purchases SET purchase_price = ?, retail_price = ?, amount = ?, " +
                            "quarantee = ?, name = ?, id_part_type = ? WHERE id = ?");
            st.setObject(1, purchase.getPurchase_price());
            st.setObject(2, purchase.getRetail_price());
            st.setObject(3, purchase.getAmount());
            st.setObject(4, purchase.getGuarantee());
            st.setObject(5, purchase.getName());
            st.setObject(6, purchase.getId_part_type());
            st.setObject(7, purchase.getId());

            st.execute();
            st.close();
            con.close();
        } catch (SQLException e){
            e.printStackTrace();
        }
    }

    public static ObservableList<OrderRequest> getAllOrderRequests(){
        ObservableList<OrderRequest> orderRequests = FXCollections.observableArrayList();

        try {
            Connection con = DriverManager.getConnection(connectionString);
            Statement st = con.createStatement();
            ResultSet rs = st.executeQuery("SELECT id, addres, date_limit, date_request, defect, equipment, mechanical_damage, model, quarantee, id_device_type, id_user, id_status_type  FROM order_requests");

            while(rs.next()){
                OrderRequest order = new OrderRequest();
                order.setId(rs.getLong("id"));
                order.setAddres(rs.getString("addres"));
                order.setDate_limit(rs.getDate("date_limit"));
                order.setDate_request(rs.getDate("date_request"));
                order.setDefect(rs.getString("equipment"));
                order.setMechanical_damage(rs.getString("mechanical_damage"));
                order.setModel(rs.getString("model"));
                order.setQuarantee(rs.getBoolean("quarantee"));
                order.setDeviceType(getDeviceTypeById(rs.getInt("id_device_type")));
                order.setStatusType(getStatusRepairById(rs.getInt("id_status_type")));
                order.setUser(getUserById(rs.getLong("id_user")));
                order.setId_device_type(rs.getInt("id_device_type"));
                order.setId_status_type(rs.getInt("id_status_type"));

                orderRequests.add(order);
            }
            rs.close();
            st.close();
            con.close();
        } catch (SQLException e){
            e.printStackTrace();
        }
        return orderRequests;
    }

    private static User getUserById(Long id){
        try{
            Connection con = DriverManager.getConnection(connectionString);
            PreparedStatement st = con.prepareStatement(
                    "SELECT email, first_name, last_name, middle_name, phone FROM users WHERE id = ?");
            st.setObject(1, id);

            ResultSet rs = st.executeQuery();
            rs.next();
            User user = new User(id,
                    rs.getString(1),
                    rs.getString(2),
                    rs.getString(3),
                    rs.getString(4),
                    rs.getString(5)
            );

            st.close();
            con.close();
            return user;
        } catch (SQLException e){
            e.printStackTrace();
            return null;
        }
    }

    private static StatusRepair getStatusRepairById(Integer id){
        try{
            Connection con = DriverManager.getConnection(connectionString);
            PreparedStatement st = con.prepareStatement(
                    "SELECT id, name_status FROM statuses_repair WHERE id = ?");
            st.setObject(1, id);

            ResultSet rs = st.executeQuery();
            rs.next();
            StatusRepair statusRepair = new StatusRepair(rs.getInt(1), rs.getString(2));

            st.close();
            con.close();
            return statusRepair;
        } catch (SQLException e){
            e.printStackTrace();
            return null;
        }
    }

    private static DeviceType getDeviceTypeById(Integer id){
        try{
            Connection con = DriverManager.getConnection(connectionString);
            PreparedStatement st = con.prepareStatement(
                    "SELECT id, name_type FROM device_types WHERE id = ?");
            st.setObject(1, id);

            ResultSet rs = st.executeQuery();
            rs.next();
            DeviceType deviceType = new DeviceType(rs.getInt(1), rs.getString(2));

            st.close();
            con.close();
            return deviceType;
        } catch (SQLException e){
            e.printStackTrace();
            return null;
        }
    }

    public static PartType getPartTypeById(Integer id){
        try{
            Connection con = DriverManager.getConnection(connectionString);
            PreparedStatement st = con.prepareStatement(
                    "SELECT id, name_type FROM part_types WHERE id = ?");
            st.setObject(1, id);

            ResultSet rs = st.executeQuery();
            rs.next();
            PartType partType = new PartType(rs.getInt(1), rs.getString(2));

            st.close();
            con.close();
            return partType;

        } catch (SQLException e){
            e.printStackTrace();
            return null;
        }
    }

    public static void addPurchase(Purchases purchase){
        try{
            Connection con = DriverManager.getConnection(connectionString);
            PreparedStatement st = con.prepareStatement(
                    "INSERT INTO purchases(name, purchase_price, retail_price, amount, quarantee, id_part_type, date_purchase)" +
                            "VALUES (?, ?, ?, ?, ?, ?, now())");
            st.setObject(1, purchase.getName());
            st.setObject(2, purchase.getPurchase_price());
            st.setObject(3, purchase.getRetail_price());
            st.setObject(4, purchase.getAmount());
            st.setObject(5, purchase.getGuarantee());
            st.setObject(6, purchase.getId_part_type());

            st.execute();
            st.close();
            con.close();
        } catch (SQLException e){
            e.printStackTrace();
        }
    }

    public static ObservableList<OrderRequest> getRequestedOrders(DeviceType deviceType, StatusRepair statusRepair){
        return getAllOrderRequests().filtered(d -> d.getId_device_type() == deviceType.getId() && d.getId_status_type() == statusRepair.getId());
    }
    public static ObservableList<OrderRequest> getRequestedOrders(DeviceType deviceType){
        return getAllOrderRequests().filtered(d -> d.getId_device_type() == deviceType.getId());
    }
    public static ObservableList<OrderRequest> getRequestedOrders(StatusRepair statusRepair){
        return getAllOrderRequests().filtered(s -> s.getId_status_type() == statusRepair.getId());
    }

}
