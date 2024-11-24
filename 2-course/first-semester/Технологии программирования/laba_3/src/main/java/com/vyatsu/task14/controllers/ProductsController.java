package com.vyatsu.task14.controllers;

import com.vyatsu.task14.entities.Product;
import com.vyatsu.task14.repositories.ProductRepository;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.*;
import java.util.List;
import org.springframework.security.access.prepost.PreAuthorize;

@Controller
@RequestMapping("/products")
public class ProductsController {
	private ProductRepository productsRepository;

	@Autowired
	public void setProductsRepository(ProductRepository productsRepository) {
		this.productsRepository = productsRepository;
	}

	@GetMapping
	public String showProductsList(@RequestParam(value = "title", required = false) String title,
				       @RequestParam(value = "gt", required = false) Integer gt,
				       @RequestParam(value = "lt", required = false) Integer lt,
				       @RequestParam(defaultValue = "1", required = false) int page,
				       Model model) {
		List<Product> products = productsRepository.filterProducts(page, title, gt, lt);

		model.addAttribute("products", products);
		model.addAttribute("product", new Product());
		model.addAttribute("currentPage", page);
		model.addAttribute("totalPages", productsRepository.getTotalPages());
		model.addAttribute("size", productsRepository.pageSize);

		model.addAttribute("mostViewed", productsRepository.getTop3MostViewedProducts());

		
		return "products";
	}

	@PostMapping("/add")
	@PreAuthorize("hasRole('ADMIN')")
	public String addProduct(@ModelAttribute(value = "product")Product product) {
		productsRepository.save(product);
		return "redirect:/products";
	}

	@GetMapping("/show/{id}")
	public String showOneProduct(Model model, @PathVariable(value = "id") Long id) {
		Product product = productsRepository.findById(id);
		
		product.incrementViewCount();
		
		model.addAttribute("product", product);

		return "product-page";
	}

	@GetMapping("/edit/{id}")
	@PreAuthorize("hasRole('ADMIN')")

	public String editFormProduct(Model model, @PathVariable(value = "id") Long id) {
		Product product = productsRepository.findById(id);
		model.addAttribute("product", product);
		return "edit-product";
	}

	@PostMapping("/edit")
	@PreAuthorize("hasRole('ADMIN')")
	public String editProduct(@RequestParam(value = "id", required = false) Long id,
				  @RequestParam(value = "title", required = false) String title,
				  @RequestParam(value = "price", required = false) Integer price,
				  Model model) {
		productsRepository.edit(id, title, price);
		Product product = productsRepository.findById(id);
		model.addAttribute("product", product);
		return "edit-product";
	}
	
	@PostMapping("/delete/{id}")
	@PreAuthorize("hasRole('ADMIN')")
	public String deleteProduct(Model model, @PathVariable(value = "id") Long id) {
		productsRepository.delete(id);
		return "redirect:/products";
	}
}
