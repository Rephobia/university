package com.vyatsu.task14.services;

import org.springframework.security.core.Authentication;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.security.core.userdetails.User;
import org.springframework.stereotype.Service;

@Service
public class CurrentUserService {

	public User getCurrentUser() {
		Authentication authentication = SecurityContextHolder.getContext().getAuthentication();
		if (authentication == null || !(authentication.getPrincipal() instanceof User)) {
			throw new IllegalStateException("No authenticated user found");
		}
		return (User) authentication.getPrincipal();
	}

	public String getCurrentUsername() {
		return getCurrentUser().getUsername();
	}
}
