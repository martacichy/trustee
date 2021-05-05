-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema default_schema
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema database06
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `database06` ;

-- -----------------------------------------------------
-- Schema database06
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `database06` ;
USE `database06` ;

-- -----------------------------------------------------
-- Table `database06`.`Company`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `database06`.`Company` ;

CREATE TABLE IF NOT EXISTS `database06`.`Company` (
  `company_id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(100) NOT NULL,
  `creation_date` DATE NULL DEFAULT NULL,
  `login` VARCHAR(100) NULL DEFAULT NULL,
  `password` VARCHAR(100) NULL DEFAULT NULL,
  PRIMARY KEY (`company_id`),
  UNIQUE INDEX `company_id_UNIQUE` (`company_id` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `database06`.`Employee`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `database06`.`Employee` ;

CREATE TABLE IF NOT EXISTS `database06`.`Employee` (
  `employee_id` INT NOT NULL AUTO_INCREMENT,
  `company_id` INT NULL DEFAULT NULL,
  `first_name` VARCHAR(50) NOT NULL,
  `last_name` VARCHAR(50) NOT NULL,
  `email` VARCHAR(100) NULL DEFAULT NULL,
  `if_manager` INT NOT NULL DEFAULT 0,
  `login` VARCHAR(100) NULL DEFAULT NULL,
  `password` VARCHAR(100) NULL DEFAULT NULL,
  PRIMARY KEY (`employee_id`),
  UNIQUE INDEX `employee_id_UNIQUE` (`employee_id` ASC) VISIBLE,
  UNIQUE INDEX `unique_email` (`email` ASC) VISIBLE,
  INDEX `company_id_idx` (`company_id` ASC) VISIBLE,
  CONSTRAINT `company_id_employee`
    FOREIGN KEY (`company_id`)
    REFERENCES `database06`.`Company` (`company_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `database06`.`Project`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `database06`.`Project` ;

CREATE TABLE IF NOT EXISTS `database06`.`Project` (
  `project_id` INT NOT NULL AUTO_INCREMENT,
  `company_id` INT NULL DEFAULT NULL,
  `name` VARCHAR(200) NOT NULL DEFAULT '<projekt bez nazwy>',
  PRIMARY KEY (`project_id`),
  UNIQUE INDEX `project_id_UNIQUE` (`project_id` ASC) VISIBLE,
  INDEX `company_id_labeltype_idx` (`company_id` ASC) VISIBLE,
  CONSTRAINT `company_id_labeltype`
    FOREIGN KEY (`company_id`)
    REFERENCES `database06`.`Company` (`company_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `database06`.`Label`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `database06`.`Label` ;

CREATE TABLE IF NOT EXISTS `database06`.`Label` (
  `label_id` INT NOT NULL AUTO_INCREMENT,
  `company_id` INT NULL DEFAULT NULL,
  `name` VARCHAR(30) NOT NULL,
  `description` VARCHAR(500) NULL DEFAULT NULL,
  PRIMARY KEY (`label_id`),
  UNIQUE INDEX `label_id_UNIQUE` (`label_id` ASC) VISIBLE,
  INDEX `company_id_idx` (`company_id` ASC) VISIBLE,
  CONSTRAINT `company_id_label`
    FOREIGN KEY (`company_id`)
    REFERENCES `database06`.`Company` (`company_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `database06`.`EmployeeLabel`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `database06`.`EmployeeLabel` ;

CREATE TABLE IF NOT EXISTS `database06`.`EmployeeLabel` (
  `employee_id` INT NOT NULL,
  `label_id` INT NOT NULL,
  INDEX `employee_id_idx` (`employee_id` ASC) VISIBLE,
  INDEX `label_id_idx` (`label_id` ASC) VISIBLE,
  PRIMARY KEY (`label_id`, `employee_id`),
  CONSTRAINT `employee_id`
    FOREIGN KEY (`employee_id`)
    REFERENCES `database06`.`Employee` (`employee_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `label_id`
    FOREIGN KEY (`label_id`)
    REFERENCES `database06`.`Label` (`label_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `database06`.`Task`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `database06`.`Task` ;

CREATE TABLE IF NOT EXISTS `database06`.`Task` (
  `task_id` INT NOT NULL AUTO_INCREMENT,
  `company_id` INT NOT NULL,
  `name` VARCHAR(50) NOT NULL DEFAULT '<niepodpisane zadanie>',
  `description` VARCHAR(1000) NULL DEFAULT NULL,
  `start_time` DATETIME NULL DEFAULT NULL,
  `deadline` DATETIME NULL DEFAULT NULL,
  `status` VARCHAR(50) NOT NULL DEFAULT 'not started',
  `auto_assigned` INT NOT NULL DEFAULT 1,
  `project_id` INT NULL DEFAULT NULL,
  PRIMARY KEY (`task_id`, `company_id`),
  UNIQUE INDEX `task_id_UNIQUE` (`task_id` ASC) VISIBLE,
  INDEX `company_id_task_idx` (`company_id` ASC) VISIBLE,
  INDEX `project_id_idx` (`project_id` ASC) VISIBLE,
  CONSTRAINT `company_id_task`
    FOREIGN KEY (`company_id`)
    REFERENCES `database06`.`Company` (`company_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `project_id`
    FOREIGN KEY (`project_id`)
    REFERENCES `database06`.`Project` (`project_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `database06`.`EmployeeTask`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `database06`.`EmployeeTask` ;

CREATE TABLE IF NOT EXISTS `database06`.`EmployeeTask` (
  `task_id` INT NOT NULL,
  `employee_id` INT NOT NULL,
  `status` VARCHAR(50) NULL DEFAULT NULL,
  PRIMARY KEY (`employee_id`, `task_id`),
  INDEX `employee_id_task_idx` (`employee_id` ASC) VISIBLE,
  INDEX `task_id` (`task_id` ASC) VISIBLE,
  CONSTRAINT `task_id`
    FOREIGN KEY (`task_id`)
    REFERENCES `database06`.`Task` (`task_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `employee_id_task`
    FOREIGN KEY (`employee_id`)
    REFERENCES `database06`.`Employee` (`employee_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `database06`.`TaskLabel`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `database06`.`TaskLabel` ;

CREATE TABLE IF NOT EXISTS `database06`.`TaskLabel` (
  `task_id` INT NOT NULL,
  `label_id` INT NOT NULL,
  PRIMARY KEY (`label_id`, `task_id`),
  INDEX `label_id_task_idx` (`label_id` ASC) VISIBLE,
  INDEX `task_id_FK` (`task_id` ASC) VISIBLE,
  CONSTRAINT `task_id_FK`
    FOREIGN KEY (`task_id`)
    REFERENCES `database06`.`Task` (`task_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `label_id_task`
    FOREIGN KEY (`label_id`)
    REFERENCES `database06`.`Label` (`label_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `database06`.`Comment`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `database06`.`Comment` ;

CREATE TABLE IF NOT EXISTS `database06`.`Comment` (
  `comment_id` INT NOT NULL AUTO_INCREMENT,
  `task_id` INT NOT NULL,
  `employee_id` INT NOT NULL,
  `date` DATETIME NULL,
  `description` VARCHAR(1000) NULL DEFAULT NULL,
  PRIMARY KEY (`comment_id`),
  UNIQUE INDEX `comment_id_UNIQUE` (`comment_id` ASC) VISIBLE,
  INDEX `employee_id_idx` (`employee_id` ASC) VISIBLE,
  INDEX `task_id_idx` (`task_id` ASC) VISIBLE,
  CONSTRAINT `employee_id_comment`
    FOREIGN KEY (`employee_id`)
    REFERENCES `database06`.`Employee` (`employee_id`),
  CONSTRAINT `task_id_comment`
    FOREIGN KEY (`task_id`)
    REFERENCES `database06`.`Task` (`task_id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `database06`.`EmployeeProject`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `database06`.`EmployeeProject` ;

CREATE TABLE IF NOT EXISTS `database06`.`EmployeeProject` (
  `project_id` INT NOT NULL,
  `employee_id` INT NOT NULL,
  PRIMARY KEY (`employee_id`, `project_id`),
  INDEX `employee_id_task_idx` (`employee_id` ASC) VISIBLE,
  INDEX `project_id_idx` (`project_id` ASC) VISIBLE,
  CONSTRAINT `project_id_in_emppro`
    FOREIGN KEY (`project_id`)
    REFERENCES `database06`.`Project` (`project_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `employee_id_in_emppro`
    FOREIGN KEY (`employee_id`)
    REFERENCES `database06`.`Employee` (`employee_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `database06`.`File`
-- -----------------------------------------------------

DROP TABLE IF EXISTS `database06`.`File` ;

CREATE TABLE IF NOT EXISTS `database06`.`File` (
  `file_id` INT NOT NULL AUTO_INCREMENT,
  `task_id` INT NOT NULL,
  `employee_id` INT NOT NULL,
  `date` DATETIME NULL,
  `file_name` VARCHAR(256) NULL DEFAULT NULL
  `file_size` INT NULL DEFAULT NULL
  `file_rawData` BLOB NULL DEFAULT NULL,
  PRIMARY KEY (`file_id`),
  UNIQUE INDEX `file_id_UNIQUE` (`file_id` ASC) VISIBLE,
  INDEX `employee_id_idx` (`employee_id` ASC) VISIBLE,
  INDEX `task_id_idx` (`task_id` ASC) VISIBLE,
  CONSTRAINT `employee_id_file`
    FOREIGN KEY (`employee_id`)
    REFERENCES `database06`.`Employee` (`employee_id`),
  CONSTRAINT `task_id_file`
    FOREIGN KEY (`task_id`)
    REFERENCES `database06`.`Task` (`task_id`))
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
