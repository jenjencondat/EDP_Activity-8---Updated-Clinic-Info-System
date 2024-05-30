<?php

require 'conn.php';

if ($_SERVER['REQUEST_METHOD'] == 'POST') {
    $input = json_decode(file_get_contents('php://input'), true);
    $sql = 'INSERT INTO patients (PFirstName, PLastName, PGender, PAddress, PDateOfBirth, PContactNum) VALUES (?, ?, ?, ?, ?, ?)';

    $stmt = $pdo->prepare($sql);
    $stmt->execute([$input['PFirstName'], $input['PLastName'], $input['PGender'], $input['PAddress'], $input['PDateOfBirth'], $input['PContactNum']]);
    echo json_encode('Patient added');
}

if ($_SERVER['REQUEST_METHOD'] == 'GET') {
    $sql = 'SELECT PatientID, PFirstName, PLastName,PGender, PAddress,PDateOfBirth, PContactNum FROM patients';
    $stmt = $pdo->query($sql);
    $patients = $stmt->fetchAll();
    echo json_encode($patients);
}
