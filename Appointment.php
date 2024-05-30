<?php

require 'conn.php';

if ($_SERVER['REQUEST_METHOD'] == 'GET') {
    $sql = "SELECT AppointmentID, PatientID, DoctorID, AppointmentDate, Notes FROM appointments";
    $stmt = $pdo->query($sql);
    $appointments = $stmt->fetchAll();
    echo json_encode($appointments);
}
