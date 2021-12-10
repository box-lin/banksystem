# BankSystemApp

`WSU ID: 011601661`

`Name: Boxiang Lin`

1. bug: create account make sure amount > 0, no negative accepted.

## Features

#### Registration

- Few accounts of Client and Employee are pre-generated, account username and password info will be stored in the **BankSystemApp** `bin/Debug` project folder.

  

#### Login	

- Clients and Employees are able to login with the existing accounts.

  

#### Account Creation

- Clients able to possess three types of, and multiple ones of, **Bank Account** - `Saving account`, `Checking account`, and `Loan account`.

- Clients able to open the `checking account` with an **initial deposit (amount > $0)**.
- Clients able to open the `saving account` with an **initial deposit (amount > $15,000)** so to adhere of default minimum balance requirement in a range of saving account lifetime.
- Clients able to open the `loan account` with a **loan limit ( greater than $0)**.



#### Transaction Category

- Clients able to deposit money into their own Bank Accounts (`Saving account`, `Checking account`, `Loan account`).
- Clients able to withdraw money from their own Bank Accounts (`Saving account`, `Checking account`, `Loan account`).
- Clients able to transfer money to their own, or other clients, Bank Accounts (`Saving account`, `Checking account`, `Loan account`).
- Each account stores a collection of **TEN** most recent transaction information. 
- Clients able to **UNDO** the transaction within 10 seconds after the transaction made. **(Redo available once undo made, undo available again until redo made, so on so forth, until 10 seconds ended. )**



## Dummy Accounts

#### Client:

- **Username:** `boxiang`, **Password: **123
- **Username:** `sam`, **Password: ** `123`



#### Employee

- **Username: **`john`, **Password: **`321`



 



