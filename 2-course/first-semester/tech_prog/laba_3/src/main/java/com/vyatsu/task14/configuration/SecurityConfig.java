package com.vyatsu.task14.configuration;

import org.springframework.security.config.annotation.authentication.builders.AuthenticationManagerBuilder;
import org.springframework.security.config.annotation.method.configuration.EnableGlobalMethodSecurity;
import org.springframework.security.config.annotation.web.builders.HttpSecurity;
import org.springframework.security.config.annotation.web.configuration.EnableWebSecurity;
import org.springframework.security.config.annotation.web.configuration.WebSecurityConfigurerAdapter;

import org.springframework.context.annotation.Configuration;
import javax.sql.DataSource;
import org.springframework.beans.factory.annotation.Autowired;

@Configuration
@EnableWebSecurity
@EnableGlobalMethodSecurity(prePostEnabled = true)
public class SecurityConfig  extends WebSecurityConfigurerAdapter {
   private DataSource dataSource;

   @Autowired
   public void setDataSource(DataSource dataSource) {
       this.dataSource = dataSource;
   }

   @Override
   protected void configure(AuthenticationManagerBuilder auth) throws Exception { // (1)
       auth.jdbcAuthentication().dataSource(dataSource);
   }

	
   // @Override
   // protected void configure(AuthenticationManagerBuilder auth) throws Exception { // (2)
       // User.UserBuilder users = User.withDefaultPasswordEncoder();
       // auth.inMemoryAuthentication()
               // .withUser(users.username("user1").password("pass1").roles("USER", "ADMIN"))
               // .withUser(users.username("user2").password("pass2").roles("USER"));
   // }

   @Override
   protected void configure(HttpSecurity http) throws Exception {
       http.authorizeRequests()
               .anyRequest().permitAll()
               .antMatchers("/secured/**").hasAnyRole("ADMIN")
               .and()
               .formLogin()
               .loginPage("/login")
               .loginProcessingUrl("/authenticateTheUser")
	       .defaultSuccessUrl("/decks", true)
               .permitAll()
	       .and()
	       .logout()
	       .logoutUrl("/logout")
	       .logoutSuccessUrl("/decks")
	       .permitAll();
   }
}

