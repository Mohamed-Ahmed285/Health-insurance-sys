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

-- ADMINS
INSERT INTO Admins (Admin_ID, Username, Password_Hash) VALUES
  (admin_seq.NEXTVAL, 'superadmin',   '$2b$12$KIXx5v1J8oN3zQmWvRtLyOe9P1234567890ABCDEFGHabcdefgh01');
INSERT INTO Admins (Admin_ID, Username, Password_Hash) VALUES
  (admin_seq.NEXTVAL, 'ops_manager',  '$2b$12$TRxt8w2K9pO4aRnXwStMyPf0Q1234567890ABCDEFGHabcdefgh02');
INSERT INTO Admins (Admin_ID, Username, Password_Hash) VALUES
  (admin_seq.NEXTVAL, 'support_lead', '$2b$12$USyu9x3L0qP5bSoYxTuNzQg1R1234567890ABCDEFGHabcdefgh03');

-- INSURANCE PLANS  (Plan_ID will be 1..5)
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

-- HEALTHCARE PROVIDERS  (Provider_ID will be 1..8)
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
-- Plan_ID: 1=Basic Care, 2=Standard Plus, 3=Family Shield, 4=Senior Comfort, 5=Elite Platinum
INSERT INTO Subscriptions (Subscription_ID, Patient_National_ID, Plan_ID, Payment_Date, Amount_Paid) VALUES
  (sub_seq.NEXTVAL, '29901012345678', 2, DATE '2024-01-15',  300.00);
INSERT INTO Subscriptions (Subscription_ID, Patient_National_ID, Plan_ID, Payment_Date, Amount_Paid) VALUES
  (sub_seq.NEXTVAL, '29901012345678', 2, DATE '2024-07-15',  300.00);
INSERT INTO Subscriptions (Subscription_ID, Patient_National_ID, Plan_ID, Payment_Date, Amount_Paid) VALUES
  (sub_seq.NEXTVAL, '29805023456789', 1, DATE '2024-02-01',  150.00);
INSERT INTO Subscriptions (Subscription_ID, Patient_National_ID, Plan_ID, Payment_Date, Amount_Paid) VALUES
  (sub_seq.NEXTVAL, '29805023456789', 3, DATE '2025-02-01',  500.00);
INSERT INTO Subscriptions (Subscription_ID, Patient_National_ID, Plan_ID, Payment_Date, Amount_Paid) VALUES
  (sub_seq.NEXTVAL, '30103034567890', 1, DATE '2024-03-10',  150.00);
INSERT INTO Subscriptions (Subscription_ID, Patient_National_ID, Plan_ID, Payment_Date, Amount_Paid) VALUES
  (sub_seq.NEXTVAL, '29607045678901', 5, DATE '2024-04-01', 1200.00);
INSERT INTO Subscriptions (Subscription_ID, Patient_National_ID, Plan_ID, Payment_Date, Amount_Paid) VALUES
  (sub_seq.NEXTVAL, '29607045678901', 5, DATE '2025-04-01', 1200.00);
INSERT INTO Subscriptions (Subscription_ID, Patient_National_ID, Plan_ID, Payment_Date, Amount_Paid) VALUES
  (sub_seq.NEXTVAL, '30205056789012', 1, DATE '2024-05-20',  150.00);
INSERT INTO Subscriptions (Subscription_ID, Patient_National_ID, Plan_ID, Payment_Date, Amount_Paid) VALUES
  (sub_seq.NEXTVAL, '29508067890123', 3, DATE '2024-06-01',  500.00);
INSERT INTO Subscriptions (Subscription_ID, Patient_National_ID, Plan_ID, Payment_Date, Amount_Paid) VALUES
  (sub_seq.NEXTVAL, '30009078901234', 2, DATE '2024-08-15',  300.00);
INSERT INTO Subscriptions (Subscription_ID, Patient_National_ID, Plan_ID, Payment_Date, Amount_Paid) VALUES
  (sub_seq.NEXTVAL, '29710089012345', 4, DATE '2024-09-01',  250.00);
INSERT INTO Subscriptions (Subscription_ID, Patient_National_ID, Plan_ID, Payment_Date, Amount_Paid) VALUES
  (sub_seq.NEXTVAL, '29710089012345', 4, DATE '2025-03-01',  250.00);
INSERT INTO Subscriptions (Subscription_ID, Patient_National_ID, Plan_ID, Payment_Date, Amount_Paid) VALUES
  (sub_seq.NEXTVAL, '30111090123456', 2, DATE '2024-10-10',  300.00);
INSERT INTO Subscriptions (Subscription_ID, Patient_National_ID, Plan_ID, Payment_Date, Amount_Paid) VALUES
  (sub_seq.NEXTVAL, '29412100234567', 5, DATE '2024-11-01', 1200.00);
INSERT INTO Subscriptions (Subscription_ID, Patient_National_ID, Plan_ID, Payment_Date, Amount_Paid) VALUES
  (sub_seq.NEXTVAL, '30103034567890', 2, DATE '2025-01-10',  300.00);

-- TREATMENTS
-- Provider_ID: 1=Cairo General, 2=Nile Medical, 3=Al-Salam,
--              4=Delta Ortho,   5=Giza Cardio,  6=Heliopolis Eye,
--              7=Alex Pediatric, 8=Luxor Lab
INSERT INTO Treatments (Treatment_ID, Patient_National_ID, Provider_ID, Treatment_Cost, Treatment_Date) VALUES
  (treat_seq.NEXTVAL, '29901012345678', 1, 3200.00, DATE '2024-03-05');
INSERT INTO Treatments (Treatment_ID, Patient_National_ID, Provider_ID, Treatment_Cost, Treatment_Date) VALUES
  (treat_seq.NEXTVAL, '29901012345678', 5,  850.00, DATE '2024-09-20');
INSERT INTO Treatments (Treatment_ID, Patient_National_ID, Provider_ID, Treatment_Cost, Treatment_Date) VALUES
  (treat_seq.NEXTVAL, '29805023456789', 2,  420.00, DATE '2024-04-12');
INSERT INTO Treatments (Treatment_ID, Patient_National_ID, Provider_ID, Treatment_Cost, Treatment_Date) VALUES
  (treat_seq.NEXTVAL, '29805023456789', 7, 1100.00, DATE '2025-02-28');
INSERT INTO Treatments (Treatment_ID, Patient_National_ID, Provider_ID, Treatment_Cost, Treatment_Date) VALUES
  (treat_seq.NEXTVAL, '30103034567890', 3,  275.00, DATE '2024-05-18');
INSERT INTO Treatments (Treatment_ID, Patient_National_ID, Provider_ID, Treatment_Cost, Treatment_Date) VALUES
  (treat_seq.NEXTVAL, '29607045678901', 5, 8500.00, DATE '2024-06-30');
INSERT INTO Treatments (Treatment_ID, Patient_National_ID, Provider_ID, Treatment_Cost, Treatment_Date) VALUES
  (treat_seq.NEXTVAL, '29607045678901', 1, 2100.00, DATE '2024-11-14');
INSERT INTO Treatments (Treatment_ID, Patient_National_ID, Provider_ID, Treatment_Cost, Treatment_Date) VALUES
  (treat_seq.NEXTVAL, '30205056789012', 8,  180.00, DATE '2024-07-03');
INSERT INTO Treatments (Treatment_ID, Patient_National_ID, Provider_ID, Treatment_Cost, Treatment_Date) VALUES
  (treat_seq.NEXTVAL, '29508067890123', 4, 6200.00, DATE '2024-08-22');
INSERT INTO Treatments (Treatment_ID, Patient_National_ID, Provider_ID, Treatment_Cost, Treatment_Date) VALUES
  (treat_seq.NEXTVAL, '29508067890123', 2,  950.00, DATE '2025-01-07');
INSERT INTO Treatments (Treatment_ID, Patient_National_ID, Provider_ID, Treatment_Cost, Treatment_Date) VALUES
  (treat_seq.NEXTVAL, '30009078901234', 6,  390.00, DATE '2024-10-01');
INSERT INTO Treatments (Treatment_ID, Patient_National_ID, Provider_ID, Treatment_Cost, Treatment_Date) VALUES
  (treat_seq.NEXTVAL, '29710089012345', 1, 1750.00, DATE '2024-11-25');
INSERT INTO Treatments (Treatment_ID, Patient_National_ID, Provider_ID, Treatment_Cost, Treatment_Date) VALUES
  (treat_seq.NEXTVAL, '29710089012345', 8,  230.00, DATE '2025-03-15');
INSERT INTO Treatments (Treatment_ID, Patient_National_ID, Provider_ID, Treatment_Cost, Treatment_Date) VALUES
  (treat_seq.NEXTVAL, '30111090123456', 3,  560.00, DATE '2024-12-10');
INSERT INTO Treatments (Treatment_ID, Patient_National_ID, Provider_ID, Treatment_Cost, Treatment_Date) VALUES
  (treat_seq.NEXTVAL, '29412100234567', 5, 4800.00, DATE '2025-01-30');
INSERT INTO Treatments (Treatment_ID, Patient_National_ID, Provider_ID, Treatment_Cost, Treatment_Date) VALUES
  (treat_seq.NEXTVAL, '29412100234567', 4, 3100.00, DATE '2025-04-10');
INSERT INTO Treatments (Treatment_ID, Patient_National_ID, Provider_ID, Treatment_Cost, Treatment_Date) VALUES
  (treat_seq.NEXTVAL, '30103034567890', 2,  710.00, DATE '2025-02-14');
INSERT INTO Treatments (Treatment_ID, Patient_National_ID, Provider_ID, Treatment_Cost, Treatment_Date) VALUES
  (treat_seq.NEXTVAL, '29607045678901', 6,  340.00, DATE '2025-03-22');
INSERT INTO Treatments (Treatment_ID, Patient_National_ID, Provider_ID, Treatment_Cost, Treatment_Date) VALUES
  (treat_seq.NEXTVAL, '29508067890123', 5, 2250.00, DATE '2025-04-05');
INSERT INTO Treatments (Treatment_ID, Patient_National_ID, Provider_ID, Treatment_Cost, Treatment_Date) VALUES
  (treat_seq.NEXTVAL, '30009078901234', 1,  980.00, DATE '2025-04-18');

COMMIT;