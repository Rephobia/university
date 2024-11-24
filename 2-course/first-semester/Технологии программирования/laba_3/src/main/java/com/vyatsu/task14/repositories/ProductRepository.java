package com.vyatsu.task14.repositories;

import com.vyatsu.task14.entities.Product;
import org.springframework.stereotype.Component;
import org.springframework.data.jpa.domain.Specification;


import javax.annotation.PostConstruct;
import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

import com.vyatsu.task14.repositories.specifications.ListSpecification;
import com.vyatsu.task14.repositories.specifications.ProductSpecification;

@Component
public class ProductRepository {
	private List<Product> products;

	@PostConstruct
	public void init() {
		products = new ArrayList<>();
		products.add(new Product(1L, "Bread", 40));
		products.add(new Product(2L, "Milk", 90));
		products.add(new Product(3L, "Cheese", 200));
	}

	public List<Product> findAll() {
		return products;
	}

	public Product findByTitle(String title) {
		return products.stream().filter(p -> p.getTitle().equals(title)).findFirst().get();
	}
	
	public Product findById(Long id) {
		return products.stream().filter(p -> p.getId().equals(id)).findFirst().get();
	}

	public List<Product> filterProducts(String title, Integer gt, Integer lt)
	{
		if (gt == null && lt == null && (title == null || title.isEmpty())) {
			return products;
		}

		ListSpecification<Product> spec = ListSpecification.all();

		if (title != null && !title.isEmpty()) {
			spec = spec.and(ProductSpecification.hasTitle(title));
		}
		
		if (gt != null) {
			spec = spec.and(ProductSpecification.hasPriceGreaterThan(gt));
		}

		if (lt != null) {
			spec = spec.and(ProductSpecification.hasPriceLessThan(lt));
		}
		
		return products.stream()
			.filter(spec::isSatisfiedBy)
			.collect(Collectors.toList());
	}
	
	public void save(Product product) {
		products.add(product);
	}

	public void delete(Long id) {
		products.stream().filter(p -> p.getId().equals(id)).findFirst().ifPresent(products::remove);
	}

	public void edit(Long id, String title, Integer price) {
		products.stream()
			.filter(p -> p.getId().equals(id))
			.findFirst()
			.ifPresent(product -> {
					product.setTitle(title);
					product.setPrice(price); 
				});
	}
}
