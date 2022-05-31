package home.model;

import java.sql.Date;

public class OrderRequest {
    private Long id;
    private String addres;
    private Date date_limit;
    private Date date_request;
    private String defect;
    private String equipment;
    private String mechanical_damage;
    private String model;
    private Boolean quarantee;
    private Integer id_device_type;
    private Integer id_user;
    private Integer id_status_type;

    DeviceType deviceType;
    User user;
    StatusRepair statusType;

    public OrderRequest(String addres, Date date_limit, String defect, String equipment, String mechanical_damage, String model, Boolean quarantee, Integer id_device_type, Integer id_user, Integer id_status_type) {
        this.addres = addres;
        this.date_limit = date_limit;
        this.defect = defect;
        this.equipment = equipment;
        this.mechanical_damage = mechanical_damage;
        this.model = model;
        this.quarantee = quarantee;
        this.id_device_type = id_device_type;
        this.id_user = id_user;
        this.id_status_type = id_status_type;
    }
    public OrderRequest(){}

    // getters and setters
    public Long getId() {
        return id;
    }

    public String getAddres() {
        return addres;
    }

    public Date getDate_limit() {
        return date_limit;
    }

    public Date getDate_request() {
        return date_request;
    }

    public String getDefect() {
        return defect;
    }

    public String getEquipment() {
        return equipment;
    }

    public String getMechanical_damage() {
        return mechanical_damage;
    }

    public String getModel() {
        return model;
    }

    public Boolean getQuarantee() {
        return quarantee;
    }

    public Integer getId_device_type() {
        return id_device_type;
    }

    public Integer getId_user() {
        return id_user;
    }

    public Integer getId_status_type() {
        return id_status_type;
    }

    public DeviceType getDeviceType() {
        return deviceType;
    }

    public User getUser() {
        return user;
    }

    public StatusRepair getStatusType() {
        return statusType;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public void setAddres(String addres) {
        this.addres = addres;
    }

    public void setDate_limit(Date date_limit) {
        this.date_limit = date_limit;
    }

    public void setDate_request(Date date_request) {
        this.date_request = date_request;
    }

    public void setDefect(String defect) {
        this.defect = defect;
    }

    public void setEquipment(String equipment) {
        this.equipment = equipment;
    }

    public void setMechanical_damage(String mechanical_damage) {
        this.mechanical_damage = mechanical_damage;
    }

    public void setModel(String model) {
        this.model = model;
    }

    public void setQuarantee(Boolean quarantee) {
        this.quarantee = quarantee;
    }

    public void setId_device_type(Integer id_device_type) {
        this.id_device_type = id_device_type;
    }

    public void setId_user(Integer id_user) {
        this.id_user = id_user;
    }

    public void setId_status_type(Integer id_status_type) {
        this.id_status_type = id_status_type;
    }

    public void setDeviceType(DeviceType deviceType) {
        this.deviceType = deviceType;
    }

    public void setUser(User user) {
        this.user = user;
    }

    public void setStatusType(StatusRepair statusType) {
        this.statusType = statusType;
    }
}
