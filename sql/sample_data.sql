-- ────────────────────────────────────────────────────────────
--  STEP 1: Clear existing data (child tables first)
-- ────────────────────────────────────────────────────────────
DELETE FROM Treatments;
DELETE FROM Subscriptions;
DELETE FROM Patients;
DELETE FROM Healthcare_Providers;
DELETE FROM Insurance_Plans;
DELETE FROM Admins;
COMMIT;

-- ────────────────────────────────────────────────────────────
--  STEP 2: Reset sequences
-- ────────────────────────────────────────────────────────────
DROP SEQUENCE admin_seq;
DROP SEQUENCE plan_seq;
DROP SEQUENCE sub_seq;
DROP SEQUENCE provider_seq;
DROP SEQUENCE treat_seq;

CREATE SEQUENCE admin_seq    START WITH 1 INCREMENT BY 1;
CREATE SEQUENCE plan_seq     START WITH 1 INCREMENT BY 1;
CREATE SEQUENCE sub_seq      START WITH 1 INCREMENT BY 1;
CREATE SEQUENCE provider_seq START WITH 1 INCREMENT BY 1;
CREATE SEQUENCE treat_seq    START WITH 1 INCREMENT BY 1;

-- ────────────────────────────────────────────────────────────
--  STEP 3: Insert data
-- ────────────────────────────────────────────────────────────

-- ADMINS
INSERT INTO Admins (Admin_ID, Username, Password_Hash) VALUES
  (admin_seq.NEXTVAL, 'superadmin',   '$2b$12$KIXx5v1J8oN3zQmWvRtLyOe9P1234567890ABCDEFGHabcdefgh01');
INSERT INTO Admins (Admin_ID, Username, Password_Hash) VALUES
  (admin_seq.NEXTVAL, 'ops_manager',  '$2b$12$TRxt8w2K9pO4aRnXwStMyPf0Q1234567890ABCDEFGHabcdefgh02');
INSERT INTO Admins (Admin_ID, Username, Password_Hash) VALUES
  (admin_seq.NEXTVAL, 'support_lead', '$2b$12$USyu9x3L0qP5bSoYxTuNzQg1R1234567890ABCDEFGHabcdefgh03');

-- INSURANCE PLANS  (Plan_ID: 1=Basic, 2=Standard, 3=Family, 4=Senior, 5=Elite)
INSERT INTO Insurance_Plans (Plan_ID, Plan_Name, Premium_Fee, Coverage_Amount) VALUES
  (plan_seq.NEXTVAL, 'Basic Care',      150.00,   5000.00);
INSERT INTO Insurance_Plans (Plan_ID, Plan_Name, Premium_Fee, Coverage_Amount) VALUES
  (plan_seq.NEXTVAL, 'Standard Plus',   300.00,  15000.00);
INSERT INTO Insurance_Plans (Plan_ID, Plan_Name, Premium_Fee, Coverage_Amount) VALUES
  (plan_seq.NEXTVAL, 'Family Shield',   500.00,  30000.00);
INSERT INTO Insurance_Plans (Plan_ID, Plan_Name, Premium_Fee, Coverage_Amount) VALUES
  (plan_seq.NEXTVAL, 'Senior Comfort',  250.00,  20000.00);
INSERT INTO Insurance_Plans (Plan_ID, Plan_Name, Premium_Fee, Coverage_Amount) VALUES
  (plan_seq.NEXTVAL, 'Elite Platinum', 1200.00, 100000.00);

-- HEALTHCARE PROVIDERS  (Provider_ID: 1..8)
INSERT INTO Healthcare_Providers (Provider_ID, Provider_Name, Contact_Info) VALUES
  (provider_seq.NEXTVAL, 'Cairo General Hospital',     'Tel: +20-2-2345-6789 | cairo-general@health.eg');
INSERT INTO Healthcare_Providers (Provider_ID, Provider_Name, Contact_Info) VALUES
  (provider_seq.NEXTVAL, 'Nile Medical Center',        'Tel: +20-2-3456-7890 | info@nilemedical.eg');
INSERT INTO Healthcare_Providers (Provider_ID, Provider_Name, Contact_Info) VALUES
  (provider_seq.NEXTVAL, 'Al-Salam Clinic',            'Tel: +20-2-4567-8901 | alsalam@clinic.eg');
INSERT INTO Healthcare_Providers (Provider_ID, Provider_Name, Contact_Info) VALUES
  (provider_seq.NEXTVAL, 'Delta Orthopedic Center',    'Tel: +20-45-567-8902 | delta@ortho.eg');
INSERT INTO Healthcare_Providers (Provider_ID, Provider_Name, Contact_Info) VALUES
  (provider_seq.NEXTVAL, 'Giza Cardiology Institute',  'Tel: +20-2-5678-9012 | giza@cardio.eg');
INSERT INTO Healthcare_Providers (Provider_ID, Provider_Name, Contact_Info) VALUES
  (provider_seq.NEXTVAL, 'Heliopolis Eye Clinic',      'Tel: +20-2-6789-0123 | heliopolis@eye.eg');
INSERT INTO Healthcare_Providers (Provider_ID, Provider_Name, Contact_Info) VALUES
  (provider_seq.NEXTVAL, 'Alexandria Pediatric Hosp.', 'Tel: +20-3-789-0124  | alex@pediatric.eg');
INSERT INTO Healthcare_Providers (Provider_ID, Provider_Name, Contact_Info) VALUES
  (provider_seq.NEXTVAL, 'Luxor Diagnostic Lab',       'Tel: +20-95-890-0125 | luxor@diaglab.eg');

-- PATIENTS
INSERT INTO Patients (National_ID, Full_Name, Phone, Email, Password_Hash, Current_Balance) VALUES
  ('29901012345678', 'Ahmed Hassan Mostafa', '01001234567', 'ahmed.hassan@gmail.com',    '$2b$12$abc1111111111111111111uABCDEFGHIJKLMNOPQRSTUVWXYZab', 2500.00);
INSERT INTO Patients (National_ID, Full_Name, Phone, Email, Password_Hash, Current_Balance) VALUES
  ('29805023456789', 'Fatma Ibrahim Ali',    '01112345678', 'fatma.ibrahim@yahoo.com',   '$2b$12$abc2222222222222222222uABCDEFGHIJKLMNOPQRSTUVWXYZab', 1800.50);
INSERT INTO Patients (National_ID, Full_Name, Phone, Email, Password_Hash, Current_Balance) VALUES
  ('30103034567890', 'Mohamed Samir Khalil', '01223456789', 'mohamed.samir@outlook.com', '$2b$12$abc3333333333333333333uABCDEFGHIJKLMNOPQRSTUVWXYZab',  950.00);
INSERT INTO Patients (National_ID, Full_Name, Phone, Email, Password_Hash, Current_Balance) VALUES
  ('29607045678901', 'Nour Abdel Rahman',    '01034567890', 'nour.ar@gmail.com',         '$2b$12$abc4444444444444444444uABCDEFGHIJKLMNOPQRSTUVWXYZab', 4200.75);
INSERT INTO Patients (National_ID, Full_Name, Phone, Email, Password_Hash, Current_Balance) VALUES
  ('30205056789012', 'Youssef Adel Mansour', '01145678901', 'youssef.adel@gmail.com',    '$2b$12$abc5555555555555555555uABCDEFGHIJKLMNOPQRSTUVWXYZab',  300.00);
INSERT INTO Patients (National_ID, Full_Name, Phone, Email, Password_Hash, Current_Balance) VALUES
  ('29508067890123', 'Hana Gamal Fouad',     '01256789012', 'hana.gamal@hotmail.com',    '$2b$12$abc6666666666666666666uABCDEFGHIJKLMNOPQRSTUVWXYZab', 7500.00);
INSERT INTO Patients (National_ID, Full_Name, Phone, Email, Password_Hash, Current_Balance) VALUES
  ('30009078901234', 'Karim Tarek Nasser',   '01067890123', 'karim.tarek@gmail.com',     '$2b$12$abc7777777777777777777uABCDEFGHIJKLMNOPQRSTUVWXYZab', 1150.25);
INSERT INTO Patients (National_ID, Full_Name, Phone, Email, Password_Hash, Current_Balance) VALUES
  ('29710089012345', 'Sara Magdy Younis',    '01178901234', 'sara.magdy@yahoo.com',      '$2b$12$abc8888888888888888888uABCDEFGHIJKLMNOPQRSTUVWXYZab', 3300.00);
INSERT INTO Patients (National_ID, Full_Name, Phone, Email, Password_Hash, Current_Balance) VALUES
  ('30111090123456', 'Omar Khaled Barakat',  '01289012345', 'omar.khaled@gmail.com',     '$2b$12$abc9999999999999999999uABCDEFGHIJKLMNOPQRSTUVWXYZab',  620.00);
INSERT INTO Patients (National_ID, Full_Name, Phone, Email, Password_Hash, Current_Balance) VALUES
  ('29412100234567', 'Layla Ashraf Zaki',    '01090123456', 'layla.ashraf@outlook.com',  '$2b$12$abcAAAAAAAAAAAAAAAAAAAAuABCDEFGHIJKLMNOPQRSTUVWXYZab', 5100.00);

-- SUBSCRIPTIONS
INSERT INTO Subscriptions (Subscription_ID, Patient_National_ID, Plan_ID, Payment_Date, Amount_Paid) VALUES
  (sub_seq.NEXTVAL, '29901012345678', 2, DATE '2024-01-15',  300.00);  -- Ahmed    → Standard Plus  (covers 15,000)
INSERT INTO Subscriptions (Subscription_ID, Patient_National_ID, Plan_ID, Payment_Date, Amount_Paid) VALUES
  (sub_seq.NEXTVAL, '29901012345678', 2, DATE '2024-07-15',  300.00);
INSERT INTO Subscriptions (Subscription_ID, Patient_National_ID, Plan_ID, Payment_Date, Amount_Paid) VALUES
  (sub_seq.NEXTVAL, '29805023456789', 1, DATE '2024-02-01',  150.00);  -- Fatma    → Basic Care     (covers  5,000)
INSERT INTO Subscriptions (Subscription_ID, Patient_National_ID, Plan_ID, Payment_Date, Amount_Paid) VALUES
  (sub_seq.NEXTVAL, '29805023456789', 3, DATE '2025-02-01',  500.00);  -- Fatma    → Family Shield  (covers 30,000)
INSERT INTO Subscriptions (Subscription_ID, Patient_National_ID, Plan_ID, Payment_Date, Amount_Paid) VALUES
  (sub_seq.NEXTVAL, '30103034567890', 1, DATE '2024-03-10',  150.00);  -- Mohamed  → Basic Care     (covers  5,000)
INSERT INTO Subscriptions (Subscription_ID, Patient_National_ID, Plan_ID, Payment_Date, Amount_Paid) VALUES
  (sub_seq.NEXTVAL, '29607045678901', 5, DATE '2024-04-01', 1200.00);  -- Nour     → Elite Platinum (covers 100,000)
INSERT INTO Subscriptions (Subscription_ID, Patient_National_ID, Plan_ID, Payment_Date, Amount_Paid) VALUES
  (sub_seq.NEXTVAL, '29607045678901', 5, DATE '2025-04-01', 1200.00);
INSERT INTO Subscriptions (Subscription_ID, Patient_National_ID, Plan_ID, Payment_Date, Amount_Paid) VALUES
  (sub_seq.NEXTVAL, '30205056789012', 1, DATE '2024-05-20',  150.00);  -- Youssef  → Basic Care     (covers  5,000)
INSERT INTO Subscriptions (Subscription_ID, Patient_National_ID, Plan_ID, Payment_Date, Amount_Paid) VALUES
  (sub_seq.NEXTVAL, '29508067890123', 2, DATE '2024-06-01',  300.00);  -- Hana     → Standard Plus  (covers 15,000)
INSERT INTO Subscriptions (Subscription_ID, Patient_National_ID, Plan_ID, Payment_Date, Amount_Paid) VALUES
  (sub_seq.NEXTVAL, '30009078901234', 2, DATE '2024-08-15',  300.00);  -- Karim    → Standard Plus  (covers 15,000)
INSERT INTO Subscriptions (Subscription_ID, Patient_National_ID, Plan_ID, Payment_Date, Amount_Paid) VALUES
  (sub_seq.NEXTVAL, '29710089012345', 4, DATE '2024-09-01',  250.00);  -- Sara     → Senior Comfort (covers 20,000)
INSERT INTO Subscriptions (Subscription_ID, Patient_National_ID, Plan_ID, Payment_Date, Amount_Paid) VALUES
  (sub_seq.NEXTVAL, '29710089012345', 4, DATE '2025-03-01',  250.00);
INSERT INTO Subscriptions (Subscription_ID, Patient_National_ID, Plan_ID, Payment_Date, Amount_Paid) VALUES
  (sub_seq.NEXTVAL, '30111090123456', 2, DATE '2024-10-10',  300.00);  -- Omar     → Standard Plus  (covers 15,000)
INSERT INTO Subscriptions (Subscription_ID, Patient_National_ID, Plan_ID, Payment_Date, Amount_Paid) VALUES
  (sub_seq.NEXTVAL, '29412100234567', 5, DATE '2024-11-01', 1200.00);  -- Layla    → Elite Platinum (covers 100,000)
INSERT INTO Subscriptions (Subscription_ID, Patient_National_ID, Plan_ID, Payment_Date, Amount_Paid) VALUES
  (sub_seq.NEXTVAL, '30103034567890', 2, DATE '2025-01-10',  300.00);  -- Mohamed  → Standard Plus  (covers 15,000)

-- Treatments
INSERT INTO Treatments (Treatment_ID, Patient_National_ID, Provider_ID, Treatment_Cost, Treatment_Date) VALUES
  (treat_seq.NEXTVAL, '29901012345678', 1,  3200.00, DATE '2024-03-05');
INSERT INTO Treatments (Treatment_ID, Patient_National_ID, Provider_ID, Treatment_Cost, Treatment_Date) VALUES
  (treat_seq.NEXTVAL, '29901012345678', 5,   850.00, DATE '2024-09-20');
INSERT INTO Treatments (Treatment_ID, Patient_National_ID, Provider_ID, Treatment_Cost, Treatment_Date) VALUES
  (treat_seq.NEXTVAL, '29805023456789', 1,  7500.00, DATE '2024-04-12');  -- costs 7,500 > 5,000 coverage
INSERT INTO Treatments (Treatment_ID, Patient_National_ID, Provider_ID, Treatment_Cost, Treatment_Date) VALUES
  (treat_seq.NEXTVAL, '29805023456789', 7,   420.00, DATE '2025-02-28');  -- routine, no gap
INSERT INTO Treatments (Treatment_ID, Patient_National_ID, Provider_ID, Treatment_Cost, Treatment_Date) VALUES
  (treat_seq.NEXTVAL, '30103034567890', 3,  6800.00, DATE '2024-05-18');  -- costs 6,800 > 5,000 coverage
INSERT INTO Treatments (Treatment_ID, Patient_National_ID, Provider_ID, Treatment_Cost, Treatment_Date) VALUES
  (treat_seq.NEXTVAL, '30103034567890', 2,   275.00, DATE '2025-02-14');  -- routine, no gap
INSERT INTO Treatments (Treatment_ID, Patient_National_ID, Provider_ID, Treatment_Cost, Treatment_Date) VALUES
  (treat_seq.NEXTVAL, '29607045678901', 5,  8500.00, DATE '2024-06-30');
INSERT INTO Treatments (Treatment_ID, Patient_National_ID, Provider_ID, Treatment_Cost, Treatment_Date) VALUES
  (treat_seq.NEXTVAL, '29607045678901', 1,  2100.00, DATE '2024-11-14');
INSERT INTO Treatments (Treatment_ID, Patient_National_ID, Provider_ID, Treatment_Cost, Treatment_Date) VALUES
  (treat_seq.NEXTVAL, '29607045678901', 6,   340.00, DATE '2025-03-22');
INSERT INTO Treatments (Treatment_ID, Patient_National_ID, Provider_ID, Treatment_Cost, Treatment_Date) VALUES
  (treat_seq.NEXTVAL, '30205056789012', 4,  9200.00, DATE '2024-07-03');  -- costs 9,200 > 5,000 coverage
INSERT INTO Treatments (Treatment_ID, Patient_National_ID, Provider_ID, Treatment_Cost, Treatment_Date) VALUES
  (treat_seq.NEXTVAL, '29508067890123', 4, 18500.00, DATE '2024-08-22');  -- costs 18,500 > 15,000 coverage
INSERT INTO Treatments (Treatment_ID, Patient_National_ID, Provider_ID, Treatment_Cost, Treatment_Date) VALUES
  (treat_seq.NEXTVAL, '29508067890123', 2,   950.00, DATE '2025-01-07');  -- routine, no gap
INSERT INTO Treatments (Treatment_ID, Patient_National_ID, Provider_ID, Treatment_Cost, Treatment_Date) VALUES
  (treat_seq.NEXTVAL, '29508067890123', 5,  2250.00, DATE '2025-04-05');  -- routine, no gap
INSERT INTO Treatments (Treatment_ID, Patient_National_ID, Provider_ID, Treatment_Cost, Treatment_Date) VALUES
  (treat_seq.NEXTVAL, '30009078901234', 6,   390.00, DATE '2024-10-01');
INSERT INTO Treatments (Treatment_ID, Patient_National_ID, Provider_ID, Treatment_Cost, Treatment_Date) VALUES
  (treat_seq.NEXTVAL, '30009078901234', 1,   980.00, DATE '2025-04-18');
INSERT INTO Treatments (Treatment_ID, Patient_National_ID, Provider_ID, Treatment_Cost, Treatment_Date) VALUES
  (treat_seq.NEXTVAL, '29710089012345', 5, 23000.00, DATE '2024-11-25');  -- costs 23,000 > 20,000 coverage
INSERT INTO Treatments (Treatment_ID, Patient_National_ID, Provider_ID, Treatment_Cost, Treatment_Date) VALUES
  (treat_seq.NEXTVAL, '29710089012345', 8,   230.00, DATE '2025-03-15');  -- routine, no gap
INSERT INTO Treatments (Treatment_ID, Patient_National_ID, Provider_ID, Treatment_Cost, Treatment_Date) VALUES
  (treat_seq.NEXTVAL, '30111090123456', 3,   560.00, DATE '2024-12-10');
INSERT INTO Treatments (Treatment_ID, Patient_National_ID, Provider_ID, Treatment_Cost, Treatment_Date) VALUES
  (treat_seq.NEXTVAL, '29412100234567', 5,  4800.00, DATE '2025-01-30');
INSERT INTO Treatments (Treatment_ID, Patient_National_ID, Provider_ID, Treatment_Cost, Treatment_Date) VALUES
  (treat_seq.NEXTVAL, '29412100234567', 4,  3100.00, DATE '2025-04-10');

COMMIT;