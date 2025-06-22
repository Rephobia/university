package lab2;

public class Product {
	public int id;
	public String good;
	public double cena;
	public String category;
    
	public Product(int id, String good, double cena, String category) {
		this.id = id;
		this.good = good;
		this.cena = cena;
		this.category = category;
	}
	public Product() {
	}

	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}
	public void setGood(String good) {
		this.good = good;
	}
	public String getGood() {
		return good;
	}
	public double getCena() {
		return id;
	}

	public void setCena(double cena) {
		this.cena = cena;
	}
	public void setCategory(String category) {
		this.category = category;
	}
	public String getCategory() {
		return category;
	}
}
