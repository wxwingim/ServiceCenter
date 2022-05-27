package home.model;

import javafx.collections.FXCollections;
import javafx.collections.ObservableList;

import java.sql.*;

public class DBHandler {
    private static String connectionString = "jdbc:postgresql://127.0.0.1:5432/work100022?user=postgres&password=123";
//    private static String connectionString = "jdbc:postgresql://45.10.244.15:55532/work100022?user=work100022&password=Zf#t*#o~~dSchp9nRj4R";

    private static DBHandler instance = null;
    public static  synchronized DBHandler getInstance() throws SQLException{
        if (instance == null)
            instance = new DBHandler();
        return instance;
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
            ResultSet rs = st.executeQuery("SELECT name, purchase_price, retail_price, amount, id_part_type, date_purchase FROM purchases");

            while(rs.next()){
                Purchases purchase = new Purchases();
                purchase.setName(rs.getString("name"));
                purchase.setPurchase_price(rs.getDouble("purchase_price"));
                purchase.setRetail_price(rs.getDouble("retail_price"));
                purchase.setAmount(rs.getInt("amount"));
//                purchase.setDays_guarantee(rs.getInt("days_guarantee"));
                purchase.setId_part_type(rs.getInt("id_part_type"));
                purchase.setPartType(getPartTypeById(rs.getInt("id_part_type")));
                purchase.setDate_purchase(rs.getDate("date_purchase"));

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

//    public static ObservableList<Purchases> getAllSparePartByType(int type_id){
//        return getAllSpareParts().filtered(sp -> sp.getId_type() == type_id);
//    }

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

//    public static void addSparePart(Purchases sparePart){
//        try{
//            Connection con = DriverManager.getConnection(connectionString);
//            PreparedStatement st = con.prepareStatement(
//                    "INSERT INTO spare_part(name_sparepart, purchase_price, retail_price, amount, days_guarantee, id_type)" +
//                            "VALUES (?, ?, ?, ?, ?, ?)");
//            st.setObject(1, sparePart.getName_sparepart());
//            st.setObject(2, sparePart.getPurchase_price());
//            st.setObject(3, sparePart.getRetail_price());
//            st.setObject(4, sparePart.getAmount());
//            st.setObject(5, sparePart.getDays_guarantee());
//            st.setObject(6, sparePart.getId_type());
//
//            st.execute();
//            st.close();
//            con.close();
//        } catch (SQLException e){
//            e.printStackTrace();
//        }
//    }

}
