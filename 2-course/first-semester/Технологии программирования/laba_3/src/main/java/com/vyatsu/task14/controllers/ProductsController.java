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
	public String showProductsList(@RequestParam(value = "title", required = false) String title,
				       @RequestParam(value = "gt", required = false) Integer gt,
				       @RequestParam(value = "lt", required = false) Integer lt,
				       Model model) {
		List<Product> products = productsService.filterProducts(title, gt, lt);

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

	@GetMapping("/edit/{id}")
	public String editFormProduct(Model model, @PathVariable(value = "id") Long id) {
		Product product = productsService.getById(id);
		model.addAttribute("product", product);
		return "edit-product";
	}

	@PostMapping("/edit")
	public String editProduct(@RequestParam(value = "id", required = false) Long id,
				  @RequestParam(value = "title", required = false) String title,
				  @RequestParam(value = "price", required = false) Integer price,
				  Model model) {
		productsService.edit(id, title, price);
		Product product = productsService.getById(id);
		model.addAttribute("product", product);
		return "edit-product";
	}
	
	@PostMapping("/delete/{id}")
	public String deleteProduct(Model model, @PathVariable(value = "id") Long id) {
		productsService.delete(id);
		return "redirect:/products";
	}
}
