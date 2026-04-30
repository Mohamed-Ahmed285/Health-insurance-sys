DROP TABLE Treatments CASCADE CONSTRAINTS;
DROP TABLE Subscriptions CASCADE CONSTRAINTS;
DROP TABLE Patients CASCADE CONSTRAINTS;
DROP TABLE Healthcare_Providers CASCADE CONSTRAINTS;
DROP TABLE Insurance_Plans CASCADE CONSTRAINTS;
DROP TABLE Admins CASCADE CONSTRAINTS;

DROP SEQUENCE admin_seq;
DROP SEQUENCE plan_seq;
DROP SEQUENCE sub_seq;
DROP SEQUENCE provider_seq;
DROP SEQUENCE treat_seq;


CREATE TABLE Admins (
    Admin_ID NUMBER PRIMARY KEY,
    Username VARCHAR2(50) UNIQUE NOT NULL,
    Password_Hash VARCHAR2(255) NOT NULL
);

CREATE TABLE Insurance_Plans (
    Plan_ID NUMBER PRIMARY KEY,
    Plan_Name VARCHAR2(100) NOT NULL,
    Premium_Fee NUMBER(10, 2) NOT NULL,
    Coverage_Amount NUMBER(10, 2) NOT NULL
);

CREATE TABLE Patients (
    National_ID VARCHAR2(20) PRIMARY KEY, 
    Full_Name VARCHAR2(150) NOT NULL,
    Phone VARCHAR2(20) UNIQUE NOT NULL,
    Email VARCHAR2(100) UNIQUE NOT NULL,
    Password_Hash VARCHAR2(255) NOT NULL,
    Current_Balance NUMBER(10, 2) DEFAULT 0
);

CREATE TABLE Subscriptions (
    Subscription_ID NUMBER PRIMARY KEY,
    Patient_National_ID VARCHAR2(20) NOT NULL,
    Plan_ID NUMBER NOT NULL,
    Payment_Date DATE DEFAULT SYSDATE,
    Amount_Paid NUMBER(10, 2) NOT NULL,
    CONSTRAINT fk_sub_patient FOREIGN KEY (Patient_National_ID) REFERENCES Patients(National_ID),
    CONSTRAINT fk_sub_plan FOREIGN KEY (Plan_ID) REFERENCES Insurance_Plans(Plan_ID)
);

CREATE TABLE Healthcare_Providers (
    Provider_ID NUMBER PRIMARY KEY,
    Provider_Name VARCHAR2(150) NOT NULL,
    Contact_Info VARCHAR2(255) NOT NULL
);

CREATE TABLE Treatments (
    Treatment_ID NUMBER PRIMARY KEY,
    Patient_National_ID VARCHAR2(20) NOT NULL,
    Provider_ID NUMBER NOT NULL,
    Treatment_Cost NUMBER(10, 2) NOT NULL,
    Treatment_Date DATE DEFAULT SYSDATE,
    CONSTRAINT fk_treat_patient FOREIGN KEY (Patient_National_ID) REFERENCES Patients(National_ID),
    CONSTRAINT fk_treat_provider FOREIGN KEY (Provider_ID) REFERENCES Healthcare_Providers(Provider_ID)
);


CREATE SEQUENCE admin_seq START WITH 1 INCREMENT BY 1;
CREATE SEQUENCE plan_seq START WITH 1 INCREMENT BY 1;
CREATE SEQUENCE sub_seq START WITH 1 INCREMENT BY 1;
CREATE SEQUENCE provider_seq START WITH 1 INCREMENT BY 1;
CREATE SEQUENCE treat_seq START WITH 1 INCREMENT BY 1;


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
  (admin_seq.NEXTVAL, 'superadmin',   'SM60v5DWWeJRjme5YBuZZD9eLYtMVTlupmuKMbRjt1Q=');
INSERT INTO Admins (Admin_ID, Username, Password_Hash) VALUES
  (admin_seq.NEXTVAL, 'ops_manager',  'SM60v5DWWeJRjme5YBuZZD9eLYtMVTlupmuKMbRjt1Q=');
INSERT INTO Admins (Admin_ID, Username, Password_Hash) VALUES
  (admin_seq.NEXTVAL, 'support_lead', 'SM60v5DWWeJRjme5YBuZZD9eLYtMVTlupmuKMbRjt1Q=');

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
  ('29901012345678', 'Ahmed Hassan Mostafa', '01001234567', 'ahmed.hassan@gmail.com',    'SM60v5DWWeJRjme5YBuZZD9eLYtMVTlupmuKMbRjt1Q=', 2500.00);
INSERT INTO Patients (National_ID, Full_Name, Phone, Email, Password_Hash, Current_Balance) VALUES
  ('29805023456789', 'Fatma Ibrahim Ali',    '01112345678', 'fatma.ibrahim@yahoo.com',   'SM60v5DWWeJRjme5YBuZZD9eLYtMVTlupmuKMbRjt1Q=', 1800.50);
INSERT INTO Patients (National_ID, Full_Name, Phone, Email, Password_Hash, Current_Balance) VALUES
  ('30103034567890', 'Mohamed Samir Khalil', '01223456789', 'mohamed.samir@outlook.com', 'SM60v5DWWeJRjme5YBuZZD9eLYtMVTlupmuKMbRjt1Q=',  950.00);
INSERT INTO Patients (National_ID, Full_Name, Phone, Email, Password_Hash, Current_Balance) VALUES
  ('29607045678901', 'Nour Abdel Rahman',    '01034567890', 'nour.ar@gmail.com',         'SM60v5DWWeJRjme5YBuZZD9eLYtMVTlupmuKMbRjt1Q=', 4200.75);
INSERT INTO Patients (National_ID, Full_Name, Phone, Email, Password_Hash, Current_Balance) VALUES
  ('30205056789012', 'Youssef Adel Mansour', '01145678901', 'youssef.adel@gmail.com',    'SM60v5DWWeJRjme5YBuZZD9eLYtMVTlupmuKMbRjt1Q=',  300.00);
INSERT INTO Patients (National_ID, Full_Name, Phone, Email, Password_Hash, Current_Balance) VALUES
  ('29508067890123', 'Hana Gamal Fouad',     '01256789012', 'hana.gamal@hotmail.com',    'SM60v5DWWeJRjme5YBuZZD9eLYtMVTlupmuKMbRjt1Q=', 7500.00);
INSERT INTO Patients (National_ID, Full_Name, Phone, Email, Password_Hash, Current_Balance) VALUES
  ('30009078901234', 'Karim Tarek Nasser',   '01067890123', 'karim.tarek@gmail.com',     'SM60v5DWWeJRjme5YBuZZD9eLYtMVTlupmuKMbRjt1Q=', 1150.25);
INSERT INTO Patients (National_ID, Full_Name, Phone, Email, Password_Hash, Current_Balance) VALUES
  ('29710089012345', 'Sara Magdy Younis',    '01178901234', 'sara.magdy@yahoo.com',      'SM60v5DWWeJRjme5YBuZZD9eLYtMVTlupmuKMbRjt1Q=', 3300.00);
INSERT INTO Patients (National_ID, Full_Name, Phone, Email, Password_Hash, Current_Balance) VALUES
  ('30111090123456', 'Omar Khaled Barakat',  '01289012345', 'omar.khaled@gmail.com',     'SM60v5DWWeJRjme5YBuZZD9eLYtMVTlupmuKMbRjt1Q=',  620.00);
INSERT INTO Patients (National_ID, Full_Name, Phone, Email, Password_Hash, Current_Balance) VALUES
  ('29412100234567', 'Layla Ashraf Zaki',    '01090123456', 'layla.ashraf@outlook.com',  'SM60v5DWWeJRjme5YBuZZD9eLYtMVTlupmuKMbRjt1Q=', 5100.00);

-- SUBSCRIPTIONS
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
-- Procedures

CREATE OR REPLACE PROCEDURE GET_INSURANCE_PLANS (p_cursor OUT SYS_REFCURSOR) AS
BEGIN
  OPEN p_cursor FOR
    SELECT
      PLAN_ID,
      PLAN_NAME,
      PREMIUM_FEE,
      COVERAGE_AMOUNT
    FROM INSURANCE_PLANS
    ORDER BY PLAN_NAME;
END GET_INSURANCE_PLANS;
/

----------------------------

CREATE OR REPLACE PROCEDURE GET_PATIENT_PROFILE (
  p_nid       IN  VARCHAR2,
  p_full_name OUT VARCHAR2,
  p_email     OUT VARCHAR2,
  p_phone     OUT VARCHAR2,
  p_password  OUT VARCHAR2,
  p_balance   OUT NUMBER
) AS
BEGIN
  SELECT FULL_NAME,
         EMAIL,
         PHONE,
         PASSWORD_HASH,
         NVL(CURRENT_BALANCE, 0)
    INTO p_full_name,
         p_email,
         p_phone,
         p_password,
         p_balance
    FROM PATIENTS
   WHERE NATIONAL_ID = p_nid;
EXCEPTION
  WHEN NO_DATA_FOUND THEN
    p_full_name := NULL;
    p_email := NULL;
    p_phone := NULL;
    p_password := NULL;
    p_balance := 0;
END GET_PATIENT_PROFILE;
/

---------------------------

CREATE OR REPLACE PROCEDURE GET_SUBSCRIPTION_ID (p_next OUT NUMBER) AS
BEGIN
  SELECT NVL(MAX(SUBSCRIPTION_ID), 0) + 1
    INTO p_next
    FROM SUBSCRIPTIONS;
END GET_SUBSCRIPTION_ID;
/


