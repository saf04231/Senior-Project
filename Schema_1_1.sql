-- MySQL Script generated by MySQL Workbench
-- Mon Feb  4 15:37:36 2019
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `mydb` ;

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `mydb` DEFAULT CHARACTER SET utf8 ;
USE `mydb` ;

-- -----------------------------------------------------
-- Table `mydb`.`users`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `mydb`.`users` ;

CREATE TABLE IF NOT EXISTS `mydb`.`users` (
  `userID` INT NOT NULL AUTO_INCREMENT,
  `username` VARCHAR(45) NOT NULL,
  `email` VARCHAR(45) NOT NULL,
  `password` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`userID`),
  UNIQUE INDEX `userID_UNIQUE` (`userID` ASC),
  UNIQUE INDEX `email_UNIQUE` (`email` ASC),
  UNIQUE INDEX `username_UNIQUE` (`username` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`games`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `mydb`.`games` ;

CREATE TABLE IF NOT EXISTS `mydb`.`games` (
  `gameID` INT NOT NULL AUTO_INCREMENT,
  `description` VARCHAR(256) NULL,
  `DM` INT NOT NULL,
  `notes` VARCHAR(256) NULL,
  PRIMARY KEY (`gameID`),
  UNIQUE INDEX `gameID_UNIQUE` (`gameID` ASC),
  INDEX `DM_idx` (`DM` ASC),
  CONSTRAINT `DM`
    FOREIGN KEY (`DM`)
    REFERENCES `mydb`.`users` (`userID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`player_sheets`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `mydb`.`player_sheets` ;

CREATE TABLE IF NOT EXISTS `mydb`.`player_sheets` (
  `sheetID` INT NOT NULL AUTO_INCREMENT,
  `games_gameID` INT NOT NULL,
  `users_userID` INT NOT NULL,
  `name` VARCHAR(45) NOT NULL,
  `description` VARCHAR(256) NULL,
  `stats` BLOB NOT NULL,
  `inventory` BLOB NULL,
  `spells` BLOB NULL,
  PRIMARY KEY (`sheetID`),
  UNIQUE INDEX `idplayer_sheets_UNIQUE` (`sheetID` ASC),
  INDEX `fk_player_sheets_users_idx` (`users_userID` ASC),
  INDEX `fk_player_sheets_games1_idx` (`games_gameID` ASC),
  CONSTRAINT `fk_player_sheets_users`
    FOREIGN KEY (`users_userID`)
    REFERENCES `mydb`.`users` (`userID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_player_sheets_games1`
    FOREIGN KEY (`games_gameID`)
    REFERENCES `mydb`.`games` (`gameID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`maps`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `mydb`.`maps` ;

CREATE TABLE IF NOT EXISTS `mydb`.`maps` (
  `mapID` INT NOT NULL,
  `games_gameID` INT NOT NULL,
  `img` BLOB NOT NULL,
  PRIMARY KEY (`mapID`),
  INDEX `fk_maps_games1_idx` (`games_gameID` ASC),
  CONSTRAINT `fk_maps_games1`
    FOREIGN KEY (`games_gameID`)
    REFERENCES `mydb`.`games` (`gameID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`users_has_games`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `mydb`.`users_has_games` ;

CREATE TABLE IF NOT EXISTS `mydb`.`users_has_games` (
  `users_userID` INT NOT NULL,
  `games_gameID` INT NOT NULL,
  PRIMARY KEY (`users_userID`, `games_gameID`),
  INDEX `fk_users_has_games_games1_idx` (`games_gameID` ASC),
  INDEX `fk_users_has_games_users1_idx` (`users_userID` ASC),
  CONSTRAINT `fk_users_has_games_users1`
    FOREIGN KEY (`users_userID`)
    REFERENCES `mydb`.`users` (`userID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_users_has_games_games1`
    FOREIGN KEY (`games_gameID`)
    REFERENCES `mydb`.`games` (`gameID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;