-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 30, 2024 at 04:15 PM
-- Server version: 10.4.28-MariaDB
-- PHP Version: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `clinicinfosys`
--

DELIMITER $$
--
-- Procedures
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetPatientInfo` (IN `patientIDParam` INT)   BEGIN
    # Declare variables to store the details of the patient
    DECLARE patientFirstName VARCHAR(50);
    DECLARE patientLastName VARCHAR(50);

    # To retrieve patient details
    SELECT PFirstName, PLastName
    INTO patientFirstName, patientLastName
    FROM patients
    WHERE PatientID = patientIDParam;

    # to display the patient's details
    SELECT 'Patient ID:', patientIDParam AS 'ID', patientFirstName AS 'First Name', patientLastName AS 'Last Name';

    # to display the patient's appointments
    SELECT 'Appointments:' AS Info;
    SELECT AppointmentID, AppointmentDate, Notes 
    FROM appointments
    WHERE PatientID = patientIDParam;

    # to display the patient's needed treatments
    SELECT 'Treatments:' AS Info;
    SELECT TreatmentID, TreatmentType, Treat_Cost, Treat_Date
    FROM treatments
    WHERE PatientID = patientIDParam;

    # to display the patient's prescriptions by the doctor
    SELECT 'Prescriptions:' AS Info;
    SELECT PrescriptionID, Medication, Dosage, Frequency
    FROM prescriptions
    WHERE PatientID = patientIDParam;
END$$

--
-- Functions
--
CREATE DEFINER=`root`@`localhost` FUNCTION `CalculateTotalTreatmentCost` (`patientIDParam` INT) RETURNS DECIMAL(10,2) READS SQL DATA BEGIN
	# declare variable to store the total treatment cost
    DECLARE totalCost DECIMAL(10, 2);
 
	# calculates the total treatment cost
    SELECT COALESCE(SUM(T.Treat_Cost), 0.00)
    INTO totalCost
	FROM treatments T
	WHERE T.PatientID = patientIDParam;
 
    # to return the result
    RETURN totalCost;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `appointments`
--

CREATE TABLE `appointments` (
  `AppointmentID` int(11) NOT NULL,
  `PatientID` int(11) DEFAULT NULL,
  `DoctorID` int(11) DEFAULT NULL,
  `AppointmentDate` datetime DEFAULT NULL,
  `Notes` varchar(300) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `appointments`
--

INSERT INTO `appointments` (`AppointmentID`, `PatientID`, `DoctorID`, `AppointmentDate`, `Notes`) VALUES
(202, 2, 102, '2024-01-05 10:00:00', 'Follow-up visit'),
(203, 3, 102, '2024-01-07 01:30:00', 'Follow-up visit'),
(204, 4, 106, '2024-01-07 09:00:00', 'Annual Check-up'),
(205, 5, 107, '2024-02-15 12:00:00', 'Follow-up visit'),
(206, 6, 108, '2024-02-01 09:35:01', 'Annual Check-up'),
(207, 7, 109, '2024-02-01 14:20:00', 'Annual Check-up'),
(208, 8, NULL, '2024-02-01 11:00:03', 'Follow-up visit'),
(209, 9, 103, '2024-02-01 13:10:00', 'Follow-up visit'),
(210, 10, 101, '2024-02-01 09:00:00', 'Follow-up visit'),
(214, 12, 104, '2024-02-20 15:30:00', 'New appointment for testing'),
(215, 10, 109, '2024-02-20 15:30:00', 'New appointment for testing'),
(216, 10, 102, '2024-02-20 15:30:00', 'New appointment for testing'),
(220, 3, 108, '2024-02-20 10:30:00', 'New appointment for testing'),
(221, 12, 104, '2024-02-20 15:30:00', 'New appointment for testing'),
(223, 12, 107, '2024-02-21 15:30:00', 'New appointment'),
(224, 2, 107, '2024-03-21 15:30:00', 'New appointment'),
(225, 3, 107, '2024-03-21 15:30:00', 'New appointment'),
(226, 3, 107, '2024-02-20 10:30:00', 'New appointment'),
(228, 12, 104, '2024-02-20 15:30:00', 'New appointmentdate for testing'),
(229, 12, 108, '2024-02-20 15:30:00', 'New appointmentdate for testing'),
(230, 12, 108, '2024-02-20 15:30:00', 'New appointmentdate for testing'),
(233, 12, 104, '2024-02-20 15:30:00', 'New appointmentdate for testing'),
(234, 12, 104, '2024-02-20 15:30:00', 'New appointmentdate for testing'),
(237, 12, 104, '2024-02-20 15:30:00', 'New appointment for testing'),
(238, 3, 108, '2024-02-20 10:30:00', 'New appointment for testing'),
(239, 12, 104, '2024-02-20 15:30:00', 'New appointmentdate');

--
-- Triggers `appointments`
--
DELIMITER $$
CREATE TRIGGER `on_appointment_delete` BEFORE DELETE ON `appointments` FOR EACH ROW BEGIN
    # Check if the appointment exists and if it is associated with a doctor
    IF OLD.DoctorID IS NOT NULL THEN
        # Update the doctor's schedule by decrementing the appointment count
        UPDATE doctors
        SET AppointmentCount = AppointmentCount - 1  -- Fix: Use correct column name
        WHERE DoctorID = OLD.DoctorID;
    END IF;
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `on_appointment_insert` AFTER INSERT ON `appointments` FOR EACH ROW BEGIN
	-- Update the doctor's schedule by incrementing the appointment count
    UPDATE doctors
    SET AppointmentCount = AppointmentCount + 1
    WHERE DoctorID = NEW.DoctorID;
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `on_appointment_update` BEFORE UPDATE ON `appointments` FOR EACH ROW BEGIN
    -- Check if the new appointment date is in the past
    IF NEW.AppointmentDate < NOW() THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Cannot update appointment to a past date';
    END IF;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Stand-in structure for view `doctorprescriptions`
-- (See below for the actual view)
--
CREATE TABLE `doctorprescriptions` (
`DoctorID` int(11)
,`DoctorFirstName` varchar(50)
,`DoctorLastName` varchar(50)
,`Medication` varchar(50)
,`Dosage` varchar(30)
,`Frequency` varchar(100)
);

-- --------------------------------------------------------

--
-- Table structure for table `doctors`
--

CREATE TABLE `doctors` (
  `DoctorID` int(11) NOT NULL,
  `DFirstName` varchar(50) NOT NULL,
  `DLastName` varchar(50) NOT NULL,
  `DSpecialization` varchar(50) DEFAULT NULL,
  `DContactNum` varchar(15) DEFAULT NULL,
  `AppointmentsCount` int(11) DEFAULT 0,
  `AppointmentCount` int(11) DEFAULT 0,
  `gender` varchar(10) DEFAULT NULL,
  `address` varchar(255) DEFAULT NULL,
  `birthdate` date DEFAULT NULL,
  `username` varchar(50) DEFAULT NULL,
  `password` varchar(50) DEFAULT NULL,
  `status` varchar(10) NOT NULL DEFAULT 'Active'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `doctors`
--

INSERT INTO `doctors` (`DoctorID`, `DFirstName`, `DLastName`, `DSpecialization`, `DContactNum`, `AppointmentsCount`, `AppointmentCount`, `gender`, `address`, `birthdate`, `username`, `password`, `status`) VALUES
(100, 'Dr. Jacobson', 'Brazenos', 'Pediatrics', '09123456990', 1, 0, 'Male', 'Daraga, Albay', '1979-11-21', 'Jacobson', 'abcd', 'Active'),
(101, 'Dr. Ella Mae', 'Consi', 'Dermatology', '09234576800', 0, 0, 'Female', 'Castila, Sorsogon', '1968-02-11', 'Ella Mae', '1234', 'Active'),
(102, 'Dr. Diana', 'Santos', 'Dermatology', '09123456789', 1, 0, 'Female', 'Pilar, Sorsogon', '2001-05-04', 'Diana', '2468', 'Active'),
(103, 'Dr. Josephos', 'Cruz', 'ENT', '09876543210', 0, 0, 'Male', 'Tagas, Daraga', '2001-05-04', 'Josephos', '12345', 'Active'),
(104, 'Dr. Herodes', 'Job', 'Cadiology', '09786576542', 0, 1, 'Female', 'Camalig Albay', '2003-04-04', 'Herodes', 'bcda', 'Active'),
(106, 'Er. James', 'Sotto', 'Ophthalmology', '09812345678', 0, 0, 'Male', 'Legazpi City', '2003-12-27', 'James', 'amen', 'Active'),
(107, 'Dr. Dix', 'Balbuena', 'Orthopedics', '09564321121', -1, 6, 'Male', 'Metropolican Manila', '2003-04-04', 'Dix', 'hello', 'Active'),
(108, 'Dr. Anthony', 'Leodones', 'Neurology', '09547877632', 0, 4, 'Male', 'Makati City', '1992-10-30', 'Anthony', 'hahaha', 'Active'),
(109, 'Dr. Rebecca', 'Rob', 'Pediatrics', '09356788971', 1, 0, 'Female', 'Alabang', '2003-01-20', 'Rebecca', 'syempre', 'Active'),
(110, 'Dr. Jacob', 'Brazeno', 'Pediatrics', '09123456990', 1, 0, 'Male', 'Rizal', '2001-05-04', 'Jacob', 'noway', 'Active'),
(112, 'Dr. Jen', 'Corteza', 'Pediatrics', '09923455678', 0, 0, 'Female', 'Tiwi', '2003-04-04', 'jennie', 'jen0414', 'Active'),
(115, 'Dr. James', 'Olarte', 'ENT', '09369871234', 0, 0, 'Male', 'Tabaco', '2002-11-27', 'james', 'james123', 'Active');

-- --------------------------------------------------------

--
-- Stand-in structure for view `patientappointmentswithdoctors`
-- (See below for the actual view)
--
CREATE TABLE `patientappointmentswithdoctors` (
`AppointmentID` int(11)
,`PatientFirstName` varchar(50)
,`PatientLastName` varchar(50)
,`DoctorFirstName` varchar(50)
,`DoctorLastName` varchar(50)
,`AppointmentDate` datetime
,`Notes` varchar(300)
);

-- --------------------------------------------------------

--
-- Table structure for table `patients`
--

CREATE TABLE `patients` (
  `PatientID` int(11) NOT NULL,
  `PFirstName` varchar(50) NOT NULL,
  `PLastName` varchar(50) NOT NULL,
  `PAddress` varchar(100) DEFAULT NULL,
  `PDateOfBirth` date DEFAULT current_timestamp(),
  `PGender` varchar(10) DEFAULT NULL,
  `PContactNum` varchar(15) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `patients`
--

INSERT INTO `patients` (`PatientID`, `PFirstName`, `PLastName`, `PAddress`, `PDateOfBirth`, `PGender`, `PContactNum`) VALUES
(1, 'Johnny', 'Bravo', 'Legazpi', '2019-05-15', 'M', '0923456789'),
(2, 'Jenny', 'Bron', 'Daraga', '2002-07-15', 'F', '0923456000'),
(3, 'Jessica', 'Bras', 'Orosite', '1990-02-15', 'F', '0922458780'),
(4, 'Dave', 'Orlian', 'Tiwi', '1970-11-20', 'M', '0936456788'),
(5, 'Jimmy', 'Farlon', 'Tabaco', '2003-04-04', 'M', '0935466786'),
(6, 'Riza', 'Kraken', 'Tiwi', '1999-12-25', 'F', '0993456709'),
(7, 'Jerico', 'Gonzales', 'Bacacay', '1998-05-16', 'M', '0922256789'),
(8, 'Liza', 'Chu', 'Legazpi', '2000-01-02', 'F', '0926476082'),
(9, 'Chris', 'Lim', 'Sto. Domingo', '2001-08-15', 'M', '0925556789'),
(10, 'Jona', 'Lee', 'San Jose', '1999-03-30', 'F', '09205678400'),
(12, 'John', 'Doe', 'Test Address', '1990-01-01', 'M', '1234567890'),
(22, 'John', 'Doe', 'Test Address', '1990-01-01', 'M', '1234567890');

-- --------------------------------------------------------

--
-- Table structure for table `prescriptions`
--

CREATE TABLE `prescriptions` (
  `PrescriptionID` int(11) NOT NULL,
  `PatientID` int(11) DEFAULT NULL,
  `DoctorID` int(11) DEFAULT NULL,
  `Medication` varchar(50) DEFAULT NULL,
  `Dosage` varchar(30) DEFAULT NULL,
  `Frequency` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `prescriptions`
--

INSERT INTO `prescriptions` (`PrescriptionID`, `PatientID`, `DoctorID`, `Medication`, `Dosage`, `Frequency`) VALUES
(401, 1, 100, 'Aspirin', '100mg', 'Daily'),
(402, 2, 102, 'Amoxicillin', '250mg', 'Twice daily'),
(403, 3, 102, 'Ibuprofen', '200mg', 'Twice daily'),
(404, 4, 106, 'Acetaminophen', '500mg', '3x a day'),
(405, 5, 107, 'Cetirizine', '10mg', 'Daily'),
(406, 6, 108, 'Vitamin D Supplement', '1000IU', 'Daily'),
(407, 7, 109, 'Eye Drops (Lubricant)', '2 drops', 'Twice daily'),
(408, 8, NULL, 'Insulin', '20 units', 'Once a day'),
(409, 9, 103, 'Diclofenac', '50mg', 'Daily'),
(410, 10, 101, 'Omeprazole', '20mg', 'Daily');

-- --------------------------------------------------------

--
-- Stand-in structure for view `totaltreatmentcostperpatient`
-- (See below for the actual view)
--
CREATE TABLE `totaltreatmentcostperpatient` (
`PatientID` int(11)
,`PatientFirstName` varchar(50)
,`PatientLastName` varchar(50)
,`TotalTreatmentCost` decimal(32,2)
);

-- --------------------------------------------------------

--
-- Table structure for table `treatments`
--

CREATE TABLE `treatments` (
  `TreatmentID` int(11) NOT NULL,
  `PatientID` int(11) DEFAULT NULL,
  `DoctorID` int(11) DEFAULT NULL,
  `TreatmentType` varchar(50) DEFAULT NULL,
  `Treat_Cost` decimal(10,2) DEFAULT NULL,
  `Treat_Date` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `treatments`
--

INSERT INTO `treatments` (`TreatmentID`, `PatientID`, `DoctorID`, `TreatmentType`, `Treat_Cost`, `Treat_Date`) VALUES
(301, 1, 100, 'Medication', 50.00, '2024-02-01 09:00:00'),
(302, 2, 102, 'Medication', 500.00, '2024-01-05 10:00:00'),
(303, 3, 102, 'Medication', 1000.00, '2024-02-01 09:00:00'),
(304, 4, 106, 'Medication', 500.00, '2024-01-07 01:30:00'),
(305, 5, 107, 'Medication', 800.00, '2024-01-07 09:00:00'),
(306, 6, 108, 'Medication', 1000.00, '2024-02-01 09:40:00'),
(307, 7, 109, 'Medication', 950.00, '2024-02-01 14:20:00'),
(308, 8, NULL, 'Medication', 2000.00, '2024-02-01 11:00:03'),
(309, 9, 103, 'X-ray', 500.00, '2024-02-01 13:10:00'),
(310, 10, 101, 'Medication', 799.00, '2024-02-01 09:00:00');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `username` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `role` enum('admin','doctor') NOT NULL,
  `email` varchar(255) DEFAULT NULL,
  `Secu1_Answer` varchar(255) DEFAULT NULL,
  `Secu2_Answer` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `username`, `password`, `role`, `email`, `Secu1_Answer`, `Secu2_Answer`) VALUES
(1, 'admin', 'admin123', 'admin', 'admin04@gmail.com', 'Corteza', 'Loki'),
(2, 'doctor', 'doc123', 'doctor', 'doctor02@gmail.com', 'Uchiha', 'Cookie');

-- --------------------------------------------------------

--
-- Structure for view `doctorprescriptions`
--
DROP TABLE IF EXISTS `doctorprescriptions`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `doctorprescriptions`  AS SELECT `p`.`DoctorID` AS `DoctorID`, `d`.`DFirstName` AS `DoctorFirstName`, `d`.`DLastName` AS `DoctorLastName`, `p`.`Medication` AS `Medication`, `p`.`Dosage` AS `Dosage`, `p`.`Frequency` AS `Frequency` FROM (`prescriptions` `p` join `doctors` `d` on(`p`.`DoctorID` = `d`.`DoctorID`)) ;

-- --------------------------------------------------------

--
-- Structure for view `patientappointmentswithdoctors`
--
DROP TABLE IF EXISTS `patientappointmentswithdoctors`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `patientappointmentswithdoctors`  AS SELECT `a`.`AppointmentID` AS `AppointmentID`, `p`.`PFirstName` AS `PatientFirstName`, `p`.`PLastName` AS `PatientLastName`, `d`.`DFirstName` AS `DoctorFirstName`, `d`.`DLastName` AS `DoctorLastName`, `a`.`AppointmentDate` AS `AppointmentDate`, `a`.`Notes` AS `Notes` FROM ((`appointments` `a` join `patients` `p` on(`a`.`PatientID` = `p`.`PatientID`)) join `doctors` `d` on(`a`.`DoctorID` = `d`.`DoctorID`)) ;

-- --------------------------------------------------------

--
-- Structure for view `totaltreatmentcostperpatient`
--
DROP TABLE IF EXISTS `totaltreatmentcostperpatient`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `totaltreatmentcostperpatient`  AS SELECT `t`.`PatientID` AS `PatientID`, `p`.`PFirstName` AS `PatientFirstName`, `p`.`PLastName` AS `PatientLastName`, sum(`t`.`Treat_Cost`) AS `TotalTreatmentCost` FROM (`treatments` `t` join `patients` `p` on(`t`.`PatientID` = `p`.`PatientID`)) GROUP BY `t`.`PatientID`, `p`.`PatientID`, `p`.`PFirstName`, `p`.`PLastName` ;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `appointments`
--
ALTER TABLE `appointments`
  ADD PRIMARY KEY (`AppointmentID`),
  ADD KEY `appointments_ibfk_1` (`PatientID`),
  ADD KEY `appointments_ibfk_2` (`DoctorID`);

--
-- Indexes for table `doctors`
--
ALTER TABLE `doctors`
  ADD PRIMARY KEY (`DoctorID`);

--
-- Indexes for table `patients`
--
ALTER TABLE `patients`
  ADD PRIMARY KEY (`PatientID`);

--
-- Indexes for table `prescriptions`
--
ALTER TABLE `prescriptions`
  ADD PRIMARY KEY (`PrescriptionID`),
  ADD KEY `prescriptions_ibfk_1` (`PatientID`),
  ADD KEY `prescriptions_ibfk_2` (`DoctorID`);

--
-- Indexes for table `treatments`
--
ALTER TABLE `treatments`
  ADD PRIMARY KEY (`TreatmentID`),
  ADD KEY `treatments_ibfk_1` (`PatientID`),
  ADD KEY `treatments_ibfk_2` (`DoctorID`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `appointments`
--
ALTER TABLE `appointments`
  MODIFY `AppointmentID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=240;

--
-- AUTO_INCREMENT for table `doctors`
--
ALTER TABLE `doctors`
  MODIFY `DoctorID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=122;

--
-- AUTO_INCREMENT for table `patients`
--
ALTER TABLE `patients`
  MODIFY `PatientID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;

--
-- AUTO_INCREMENT for table `prescriptions`
--
ALTER TABLE `prescriptions`
  MODIFY `PrescriptionID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=411;

--
-- AUTO_INCREMENT for table `treatments`
--
ALTER TABLE `treatments`
  MODIFY `TreatmentID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=311;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `appointments`
--
ALTER TABLE `appointments`
  ADD CONSTRAINT `appointments_ibfk_1` FOREIGN KEY (`PatientID`) REFERENCES `patients` (`PatientID`) ON DELETE SET NULL ON UPDATE SET NULL,
  ADD CONSTRAINT `appointments_ibfk_2` FOREIGN KEY (`DoctorID`) REFERENCES `doctors` (`DoctorID`) ON DELETE SET NULL ON UPDATE SET NULL;

--
-- Constraints for table `prescriptions`
--
ALTER TABLE `prescriptions`
  ADD CONSTRAINT `prescriptions_ibfk_1` FOREIGN KEY (`PatientID`) REFERENCES `patients` (`PatientID`) ON DELETE SET NULL ON UPDATE SET NULL,
  ADD CONSTRAINT `prescriptions_ibfk_2` FOREIGN KEY (`DoctorID`) REFERENCES `doctors` (`DoctorID`) ON DELETE SET NULL ON UPDATE SET NULL;

--
-- Constraints for table `treatments`
--
ALTER TABLE `treatments`
  ADD CONSTRAINT `treatments_ibfk_1` FOREIGN KEY (`PatientID`) REFERENCES `patients` (`PatientID`) ON DELETE SET NULL ON UPDATE SET NULL,
  ADD CONSTRAINT `treatments_ibfk_2` FOREIGN KEY (`DoctorID`) REFERENCES `doctors` (`DoctorID`) ON DELETE SET NULL ON UPDATE SET NULL;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
