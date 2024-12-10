-- SET search_path TO boot;

CREATE TABLE deck (
    id SERIAL PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    username VARCHAR(255) NOT NULL,
    second_period BIGINT NOT NULL,
    third_period BIGINT NOT NULL,
    CONSTRAINT fk_username FOREIGN KEY (username) REFERENCES users(username)
);
