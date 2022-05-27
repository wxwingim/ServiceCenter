package home.model;

public class PartType {
    private int id;
    private String name_type;

    public PartType(Integer id, String name_type){
        this.id = id;
        this.name_type = name_type;
    }
    public PartType(){}

    // getters and setters


    public int getId() {
        return id;
    }

    public String getName_type() {
        return name_type;
    }

    public void setId(int id) {
        this.id = id;
    }

    public void setName_type(String name_type) {
        this.name_type = name_type;
    }

    @Override
    public String toString(){
        return String.format("%s", name_type);
    }
}
