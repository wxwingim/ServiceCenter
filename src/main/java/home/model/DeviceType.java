package home.model;

public class DeviceType {
    private Integer id;
    private String name_type;

    public DeviceType(Integer id, String name_type) {
        this.id = id;
        this.name_type = name_type;
    }

    public DeviceType() {
    }

    @Override
    public String toString(){
        return String.format("%s", name_type);
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
