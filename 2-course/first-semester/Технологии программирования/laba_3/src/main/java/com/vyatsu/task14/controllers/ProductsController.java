package com.vyatsu.task14.controllers;

import com.vyatsu.task14.entities.Product;
import com.vyatsu.task14.services.ProductsService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.*;
import java.util.List;

@Controller
@RequestMapping("/products")
public class ProductsController {
	private ProductsService productsService;

	@Autowired
	public void setProductsService(ProductsService productsService) {
		this.productsService = productsService;
	}

	@GetMapping
	public String showProductsList(@RequestParam(value = "title", required = false) String title, Model model) {
		List<Product> products;

		if (title != null && !title.isEmpty()) {
			products = productsService.getProductsByTitle(title);
		} else {
			products = productsService.getAllProducts();
		}

		model.addAttribute("products", products);
		model.addAttribute("product", new Product());

		return "products";
	}

	@PostMapping("/add")
	public String addProduct(@ModelAttribute(value = "product")Product product) {
		productsService.add(product);
		return "redirect:/products";
	}

	@GetMapping("/show/{id}")
	public String showOneProduct(Model model, @PathVariable(value = "id") Long id) {
		Product product = productsService.getById(id);
		model.addAttribute("product", product);
		return "product-page";
	}

	@PostMapping("/delete/{id}")
	public String deleteProduct(Model model, @PathVariable(value = "id") Long id) {
		productsService.delete(id);
		return "redirect:/products";
	}
}
