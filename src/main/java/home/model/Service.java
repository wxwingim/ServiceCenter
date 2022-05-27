package home.model;

public class Service {
    public int key_service;
    public String name_service;
    public double price_service;

    public Service(){}

    public Service(int id, String name_service, double price_service){
        key_service = id;
        this.name_service = name_service;
        this.price_service = price_service;
    }

    @Override
    public String toString(){
        return String.format("ID: %s | Наименование услуги: %s | Цена: %s", key_service, name_service, price_service);
    }

    public void setPrice(double price) {
        this.price_service = price;
    }

    public void setId(int id) {
        this.key_service = id;
    }

    public void setName(String name) {
        this.name_service = name;
    }

    public double getPrice_service() {
        return price_service;
    }

    public int getKey_service() {
        return key_service;
    }

    public String getName_service() {
        return name_service;
    }
}
