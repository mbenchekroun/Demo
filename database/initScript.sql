-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema demo_db
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema demo_db
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `demo_db` DEFAULT CHARACTER SET utf8 ;
USE `demo_db` ;

-- -----------------------------------------------------
-- Table `demo_db`.`Products`
-- -----------------------------------------------------

CREATE TABLE IF NOT EXISTS `demo_db`.`Products` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(250) NOT NULL,
  `Price` DECIMAL(10,2) NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC))
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
