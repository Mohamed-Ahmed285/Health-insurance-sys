# Health Insurance System v1.0


![Language](https://img.shields.io/badge/Language-C%23-blue)
![Framework](https://img.shields.io/badge/Framework-dot%20Net-red)
![Framework](https://img.shields.io/badge/Framework-Windows%20Forms-lightgrey)
![Status](https://img.shields.io/badge/InProgress-5%25-orange)

> A .NET WinForms desktop application designed to digitize health insurance policy management and medical claim adjudication using an Oracle Database.

## Description
The Health Insurance System v1.0 is a .NET-based application developed using Microsoft Visual Studio. It acts as a new, self-contained software prototype developed as an academic project to demonstrate the practical application of software engineering principles and database management. The system is structured using a two-tier desktop client-server architecture, utilizing a Windows Forms front-end that interfaces directly with a centralized Oracle Database. 

Its primary purpose is to digitize the medical claim reimbursement process and modernize the interaction between patients (policyholders) and the insurance provider. By allowing users to submit claims and digital medical documentation directly through the system's interface, the application eliminates paper-based bottlenecks and reduces the likelihood of manual data entry errors. The overarching objective is to significantly reduce the turnaround time for claim adjudication, thereby improving patient satisfaction and operational efficiency for the insurance company. This aligns with the broader strategic goal of transitioning legacy healthcare operations into secure, high-performance, and database-driven digital environments.

---

## Key Features

### For Policyholders (Patients)
* **Registration & Plan Subscription:** New users can securely sign up, choose an insurance coverage tier (e.g., Basic, Silver, Gold), and activate their policy via a simulated payment gateway.
* **Digital Claim Submission:** Patients can easily submit reimbursement requests for out-of-pocket medical expenses by entering visit details and uploading supporting medical invoices or prescriptions (PDF, JPG, PNG).
* **Real-Time Tracking:** Users can track the status of their submitted claims, seeing whether they are Pending, Approved, or Rejected.

### For Claims Administrators
* **Pending Claims Dashboard:** A centralized, data-dense interface allowing administrators to view a list of all currently pending claims.
* **Claim Adjudication:** Administrators can review attached medical documents natively within the application and officially approve or reject reimbursement requests.
* **Mandatory Rejection Reasons:** The system strictly enforces the entry of a valid reason before a claim can be marked as "Rejected".

---

## Technology Stack
* **Front-End User Interface:** Built natively using C# and Microsoft Windows Forms (WinForms).
* **Database Management:** Oracle Database (fully normalized to at least 3rd Normal Form).
* **Database Connectivity:** Oracle Data Provider for .NET (ODP.NET) over standard TCP/IP protocols.

---

## System Requirements
To run this application, the host environment must meet the following constraints:
* **Operating System:** Windows 10 or Windows 11.
* **Framework:** .NET Framework compatible with Visual Studio.
* **Dependencies:** A local instance of Oracle Database (e.g., Express Edition) and the correct installation of ODP.NET to ensure database interoperability.

---

## Security & Architecture Constraints
* **Role-Based Access Control (RBAC):** The system strictly separates Policyholder views from Administrative views, ensuring patients can only access their own sensitive data.
* **Data Encryption:** All user passwords are encrypted (e.g., SHA-256) before being stored in the Oracle Database; plain-text storage is strictly prohibited.
* **File Storage Architecture:** Uploaded medical images/PDFs are stored in a designated local/network directory, while the Oracle Database strictly stores the corresponding file path to maximize performance.
