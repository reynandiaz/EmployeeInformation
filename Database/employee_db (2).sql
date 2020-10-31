-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Oct 31, 2020 at 07:01 AM
-- Server version: 8.0.17
-- PHP Version: 7.3.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `employee_db`
--

-- --------------------------------------------------------

--
-- Table structure for table `departments`
--

CREATE TABLE `departments` (
  `DepartmentID` int(11) NOT NULL,
  `DepartmentName` varchar(50) DEFAULT NULL,
  `CreatedDate` datetime NOT NULL,
  `DeletedDate` datetime DEFAULT NULL,
  `UpdatedDate` datetime NOT NULL,
  `UpdateBy` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `departments`
--

INSERT INTO `departments` (`DepartmentID`, `DepartmentName`, `CreatedDate`, `DeletedDate`, `UpdatedDate`, `UpdateBy`) VALUES
(1, 'Software Development', '2020-10-24 09:52:40', NULL, '2020-10-24 09:52:40', '34980'),
(2, 'Accouting', '2020-10-24 09:52:59', NULL, '2020-10-24 09:52:59', '34980'),
(3, 'Administration', '2020-10-24 09:53:48', NULL, '2020-10-24 09:53:48', '34980');

-- --------------------------------------------------------

--
-- Table structure for table `employees`
--

CREATE TABLE `employees` (
  `EmployeeCode` varchar(20) NOT NULL,
  `Firstname` varchar(50) NOT NULL,
  `Middlename` varchar(50) NOT NULL,
  `Lastname` varchar(50) NOT NULL,
  `Gender` varchar(10) NOT NULL,
  `Birthdate` date NOT NULL,
  `Address` varchar(1000) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `DepartmentID` int(5) DEFAULT NULL,
  `SectionID` int(5) DEFAULT NULL,
  `DesignationID` int(5) DEFAULT NULL,
  `CreatedDate` datetime NOT NULL,
  `DeletedDate` datetime DEFAULT NULL,
  `UpdatedDate` datetime NOT NULL,
  `UpdatedBy` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `employees`
--

INSERT INTO `employees` (`EmployeeCode`, `Firstname`, `Middlename`, `Lastname`, `Gender`, `Birthdate`, `Address`, `DepartmentID`, `SectionID`, `DesignationID`, `CreatedDate`, `DeletedDate`, `UpdatedDate`, `UpdatedBy`) VALUES
('34980', 'Reynan', 'Bacit', 'Diaz', 'M', '2020-01-01', 'jan lang', 1, 3, 0, '2020-10-28 09:18:06', NULL, '2020-10-28 09:18:06', '34980'),
('37037', 'Wyane IrishAAA', 'B', 'Rollamas', 'F', '2020-01-01', 'Dun lapit layo', 1, 1, NULL, '2020-10-24 08:57:29', NULL, '2020-10-24 08:57:29', '34980'),
('37039', 'test1', 'test2', 'test3', 'M', '2020-10-27', 'testasdasdsasdfasdfasdf', 1, 2, NULL, '2020-10-28 13:44:22', NULL, '2020-10-28 13:44:22', '34980'),
('37040', 'test1', 'test2', 'test3', 'M', '2020-10-26', 'test', 1, 1, NULL, '2020-10-28 13:46:32', NULL, '2020-10-28 13:46:32', '34980'),
('37041', '1', '2', '3', 'M', '2020-10-12', 'test', 1, 1, NULL, '2020-10-28 13:47:36', NULL, '2020-10-28 13:47:36', '34980'),
('37042', '1', '1', '1', 'F', '2020-10-18', '1', 3, 2, NULL, '2020-10-28 13:48:11', NULL, '2020-10-28 13:48:11', '34980'),
('37043', '1', '1', '1', 'F', '2020-10-01', '1', 2, 2, NULL, '2020-10-28 13:48:55', NULL, '2020-10-28 13:48:55', '34980'),
('37044', '2', '22111111', '2', 'M', '2020-10-28', 'testing123', 1, 2, NULL, '2020-10-28 13:49:23', NULL, '2020-10-28 13:49:23', '34980'),
('37045', 'r', 'r', 'r', '', '2020-10-28', '', 1, 1, NULL, '2020-10-28 15:12:43', NULL, '2020-10-28 15:12:43', '34980'),
('37046', 'e', 'e', 'e', '', '2020-10-28', '', 1, 1, NULL, '2020-10-28 15:12:46', NULL, '2020-10-28 15:12:46', '34980'),
('37047', 'y', 'y', 'y', '', '2020-10-28', '', 1, 1, NULL, '2020-10-28 15:12:49', NULL, '2020-10-28 15:12:49', '34980'),
('37048', 'n', 'n', 'n', '', '2020-10-28', '', 1, 1, NULL, '2020-10-28 15:12:53', NULL, '2020-10-28 15:12:53', '34980'),
('37049', 'a', 'a', 'a', '', '2020-10-28', '', 1, 1, NULL, '2020-10-28 15:12:57', NULL, '2020-10-28 15:12:57', '34980'),
('37050', 'n', 'n', 'n', '', '2020-10-28', '', 1, 1, NULL, '2020-10-28 15:13:01', NULL, '2020-10-28 15:13:01', '34980'),
('37051', 'l', 'l', 'l', '', '2020-10-28', '', 1, 1, NULL, '2020-10-28 15:13:51', NULL, '2020-10-28 15:13:51', '34980'),
('37052', 'o', 'o', 'o', '', '2020-10-28', '', 2, 2, NULL, '2020-10-28 15:13:59', NULL, '2020-10-28 15:13:59', '34980'),
('37053', 'u', 'u', 'u', '', '2020-10-28', '', 1, 2, NULL, '2020-10-28 15:14:05', NULL, '2020-10-28 15:14:05', '34980'),
('37054', 'i', 'i', 'i', '', '2020-10-28', '', 1, 1, NULL, '2020-10-28 15:14:22', NULL, '2020-10-28 15:14:22', '34980'),
('37055', 'e', 'e', 'e', '', '2020-10-28', '', 1, 2, NULL, '2020-10-28 15:14:27', NULL, '2020-10-28 15:14:27', '34980'),
('37056', 'd', 'd', 'd', '', '2020-10-29', '', 2, 1, NULL, '2020-10-29 08:41:16', NULL, '2020-10-29 08:41:16', '34980'),
('37057', 'z', 'z', 'z', '', '2020-10-29', '', 1, 1, NULL, '2020-10-29 08:41:31', NULL, '2020-10-29 08:41:31', '34980'),
('37058', '2', '22', '2', '', '2020-10-29', '', 1, 1, NULL, '2020-10-29 08:41:42', NULL, '2020-10-29 08:41:42', '34980'),
('37059', '3', '3', '3', '', '2020-10-29', '', 3, 1, NULL, '2020-10-29 08:41:47', NULL, '2020-10-29 08:41:47', '34980'),
('37060', 'y', 'y', 'y', '', '2020-10-29', '', 2, 2, NULL, '2020-10-29 08:41:54', NULL, '2020-10-29 08:41:54', '34980'),
('37061', 'a', 'a', 'a', '', '2020-10-29', '', 2, 2, NULL, '2020-10-29 08:48:51', NULL, '2020-10-29 08:48:51', '34980'),
('37062', 'x', 'x', 'x', '', '2020-10-29', '', 1, 1, NULL, '2020-10-29 08:49:36', NULL, '2020-10-29 08:49:36', '34980'),
('37063', 'd', 'd', 'd', '', '2020-10-29', '', 2, 2, NULL, '2020-10-29 08:52:18', NULL, '2020-10-29 08:52:18', '34980'),
('37064', 'd', 'dd', 'd', '', '2020-10-29', '', 1, 2, NULL, '2020-10-29 08:55:11', NULL, '2020-10-29 08:55:11', '34980'),
('37065', 'X', 'X', 'X', '', '2020-10-29', '', 3, 1, NULL, '2020-10-29 08:56:25', NULL, '2020-10-29 08:56:25', '34980'),
('37066', '1', '1', '1', '', '2020-10-29', '', 1, 1, NULL, '2020-10-29 08:56:43', NULL, '2020-10-29 08:56:43', '34980'),
('37067', 's', 's', 's', '', '2020-10-29', '', 1, 1, NULL, '2020-10-29 08:56:56', NULL, '2020-10-29 08:56:56', '34980'),
('37068', 'a', 'a', 'a', '', '2020-10-29', '', 2, 1, NULL, '2020-10-29 09:03:55', NULL, '2020-10-29 09:03:55', '34980'),
('37069', 'A', 'A', 'A', '', '2020-10-29', '', 2, 1, NULL, '2020-10-29 13:43:59', NULL, '2020-10-29 13:43:59', '34980');

-- --------------------------------------------------------

--
-- Table structure for table `logtime`
--

CREATE TABLE `logtime` (
  `EmployeeCode` varchar(7) NOT NULL,
  `LogDate` datetime NOT NULL,
  `DepartmentCode` varchar(3) DEFAULT NULL,
  `SectionCode` varchar(5) DEFAULT NULL,
  `TimeIn` datetime DEFAULT NULL,
  `TimeOut` datetime DEFAULT NULL,
  `TransIn` varchar(10) DEFAULT NULL,
  `TransOut` varchar(10) DEFAULT NULL,
  `StartTime` datetime DEFAULT NULL,
  `EndTime` datetime DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  `UpdatedBy` varchar(7) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `logtime`
--

INSERT INTO `logtime` (`EmployeeCode`, `LogDate`, `DepartmentCode`, `SectionCode`, `TimeIn`, `TimeOut`, `TransIn`, `TransOut`, `StartTime`, `EndTime`, `CreatedDate`, `UpdatedDate`, `UpdatedBy`) VALUES
('34980', '2020-10-31 00:00:00', NULL, NULL, '2020-10-31 10:52:01', NULL, 'IN', 'OUT', '2020-10-31 10:52:02', NULL, '2020-10-31 10:52:02', '2020-10-31 10:52:02', '34980'),
('37037', '2020-10-31 00:00:00', NULL, NULL, '2020-10-31 12:38:30', NULL, 'IN', 'OUT', '2020-10-31 12:38:30', NULL, '2020-10-31 12:38:30', '2020-10-31 12:38:30', '34980');

-- --------------------------------------------------------

--
-- Table structure for table `sections`
--

CREATE TABLE `sections` (
  `SectionID` int(11) NOT NULL,
  `DepartmentID` int(11) NOT NULL,
  `SectionName` varchar(100) DEFAULT NULL,
  `CreatedDate` datetime NOT NULL,
  `DeletedDate` datetime DEFAULT NULL,
  `UpdatedDate` datetime NOT NULL,
  `UpdatedBy` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `sections`
--

INSERT INTO `sections` (`SectionID`, `DepartmentID`, `SectionName`, `CreatedDate`, `DeletedDate`, `UpdatedDate`, `UpdatedBy`) VALUES
(1, 1, 'Software Development 1', '2020-10-24 09:58:28', NULL, '2020-10-24 09:58:28', '34980'),
(1, 2, 'Tax', '2020-10-24 09:59:14', NULL, '2020-10-24 09:59:14', '34980'),
(1, 3, 'Payroll', '2020-10-24 09:59:57', NULL, '2020-10-24 09:59:57', '34980'),
(2, 1, 'Software Development 2', '2020-10-24 09:58:37', NULL, '2020-10-24 09:58:37', '34980'),
(2, 2, 'Import', '2020-10-24 09:59:26', NULL, '2020-10-24 09:59:26', '34980'),
(2, 3, 'Admin', '2020-10-24 10:00:11', NULL, '2020-10-24 10:00:11', '34980'),
(3, 1, 'Software Development 3', '2020-10-24 09:58:49', NULL, '2020-10-24 09:58:49', '34980'),
(3, 2, 'Export', '2020-10-24 09:59:38', NULL, '2020-10-24 09:59:38', '34980');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `EmployeeCode` varchar(20) NOT NULL,
  `Username` varchar(50) NOT NULL,
  `Password` varchar(50) NOT NULL,
  `UserRights` int(10) NOT NULL,
  `CreatedDate` datetime NOT NULL,
  `DeletedDate` datetime DEFAULT NULL,
  `UpdatedDate` datetime NOT NULL,
  `UpdatedBy` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`EmployeeCode`, `Username`, `Password`, `UserRights`, `CreatedDate`, `DeletedDate`, `UpdatedDate`, `UpdatedBy`) VALUES
('34980', '34980', '34980', 1, '2020-10-23 15:44:07', NULL, '2020-10-23 15:44:07', '34980');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `departments`
--
ALTER TABLE `departments`
  ADD PRIMARY KEY (`DepartmentID`);

--
-- Indexes for table `employees`
--
ALTER TABLE `employees`
  ADD PRIMARY KEY (`EmployeeCode`);

--
-- Indexes for table `logtime`
--
ALTER TABLE `logtime`
  ADD PRIMARY KEY (`EmployeeCode`,`LogDate`);

--
-- Indexes for table `sections`
--
ALTER TABLE `sections`
  ADD PRIMARY KEY (`SectionID`,`DepartmentID`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`EmployeeCode`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
