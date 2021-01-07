-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

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
  `creation_date` DATE NULL,
  PRIMARY KEY (`company_id`),
  UNIQUE INDEX `company_id_UNIQUE` (`company_id` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `database06`.`Employee`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `database06`.`Employee` ;

CREATE TABLE IF NOT EXISTS `database06`.`Employee` (
  `employee_id` INT NOT NULL AUTO_INCREMENT,
  `company_id` INT NULL,
  `first_name` VARCHAR(50) NOT NULL,
  `last_name` VARCHAR(50) NOT NULL,
  `email` VARCHAR(100) NULL,
  `if_manager` INT NOT NULL DEFAULT 0,
  PRIMARY KEY (`employee_id`),
  UNIQUE INDEX `employee_id_UNIQUE` (`employee_id` ASC) VISIBLE,
  INDEX `company_id_idx` (`company_id` ASC) VISIBLE,
  CONSTRAINT `company_id_employee`
    FOREIGN KEY (`company_id`)
    REFERENCES `database06`.`Company` (`company_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `database06`.`LabelType`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `database06`.`LabelType` ;

CREATE TABLE IF NOT EXISTS `database06`.`LabelType` (
  `label_type_id` INT NOT NULL AUTO_INCREMENT,
  `company_id` INT NULL,
  `name` VARCHAR(50) NOT NULL DEFAULT '<niepodpisany rodzaj etykiety>',
  PRIMARY KEY (`label_type_id`),
  UNIQUE INDEX `label_type_id_UNIQUE` (`label_type_id` ASC) VISIBLE,
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
  `company_id` INT NULL,
  `label_type_id` INT NULL,
  `name` VARCHAR(30) NOT NULL,
  `description` VARCHAR(500) NULL,
  PRIMARY KEY (`label_id`),
  UNIQUE INDEX `label_id_UNIQUE` (`label_id` ASC) VISIBLE,
  UNIQUE INDEX `name_UNIQUE` (`name` ASC) VISIBLE,
  INDEX `label_type_id_idx` (`label_type_id` ASC) VISIBLE,
  INDEX `company_id_idx` (`company_id` ASC) VISIBLE,
  CONSTRAINT `label_type_id`
    FOREIGN KEY (`label_type_id`)
    REFERENCES `database06`.`LabelType` (`label_type_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
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
  `description` VARCHAR(1000) NULL,
  `start_time` DATETIME NULL,
  `deadline` DATETIME NULL,
  `status` VARCHAR(50) NOT NULL DEFAULT 'not started',
  `auto_assigned` INT NOT NULL DEFAULT 1,
  PRIMARY KEY (`task_id`, `company_id`),
  UNIQUE INDEX `task_id_UNIQUE` (`task_id` ASC) VISIBLE,
  INDEX `company_id_task_idx` (`company_id` ASC) VISIBLE,
  CONSTRAINT `company_id_task`
    FOREIGN KEY (`company_id`)
    REFERENCES `database06`.`Company` (`company_id`)
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
  `status` VARCHAR(50) NOT NULL DEFAULT 'not started',
  PRIMARY KEY (`employee_id`, `task_id`),
  INDEX `employee_id_task_idx` (`employee_id` ASC) VISIBLE,
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


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
