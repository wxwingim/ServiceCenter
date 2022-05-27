package home.model;

public class DeviceType {
    Integer id;
    String name_type;

    public DeviceType(String name_type) {
        this.name_type = name_type;
    }

    public DeviceType() {
    }

    // getters and setters
    public Integer getId() {
        return id;
    }

    public String getName_type() {
        return name_type;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public void setName_type(String name_type) {
        this.name_type = name_type;
    }
}
