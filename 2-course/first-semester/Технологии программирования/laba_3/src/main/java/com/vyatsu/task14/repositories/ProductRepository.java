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
import java.util.Random;
import java.util.List;

@Component
public class ProductRepository {
	private List<Product> products;
	public int pageSize = 10;
	
	@PostConstruct
	public void init() {
		products = new ArrayList<>();
		Random rnd = new Random();
		for (Long i = 1L; i < 101; i++) {
			products.add(new Product(i, "Bread" + i, rnd.nextInt(1000)));
		}
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

	public List<Product> filterProducts(int page, String title, Integer gt, Integer lt)
	{
		int from = (page - 1) * pageSize;
		int to = Math.min(from + pageSize, products.size());

		if (from > products.size()) {
			return List.of();
		}

		List<Product> paginated = products.subList(from, to);
		
		if (gt == null && lt == null && (title == null || title.isEmpty())) {
			return paginated;
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
		
		return paginated.stream()
			.filter(spec::isSatisfiedBy)
			.collect(Collectors.toList());
	}

	public int getTotalPages()
	{
		return (int) Math.ceil((double) products.size() / pageSize);
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
