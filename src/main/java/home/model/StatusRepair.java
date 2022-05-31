package home.model;

public class StatusRepair {
    private Integer id;
    private String name_status;

    public StatusRepair(Integer id, String name_status) {
        this.id = id;
        this.name_status = name_status;
    }
    public StatusRepair(){}

    @Override
    public String toString(){
        return String.format("%s", name_status);
    }

    // getters and setters

    public Integer getId() {
        return id;
    }

    public String getName_status() {
        return name_status;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public void setName_status(String name_status) {
        this.name_status = name_status;
    }
}
