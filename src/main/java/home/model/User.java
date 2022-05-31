package home.model;

public class User {
    private Long id;
    private String email;
    private String first_name;
    private String last_name;
    private String middle_name;
    private String password;
    private String phone;
    private String position;

    public String fullName(){
        return last_name + "\n" + first_name + "\n" + middle_name;
    }

    public User(Long id, String email, String first_name, String last_name, String middle_name, String password, String phone, String position) {
        this.id = id;
        this.email = email;
        this.first_name = first_name;
        this.last_name = last_name;
        this.middle_name = middle_name;
        this.password = password;
        this.phone = phone;
        this.position = position;
    }

    public User(Long id, String email, String first_name, String last_name, String middle_name, String phone){
        this.id = id;
        this.email = email;
        this.first_name = first_name;
        this.last_name = last_name;
        this.middle_name = middle_name;
        this.phone = phone;
    }

    public User() {
    }

    // getters and setters

    public Long getId() {
        return id;
    }

    public String getEmail() {
        return email;
    }

    public String getFirst_name() {
        return first_name;
    }

    public String getLast_name() {
        return last_name;
    }

    public String getMiddle_name() {
        return middle_name;
    }

    public String getPassword() {
        return password;
    }

    public String getPhone() {
        return phone;
    }

    public String getPosition() {
        return position;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public void setPosition(String position) {
        this.position = position;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public void setFirst_name(String first_name) {
        this.first_name = first_name;
    }

    public void setLast_name(String last_name) {
        this.last_name = last_name;
    }

    public void setMiddle_name(String middle_name) {
        this.middle_name = middle_name;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public void setPhone(String phone) {
        this.phone = phone;
    }
}
