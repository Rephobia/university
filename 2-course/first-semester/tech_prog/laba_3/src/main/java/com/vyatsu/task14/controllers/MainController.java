package com.vyatsu.task14.controllers;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.*;
import java.util.List;
import org.springframework.security.core.Authentication;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.ui.Model;

@Controller
//@RequestMapping("/main")
public class MainController {
//    @GetMapping
//    public String index() {
//        return "index";
//    }
//
//    @GetMapping("/secured")
//    public String secured() {
//        return "index";
//    }
//
    @Autowired
    private JdbcTemplate jdbcTemplate;
    
    @GetMapping("/form")
    public String showForm() {
        return "simple-form";
    }

    @PostMapping("/form")
    public String saveForm(@RequestParam(value = "name") String name, @RequestParam(value = "email") String email) {
        System.out.println(name);
        System.out.println(email);
        return "redirect:/index";
    }

    @GetMapping("/index")
    public String doSomething(Model model) {
	Authentication authentication = SecurityContextHolder.getContext().getAuthentication();
		
	String fullname = null; 
	System.out.println("test");
	if (authentication != null && authentication.isAuthenticated()) {
	    String username = authentication.getName();
			
	    List<String> results = jdbcTemplate.query("SELECT fullname FROM users WHERE username = ?", new Object[]{username}, (rs, rowNum) -> rs.getString("fullname"));

	    if (!results.isEmpty()) {
		fullname = results.get(0);
	    }
	}
		
	model.addAttribute("fullname", fullname);
        return "index";
    }
   @GetMapping("/login")
    public String loginForm() {
        return "login";
    }

/*
    @GetMapping("/hello")
    public String helloRequest(Model model, @RequestParam(value = "name") String name) {
        model.addAttribute("name", name);
        return "hello";
    }
*/

    @GetMapping("/hello/{name}")
    public String helloRequest(Model model, @PathVariable(value = "name") String name) {
        model.addAttribute("name", name);
        return "hello";
    }

//    @GetMapping("/hello")
//    public String helloRequest(Model model) {
//        model.addAttribute("name", "Bob");
//        return "hello";
//    }

    @GetMapping("/addcat")
    public String showAddCatForm(Model model) {
        Cat cat = new Cat(1L, null, null);
        model.addAttribute("cat", cat);
        return "cat-form";
    }

    @PostMapping("/addcat")
    public String showAddCatForm(@ModelAttribute(value = "cat") Cat cat) {
        System.out.println(cat.getId() + " " + cat.getName() + " " + cat.getColor());
        return "redirect:/index";
    }
}
