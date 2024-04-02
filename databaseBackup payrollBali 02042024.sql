/*
SQLyog Ultimate v11.11 (64 bit)
MySQL - 5.5.5-10.1.48-MariaDB : Database - payrollbali
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`payrollbali` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `payrollbali`;

/*Table structure for table `staffpayrollbali` */

DROP TABLE IF EXISTS `staffpayrollbali`;

CREATE TABLE `staffpayrollbali` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `fullName` varchar(255) DEFAULT NULL,
  `firstName` varchar(255) DEFAULT NULL,
  `lastName` varchar(255) DEFAULT NULL,
  `cardId` varchar(255) DEFAULT NULL,
  `empRecordId` varchar(255) DEFAULT NULL,
  `status` int(11) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=40 DEFAULT CHARSET=latin1;

/*Table structure for table `summarytimesheetbali` */

DROP TABLE IF EXISTS `summarytimesheetbali`;

CREATE TABLE `summarytimesheetbali` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `firstName` varchar(255) DEFAULT NULL,
  `lastName` varchar(255) DEFAULT NULL,
  `actualHours` varchar(255) DEFAULT NULL,
  `toBePaidHours` varchar(255) DEFAULT NULL,
  `baliBaseHourly` varchar(255) DEFAULT NULL,
  `baliOvertime` varchar(255) DEFAULT NULL,
  `baliHolidayPay` varchar(255) DEFAULT NULL,
  `baliSickPay` varchar(255) DEFAULT NULL,
  `baliFlexiTimeEarned` varchar(255) DEFAULT NULL,
  `baliFlexiTimeTaken` varchar(255) DEFAULT NULL,
  `baliOvertime15x` varchar(255) DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `staff_add` varchar(255) DEFAULT NULL,
  `update_at` datetime DEFAULT NULL,
  `staff_update` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `timesheetbali` */

DROP TABLE IF EXISTS `timesheetbali`;

CREATE TABLE `timesheetbali` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `idImport` varchar(11) DEFAULT NULL,
  `lastName` varchar(255) DEFAULT NULL,
  `firstName` varchar(255) DEFAULT NULL,
  `dateTimeSheet` datetime DEFAULT NULL,
  `clockOn` varchar(255) DEFAULT NULL,
  `clockOff` varchar(255) DEFAULT NULL,
  `breaks` varchar(255) DEFAULT NULL,
  `actualHours` varchar(255) DEFAULT NULL,
  `toBePaidHours` varchar(255) DEFAULT '0',
  `baliBaseHourly` varchar(255) DEFAULT NULL,
  `baliOvertime` varchar(255) DEFAULT NULL,
  `baliHolidayPay` varchar(255) DEFAULT NULL,
  `baliSickPay` varchar(255) DEFAULT NULL,
  `baliFlexiTimeEarned` varchar(255) DEFAULT NULL,
  `baliFlexiTimeTaken` varchar(255) DEFAULT NULL,
  `baliOvertime15x` varchar(255) DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `staff_add` varchar(255) DEFAULT NULL,
  `update_at` datetime DEFAULT NULL,
  `staff_update` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5167 DEFAULT CHARSET=latin1;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
