
CREATE OR REPLACE PROCEDURE SubscribeToPlan (
    p_national_id IN VARCHAR2,
    p_plan_id IN NUMBER,
    p_amount IN NUMBER
) AS
BEGIN
 
    INSERT INTO Subscriptions (Subscription_ID, Patient_National_ID, Plan_ID, Amount_Paid, Payment_Date)
    VALUES (sub_seq.NEXTVAL, p_national_id, p_plan_id, p_amount, SYSDATE);
    

    UPDATE Patients 
    SET Current_Balance = Current_Balance - p_amount 
    WHERE National_ID = p_national_id;
    

    COMMIT;
EXCEPTION
    WHEN OTHERS THEN
        ROLLBACK;
        RAISE_APPLICATION_ERROR(-20001, 'An error occurred during subscription: ' || SQLERRM);
END;
/

CREATE OR REPLACE PROCEDURE GetPatientProfile (
    p_id IN VARCHAR2,
    p_name OUT VARCHAR2,
    p_phone OUT VARCHAR2,
    p_email OUT VARCHAR2
) AS
BEGIN
    SELECT Full_Name, Phone, Email INTO p_name, p_phone, p_email
    FROM Patients WHERE National_ID = p_id;
END;

