<?php

require 'conn.php';

if ($_SERVER['REQUEST_METHOD'] == 'POST') {
    $input = json_decode(file_get_contents('php://input'), true);
    $sql = 'INSERT INTO doctors (DFirstName, DLastName, gender, DSpecialization, address, birthdate, DContactNum) VALUES (?, ?, ?, ?, ?, ?, ?)';

    $stmt = $pdo->prepare($sql);
    $stmt->execute([$input['DFirstName'], $input['DLastName'], $input['gender'], $input['DSpecialization'], $input['address'], $input['birthdate'], $input['DContactNum']]);
    echo json_encode('Doctor added');
}

if ($_SERVER['REQUEST_METHOD'] == 'GET') {
    $sql = 'SELECT DoctorID, DFirstName, DLastName, gender, DSpecialization, address, birthdate, DContactNum FROM doctors';
    $stmt = $pdo->query($sql);
    $doctors = $stmt->fetchAll();
    echo json_encode($doctors);
}
