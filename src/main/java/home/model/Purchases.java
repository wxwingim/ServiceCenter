package home.model;

import java.sql.Date;

public class Purchases {
    private Long id;
    private String name;
    private Double purchase_price;
    private Double retail_price;
    private Date date_purchase;
    private Integer amount;
    private Integer guarantee;
    private Integer id_part_type;

    private PartType partType;

    public Purchases(){
    }

    public Purchases(Long id, String name, Double purchase_price, Double retail_price, Integer amount, Integer guarantee, Integer id_part_type){
        this.id=id;
        this.purchase_price = purchase_price;
        this.retail_price = retail_price;
        this.amount = amount;
        this.guarantee = guarantee;
        this.name = name;
        this.id_part_type = id_part_type;
    }

    public Purchases(String name, Double purchase_price, Double retail_price, Integer amount, Integer guarantee, Integer id_part_type){
        this.purchase_price = purchase_price;
        this.retail_price = retail_price;
        this.amount = amount;
        this.guarantee = guarantee;
        this.name = name;
        this.id_part_type = id_part_type;
    }

    // get and set

    public Long getId() {
        return id;
    }

    public String getName() {
        return name;
    }

    public Double getPurchase_price() {
        return purchase_price;
    }

    public Double getRetail_price() {
        return retail_price;
    }

    public Date getDate_purchase() {
        return date_purchase;
    }

    public Integer getAmount() {
        return amount;
    }

    public Integer getId_part_type() {
        return id_part_type;
    }

    public PartType getPartType() {
        return partType;
    }

    public Integer getGuarantee() {
        return guarantee;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public void setName(String name) {
        this.name = name;
    }

    public void setPurchase_price(Double purchase_price) {
        this.purchase_price = purchase_price;
    }

    public void setRetail_price(Double retail_price) {
        this.retail_price = retail_price;
    }

    public void setDate_purchase(Date date_purchase) {
        this.date_purchase = date_purchase;
    }

    public void setAmount(Integer amount) {
        this.amount = amount;
    }

    public void setId_part_type(Integer id_part_type) {
        this.id_part_type = id_part_type;
    }

    public void setPartType(PartType partType) {
        this.partType = partType;
    }

    public void setGuarantee(Integer guarantee) {
        this.guarantee = guarantee;
    }
}

